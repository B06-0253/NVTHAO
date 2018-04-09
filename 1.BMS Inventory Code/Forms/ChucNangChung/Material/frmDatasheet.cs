using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BMS.Model;
using BMS.Business;
using BMS.Utils;
using System.IO;
using DevExpress.Utils;

namespace BMS
{
    public partial class frmDatasheet : _Forms
    {
        #region Variables
        public List<int> ListMaterialFileID = new List<int>();
        public bool ChooseFile = false;
        public int CustomerID = 0;
        #endregion

        #region Contructors and Load
        public frmDatasheet()
        {
            InitializeComponent();
        }

        private void frmDatasheet_Load(object sender, EventArgs e)
        {
            DocUtils.InitFTPTK();
            loadCustomer();
           
            btnChoose.Visible = ChooseFile;

            if (ChooseFile)
            {
                gbHang.Visible = false;
                gbFile.Width += gbHang.Width;
            }
        } 
        #endregion

        void loadCustomer()
        {
            DataTable dt = TextUtils.Select("Customer", new Expression("Type", 0));//0 là hãng
            grdCustomer.DataSource = dt;
        }

        private void loadGrid()
        {
            int cusID = 0;
            if (CustomerID > 0)
            {
                cusID = CustomerID;
            }
            else
            {
                cusID = TextUtils.ToInt(grvCustomer.GetFocusedRowCellValue(colID));
            }
            
            if (cusID <= 0) return;
            //DataTable dt = TextUtils.Select("MaterialFile", new Expression("CustormerID", cusID));//lấy ra danh sách datasheet
            DataTable dt = TextUtils.Select("Select * from MaterialFile with(nolock) where CustormerID = " + cusID + " order by id desc");
            grdData.DataSource = dt;
        }

        private void btnUpDatasheet_Click(object sender, EventArgs e)
        {
            int cusID = 0;
            string hang = "";
            if (CustomerID > 0)
            {
                cusID = CustomerID;
                hang = ((CustomerModel)CustomerBO.Instance.FindByPK(CustomerID)).Name;
            }
            else
            {
                cusID = TextUtils.ToInt(grvCustomer.GetFocusedRowCellValue(colID));
                hang = grvCustomer.GetFocusedRowCellValue(colCode).ToString();
            }

            if (cusID == 0)
            {
                MessageBox.Show("Bạn hãy chọn một hãng để up datasheet!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            int count = 0;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                foreach (string filePath in ofd.FileNames)
                {
                    ProcessTransaction pt = new ProcessTransaction();
                    pt.OpenConnection();
                    pt.BeginTransaction();
                    try
                    {
                        FileInfo fInfo = new FileInfo(filePath);
                        MaterialFileModel fileModel;
                        bool isAdd = true;
                        if (MaterialFileBO.Instance.CheckExist("Name", Path.GetFileName(filePath)))
                        {
                            fileModel = (MaterialFileModel)MaterialFileBO.Instance.FindByAttribute("Name", Path.GetFileName(filePath))[0];
                            isAdd = false;
                            fileModel.UpdatedDate = TextUtils.GetSystemDate();
                            fileModel.UpdatedBy = Global.AppUserName;
                        }
                        else
                        {
                            fileModel = new MaterialFileModel();
                            fileModel.CreatedDate = TextUtils.GetSystemDate();
                            fileModel.CreatedBy = Global.AppUserName;
                            fileModel.UpdatedDate = fileModel.CreatedDate;
                            fileModel.UpdatedBy = Global.AppUserName;
                        }

                        fileModel.Extension = Path.GetExtension(filePath);
                        fileModel.Datemodified = fInfo.LastWriteTime;
                        fileModel.Length = fInfo.Length;
                        fileModel.Name = Path.GetFileName(fInfo.FullName);
                        fileModel.Path = "Datasheet" + "/" + hang + "/" + Path.GetFileName(fInfo.FullName);
                        fileModel.IsDeleted = false;
                        fileModel.FileType = 1; //0 là file 3D cơ khí, 1 là datasheet
                        fileModel.CustormerID = cusID;

                        if (isAdd)
                        {
                            pt.Insert(fileModel);
                        }
                        else
                        {
                            pt.Update(fileModel);
                        }

                        if (!DocUtils.CheckExits("Datasheet" + "/" + hang))
                        {
                            DocUtils.MakeDir("Datasheet" + "/" + hang);
                        }
                        DocUtils.UploadFile(filePath, "Datasheet" + "/" + hang);
                        pt.CommitTransaction();
                        count++;
                    }
                    catch (Exception ex)
                    {
                    }
                    finally
                    {
                        pt.CloseConnection();
                    }
                }

                if (count > 0)
                {
                    loadGrid();
                }
            }
        }

        private void grvCustomer_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            loadGrid();
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            if (grvData.RowCount <= 0) return;
            foreach (int item in grvData.GetSelectedRows())
            {
                int materialFileID = TextUtils.ToInt(grvData.GetRowCellValue(item, colID));
                ListMaterialFileID.Add(materialFileID);
            }
            DialogResult = DialogResult.OK;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang xóa file..."))
            {
                if (grvData.RowCount <= 0) return;

                int materialFileID = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
                if (materialFileID == 0) return;

                string filePath = grvData.GetFocusedRowCellValue(colPath).ToString();
                string fileName = grvData.GetFocusedRowCellValue(colFileName).ToString();

                DataTable dt = TextUtils.Select("MaterialFileLink", new Expression("MaterialFileID", materialFileID));
                if (dt.Rows.Count >= 1)
                {
                    MessageBox.Show("File [" + fileName + "]" + " đã được đính kèm với nhiều vật tư.\n Bạn không thế xóa file này!", TextUtils.Caption, 
                        MessageBoxButtons.OK, MessageBoxIcon.Question);
                    return;
                }

                if (MessageBox.Show("Bạn có thật sự muốn xóa file [" + fileName + "] này không?", TextUtils.Caption,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
                
                ProcessTransaction pt = new ProcessTransaction();
                pt.OpenConnection();
                pt.BeginTransaction();
                try
                {
                    pt.Delete("MaterialFile", materialFileID);
                    pt.DeleteByAttribute("MaterialFileLink", "MaterialFileID", materialFileID.ToString());

                    DocUtils.DeleteFile(filePath);
                    pt.CommitTransaction();
                }
                catch (Exception)
                {

                }
                finally
                {
                    pt.CloseConnection();
                }
                loadGrid();
            }
        }

        private void grvData_DoubleClick(object sender, EventArgs e)
        {
            btnChoose_Click(null, null);
        }
    }
}