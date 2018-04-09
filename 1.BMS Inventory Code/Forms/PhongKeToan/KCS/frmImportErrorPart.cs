using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TPA.Model;
using TPA.Business;
using TPA.Utils;
using System.Collections;
using System.IO;
using DevExpress.XtraEditors;

namespace BMS
{
    public partial class frmImportErrorPart : _Forms
    {
        public int ProductImportType = 1;
        public decimal Qty = 0;
        public string PartsCode = "";
        public string DNNK = "";
        public int ImportStatus = 0;
        public ProductPartsImportModel ProductPartsImport = new ProductPartsImportModel();

        string _projectCode = "";
        int _moduleID = 0;

        public delegate void LoadDataChangeHandler(object sender, EventArgs e);
        public event LoadDataChangeHandler LoadDataChange;

        public frmImportErrorPart()
        {
            InitializeComponent();
        }

        public frmImportErrorPart(string projectCode, int moduleID)
        {
            InitializeComponent();

            _projectCode = projectCode;
            _moduleID = moduleID;
        }

        private void frmImportError_Load(object sender, EventArgs e)
        {
            this.Text += "- Vật tư: " + PartsCode + " - " + DNNK;

            //btnSave.Enabled = txtTotalNG.Enabled = txtTotalOK.Enabled = btnGenData.Enabled = (ImportStatus == 2);                  

            if (string.IsNullOrEmpty(ProductPartsImport.UserId))
            {
                txtCountError.EditValue = 1;
                cboLevelError.SelectedIndex = 0;
            }
            else
            {
                txtCountError.EditValue = TextUtils.ToInt(ProductPartsImport.CountError) == 0 ? 1 : TextUtils.ToInt(ProductPartsImport.CountError);
                cboLevelError.SelectedIndex = TextUtils.ToInt(ProductPartsImport.LevelError);
            }

            txtTotal.EditValue = ProductPartsImport.Total;
            txtTotalKCS.EditValue = ProductPartsImport.TotalKCS;
            txtTotalNoKCS.EditValue = ProductPartsImport.Total - ProductPartsImport.TotalKCS;
            txtTotalNG.EditValue = ProductPartsImport.TotalNG;
            txtTotalOK.EditValue = ProductPartsImport.TotalOK;

            btnSave.Enabled = txtTotalNG.Enabled = txtTotalOK.Enabled = btnGenData.Enabled = (ImportStatus == 2);

            loadGrid();
        }

        DataTable _dtTemplate = new DataTable();        

        void loadGrid()
        {
            string sql = string.Format("select *,case when Status = 1 then cast(1 as bit) else cast(0 as bit) end as Status1, N'Báo lỗi' as Error from CriteriaImport with(nolock) where ProductPartsImportId = '{0}' and CountError = {1} order by CriteriaIndex"
                , ProductPartsImport.ProductPartsImportId, TextUtils.ToInt(ProductPartsImport.CountError));
            //DataTable dt = LibQLSX.Select("select *,case when Status = 1 then cast(1 as bit) else cast(0 as bit) end as Status1, N'Báo lỗi' as Error from CriteriaImport with(nolock) where ProductPartsImportId = '" + ProductPartsImport.ProductPartsImportId + "'order by CriteriaIndex");
            DataTable dt = LibQLSX.Select(sql);
            _dtTemplate = dt.Clone();
            _dtTemplate.Rows.Clear();
            
            grdData.DataSource = dt;
        }

        void loadImge(string criteriaImportId)
        {
            DataTable dtImage = LibQLSX.Select("select * from CriteriaImportImage with(nolock) where CriteriaImportId = '" + criteriaImportId + "'");
            grdFile.DataSource = dtImage;
        }

        private void repositoryItemHyperLinkEdit1_DoubleClick(object sender, EventArgs e)
        {
            string des = TextUtils.ToString(grvData.GetFocusedRowCellValue(colValueResult));
            frmBCLError frm = new frmBCLError(des, _projectCode, _moduleID);
            frm.Show();
        }

        bool ValidateForm()
        {
            DataTable dt = (DataTable)grdData.DataSource;
            DataRow[] drs = dt.Select("ValueResult = '' or ValueResult is null");

            if (drs.Length > 0)
            {
                MessageBox.Show("Xin hãy điền nội dung kết quả kiểm tra.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            return true;
        }

        bool _isSaved = false;

        private void btnSave_Click(object sender, EventArgs e)
        {
            DataTable dtUserKCS = LibQLSX.Select("select top 1 * from Users where Account = '" + Global.AppUserName + "'");
            if (dtUserKCS.Rows.Count == 0)
            {
                MessageBox.Show("Tài khoản đăng nhập không có trên QLSX", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                //pt.CloseConnection();
                return;
            }

            decimal OK = 0;
            decimal NG = 0;

            //ProcessTransaction pt = new ProcessTransaction();
            //pt.OpenConnection();
            //pt.BeginTransaction();

            if (!ValidateForm())
            {
                //pt.CloseConnection();
                return;
            }
            grvData.FocusedRowHandle = -1;

            bool isDiffError = TextUtils.ToInt(ProductPartsImport.CountError) < TextUtils.ToInt(txtCountError.EditValue);

            if (!isDiffError)
            {
                //Xóa hết những nhật ký lỗi của vật tư khi KCS, trước khi lưu
                //CriteriaImportBO.Instance.DeleteByAttribute("ProductPartsImportId", ProductPartsImport.ProductPartsImportId);

                LibQLSX.ExcuteSQL(string.Format("delete CriteriaImport where ProductPartsImportId = '{0}' and CountError = {1}"
                    , ProductPartsImport.ProductPartsImportId, TextUtils.ToInt(ProductPartsImport.CountError)));
            }           

            try
            {
                for (int i = 0; i < grvData.RowCount; i++)
                {
                    string criteriaImportId = TextUtils.ToString(grvData.GetRowCellValue(i, colCriteriaImportId));

                    CriteriaImportModel model = new CriteriaImportModel();
                    //if (criteriaImportId != "")
                    //{
                    //    ArrayList arr = CriteriaImportBO.Instance.FindByAttribute("CriteriaImportId", criteriaImportId);
                    //    if (arr.Count > 0)
                    //    {
                    //        model = (CriteriaImportModel)arr[0];
                    //    }
                    //    else
                    //    {
                    //        criteriaImportId = "";
                    //    }                        
                    //}

                    model.CriteriaName = "Đúng thông số, kích thước kỹ thuật.";
                    model.ValueRequest = "Vật tư, thiết bị đảm bảo chất lượng.";
                    model.CriteriaIndex = TextUtils.ToInt(grvData.GetRowCellValue(i, colSTT));
                    model.IsHalf = TextUtils.ToBoolean(grvData.GetRowCellValue(i, colIsHalf));
                    model.ProductPartsImportId = ProductPartsImport.ProductPartsImportId;

                    bool status = TextUtils.ToBoolean(grvData.GetRowCellValue(i, colStatus));
                    model.Status = status ? 1 : 0;

                    model.ValueResult = TextUtils.ToString(grvData.GetRowCellValue(i, colValueResult));
                    model.CountError = TextUtils.ToInt(txtCountError.EditValue);

                    //if (criteriaImportId != "" && !isDiffError)
                    //{
                    //    CriteriaImportBO.Instance.UpdateQLSX(model);
                    //}
                    //else
                    //{
                        DataTable dt = LibQLSX.Select("SELECT top 1 CriteriaImportId FROM CriteriaImport order by CriteriaImportId desc");
                        if (dt.Rows.Count > 0)
                        {
                            criteriaImportId = TextUtils.ToString(dt.Rows[0]["CriteriaImportId"]);
                            string number = criteriaImportId.Substring(2, 8);
                            criteriaImportId = "CI" + string.Format("{0:00000000}", TextUtils.ToInt(number) + 1);
                        }
                        model.CriteriaImportId = criteriaImportId;
                        CriteriaImportBO.Instance.InsertQLSX(model);
                    //}
                    if (model.Status == 1)
                    {
                        OK++;
                    }
                    else
                    {
                        NG++;
                    }
                }                

                ProductPartsImport.UserId = TextUtils.ToString(dtUserKCS.Rows[0]["UserId"]);
                ProductPartsImport.TotalOK = TextUtils.ToDecimal(txtTotalOK.EditValue); // Qty % 1 == 0 ? OK : Qty;
                ProductPartsImport.TotalNG = TextUtils.ToDecimal(txtTotalNG.EditValue); //Qty % 1 == 0 ? NG : Qty; //NG;
                ProductPartsImport.TotalKCS = TextUtils.ToDecimal(txtTotalKCS.EditValue);
                
                ProductPartsImport.LevelError = cboLevelError.SelectedIndex;
                ProductPartsImport.CountError = TextUtils.ToInt(txtCountError.EditValue);

                ProductPartsImportBO.Instance.UpdateQLSX(ProductPartsImport);

                //pt.CommitTransaction();

                loadGrid();

                _isSaved = true;

                MessageBox.Show("Tác vụ thành công!", TextUtils.Caption,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tác vụ không thành công!" + Environment.NewLine + ex.Message, TextUtils.Caption,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //pt.CloseConnection();
            }

            if (_isSaved)
            {
                if (this.LoadDataChange != null)
                {
                    this.LoadDataChange(null, null);
                }
            }
        }

        private void btnAddFile_Click(object sender, EventArgs e)
        {
            //KcsError
            string criteriaImportId = TextUtils.ToString(grvData.GetFocusedRowCellValue(colCriteriaImportId));
            //string orderCode = TextUtils.ToString(grvOrder.GetFocusedRowCellValue(colSoDonHang));

            if (criteriaImportId == "") return;

            DocUtils.InitFTPTK();

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                foreach (string filePath in ofd.FileNames)
                {
                    FileInfo fInfo = new FileInfo(filePath);

                    ProcessTransaction pt = new ProcessTransaction();
                    pt.OpenConnection();
                    pt.BeginTransaction();

                    try
                    {
                        CriteriaImportImageModel model = new CriteriaImportImageModel();
                        model.CriteriaImportId = criteriaImportId;
                        model.FileName = fInfo.Name;
                        //model.FileLocalPath = fInfo.FullName;
                        model.FilePath = "KcsError\\" + criteriaImportId + "\\" + fInfo.Name;
                        model.Size = fInfo.Length;
                        model.DateCreated = TextUtils.GetSystemDate();
                        pt.Insert(model);
                        if (!DocUtils.CheckExits("KcsError\\" + criteriaImportId + "\\"))
                        {
                            DocUtils.MakeDir("KcsError\\" + criteriaImportId + "\\");
                        }
                        bool status = DocUtils.UploadFileWithStatus(filePath, "KcsError\\" + criteriaImportId);
                        if (status)
                            pt.CommitTransaction();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        pt.CloseConnection();
                    }                   
                }

                loadImge(criteriaImportId);
            }
        }

        private void btnDeleteFile_Click(object sender, EventArgs e)
        {
            if (grvFile.SelectedRowsCount > 0)
            {
                int id = TextUtils.ToInt(grvFile.GetFocusedRowCellValue(colFileID));
                string ftpFilePath = TextUtils.ToString(grvFile.GetFocusedRowCellValue(colFilePath));
                if (id == 0) return;
                DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa file này?", TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    DocUtils.InitFTPTK();
                    OrdersFileBO.Instance.Delete(id);
                    if (DocUtils.CheckExits(ftpFilePath))
                    {
                        DocUtils.DeleteFile(ftpFilePath);
                    }
                    grvFile.DeleteSelectedRows();
                }
            }
        }

        private void grvData_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            string criteriaImportId = TextUtils.ToString(grvData.GetFocusedRowCellValue(colCriteriaImportId));
            loadImge(criteriaImportId);
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked)
            {
                for (int i = 0; i < grvData.RowCount; i++)
                {
                    grvData.SetRowCellValue(i, colStatus, true);
                }
            }
            else
            {
                for (int i = 0; i < grvData.RowCount; i++)
                {
                    grvData.SetRowCellValue(i, colStatus, false);
                }
            }
        }

        private void grvFile_DoubleClick(object sender, EventArgs e)
        {

        }

        private void btnSET_Click(object sender, EventArgs e)
        {
            //if (TextUtils.ToInt(txtTotalNG.EditValue)<0)
            //{
            //    MessageBox.Show("Bạn đang nhập sai giá trị.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    return;
            //}

            DialogResult result = MessageBox.Show("Bạn có muốn reset lại thông tin?", TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No) return;
            frmImportError_Load(null, null);

        }      

        void getTotal()
        {
            grvData.FocusedRowHandle = -1;
            txtTotalKCS.EditValue = grvData.RowCount;

            txtTotalNoKCS.EditValue = TextUtils.ToInt(txtTotal.EditValue) - TextUtils.ToInt(txtTotalKCS.EditValue);

            DataTable dt = (DataTable)grdData.DataSource;

            txtTotalOK.EditValue = dt.Select("Status1 = 1").Length;

            txtTotalNG.EditValue = dt.Select("Status1 = 0").Length;
        }

        List<string> lstID = new List<string>();
        private void btnDelete_Click(object sender, EventArgs e)
        {
            //foreach (var i in grvData.GetSelectedRows())
            //{
            //    lstID.Add(TextUtils.ToString(grvData.GetRowCellValue(i, colCriteriaImportId)));
            //}

            //grvData.DeleteSelectedRows();
            
            //getTotal();            
        }

        private void repositoryItemCheckEdit1_CheckedChanged(object sender, EventArgs e)
        {
           // CheckEdit chk = (CheckEdit)sender;
           //// bool status = TextUtils.ToBoolean(grvData.GetFocusedRowCellValue(colStatus));
           // if (chk.Checked)
           // {
           //     txtTotalOK.EditValue = TextUtils.ToInt(txtTotalOK.EditValue) + 1;
           //     txtTotalNG.EditValue = TextUtils.ToInt(txtTotalNG.EditValue) - 1;
           // }
           // else
           // {
           //     txtTotalOK.EditValue = TextUtils.ToInt(txtTotalOK.EditValue) - 1;
           //     txtTotalNG.EditValue = TextUtils.ToInt(txtTotalNG.EditValue) + 1;
           // }
        }

        private void btnGenData_Click(object sender, EventArgs e)
        {
            _dtTemplate.Rows.Clear();

            int qtyOK = TextUtils.ToInt(txtTotalOK.EditValue);
            int qtyNG = TextUtils.ToInt(txtTotalNG.EditValue);

            int total = TextUtils.ToInt(txtTotal.EditValue);

            int qtyKCS = (qtyNG + qtyOK);

            if (qtyKCS > total)
            {
                MessageBox.Show("Tổng số lượng NG + Tổng số lượng OK > Tổng số lượng");
                return;
            }

            txtTotalKCS.EditValue = qtyKCS;

            txtTotalNoKCS.EditValue = total - qtyKCS;
            int index = 1;
            for (int i = 1; i <= qtyNG; i++)
            {
                DataRow row = _dtTemplate.NewRow();
                row["CriteriaIndex"] = index++;
                row["ValueResult"] = "Lỗi";
                row["ProductPartsImportId"] = ProductPartsImport.ProductPartsImportId;
                row["CriteriaImportId"] = "";
                row["Status"] = 0;
                row["Status1"] = false;
                row["IsHalf"] = false;
                row["Error"] = "Báo lỗi";
                _dtTemplate.Rows.Add(row);
            }

            for (int i = 1; i <= qtyOK; i++)
            {
                DataRow row = _dtTemplate.NewRow();
                row["CriteriaIndex"] = index++;
                row["ValueResult"] = "ok";
                row["ProductPartsImportId"] = ProductPartsImport.ProductPartsImportId;
                row["CriteriaImportId"] = "";
                row["Status"] = 1;
                row["Status1"] = true;
                row["IsHalf"] = false;
                row["Error"] = "Báo lỗi";
                _dtTemplate.Rows.Add(row);
            }            

            grdData.DataSource = null;
            grdData.DataSource = _dtTemplate;           
        }
    }
}
