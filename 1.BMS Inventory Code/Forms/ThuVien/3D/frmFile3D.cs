using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BMS.Model;
using BMS.Utils;
using BMS.Business;
using System.IO;

namespace BMS
{
    public partial class frmFile3D : _Forms
    {        
        #region Variables
        string _dPath ="";
        public int CatID=0;
        List<File3DModel> _listFileModel = new List<File3DModel>();
        ProductGroupModel _gModel;
        #endregion

        public frmFile3D()
        {
            InitializeComponent();            
        }

        private void frmFile3D_Load(object sender, EventArgs e)
        {
            cboParent.Enabled = false;
            loadCombo(CatID);
            cboParent.SelectedValue = CatID;
            _gModel = ((ProductGroupModel)ProductGroupBO.Instance.FindByPK(CatID));
            if (_gModel!=null)
            {
                _dPath = _gModel.Path;
            }
        }

        void loadCombo(int id = 0)
        {
            DataTable tbl = TextUtils.Select(@"SELECT ID, Name FROM ProductGroup WITH(NOLOCK) where ID = " + id + " ORDER BY Name");
            if (tbl == null)
            {
                return;
            }
            TextUtils.PopulateCombo(cboParent, tbl.Copy(), "Name", "ID", "-- CẤP LỚN NHẤT --");
        }

        void loadGrid()
        {
            grdData.DataSource = null;
            grdData.DataSource = _listFileModel;
            grvData.BestFitColumns();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ProcessTransaction pt = new ProcessTransaction();
            pt.OpenConnection();
            pt.BeginTransaction();

            progressBar1.Visible = true;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = grvData.RowCount;
            progressBar1.Value = 0;

            for (int i = 0; i < grvData.RowCount; i++)
            {
                try
                {
                    string filePath = Path.Combine(_dPath, grvData.GetRowCellValue(i, colName).ToString());

                    if (filePath != grvData.GetRowCellValue(i, colPath).ToString())
                    {
                        FileInfo fi = new FileInfo(filePath);
                       
                        if (File.Exists(filePath))
                        {
                            DialogResult result = MessageBox.Show("Đã tồn tại file: [" + grvData.GetRowCellValue(i, colName).ToString() + "] trên thư viện."
                                + Environment.NewLine + "Bạn có muốn upload file không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            if (result == DialogResult.Yes)
                            {
                                //Tạo một folder chứa file cũ
                                string folderPath = Path.GetDirectoryName(filePath) + @"\" + DateTime.Now.ToString("dd-MM-yyyy");
                                Directory.CreateDirectory(folderPath);
                                File.Copy(filePath, folderPath + @"\" + fi.Name, true);
                                File.Delete(filePath);
                                File.Copy(grvData.GetRowCellValue(i, colPath).ToString(), filePath, true); 
                            }
                        }
                        else
                        {
                            File.Copy(grvData.GetRowCellValue(i, colPath).ToString(), Path.Combine(_dPath, grvData.GetRowCellValue(i, colName).ToString()));
                        }
                    }

                    //Kiểm tra đã có trong cơ sở dữ liệu hay chưa
                    ArrayList listFile = new ArrayList();
                    try
                    {
                        listFile = File3DBO.Instance.FindByExpression(new Expression("Name", Path.GetFileName(filePath))
                           .And(new Expression("ProductGroupID", _gModel.ID)));
                    }
                    catch (Exception)
                    {                       
                    }

                    if (listFile.Count==0)
                    {
                        File3DModel model = new File3DModel();
                        model.Datemodified = TextUtils.ToDate(grvData.GetRowCellValue(i, colDatemodified).ToString());
                        model.Length = TextUtils.ToDecimal(grvData.GetRowCellValue(i, colLength));
                        model.Name = Path.GetFileName(grvData.GetRowCellValue(i, colPath).ToString());
                        model.ProductGroupID = CatID;
                        model.Path = @"" + filePath;
                        pt.Insert(model);
                    }
                    else
                    {
                        File3DModel model1 = (File3DModel)listFile[0];
                        model1.Length = TextUtils.ToDecimal(grvData.GetRowCellValue(i, colLength));
                        model1.Datemodified = TextUtils.ToDate(grvData.GetRowCellValue(i, colDatemodified).ToString());
                        pt.Update(model1);
                    }                                    
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message,"Lỗi");
                    continue;
                }
                progressBar1.Value += i;
            }

            progressBar1.Visible = false;

            pt.CommitTransaction();
            pt.CloseConnection();
            MessageBox.Show("Lưu trữ thành công.", "Thông báo");
            DialogResult = DialogResult.OK;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnChooseFile_Click(object sender, EventArgs e)
        {
            if (cboParent.Text == "Datasheet")
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "File pdf|*.pdf|All File|*.*";
                ofd.Multiselect = true;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    foreach (string item in ofd.FileNames)
                    {
                        FileInfo fInfo = new FileInfo(item);
                        File3DModel model = new File3DModel();
                        model.Datemodified = fInfo.LastWriteTime;
                        model.Length = fInfo.Length;
                        model.Name = Path.GetFileName(fInfo.FullName);
                        model.Path = fInfo.FullName;
                        model.ProductGroupID = TextUtils.ToInt(cboParent.SelectedValue);
                        _listFileModel.Add(model);
                    }
                }
            }
            else
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "File .ipt|*ipt|All File|*.*";
                ofd.Multiselect = false;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    if (cboParent.Text != Path.GetFileNameWithoutExtension(ofd.FileName))
                    {
                        MessageBox.Show("Tên của file phải giống tên sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    FileInfo fInfo = new FileInfo(ofd.FileName);
                    File3DModel model = new File3DModel();
                    model.Datemodified = fInfo.LastWriteTime;
                    model.Length = fInfo.Length;
                    model.Name = Path.GetFileName(fInfo.FullName);
                    model.Path = fInfo.FullName;
                    model.ProductGroupID = TextUtils.ToInt(cboParent.SelectedValue);
                    _listFileModel.Add(model);
                }
            }
            loadGrid();
        }       

        private void btnDelFile_Click(object sender, EventArgs e)
        {
            if (grvData.FocusedRowHandle < 0) return;
            _listFileModel.RemoveAt(grvData.FocusedRowHandle);
            loadGrid();
        }
      
    }
}
