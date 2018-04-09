using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BMS.Model;
using BMS.Utils;
using DevExpress.XtraGrid.Localization;
using BMS.Business;
using DevExpress.XtraGrid.Views.Grid;
using System.IO;
using DevExpress.Utils;
using System.Diagnostics;
using System.Collections;

namespace BMS
{
    public partial class frmBaiTHDetail : _Forms
    {
        public BaiThucHanhModel BaiThucHanh = new BaiThucHanhModel();
        bool _isSaved = false;
        public int GroupID = 0;

        DataTable dtModule = new DataTable();
        DataTable dtMaterial = new DataTable();
        DataTable dtFile = new DataTable();

        public bool IsShowVersion = false;
        public int Version = 0;

        public frmBaiTHDetail()
        {
            InitializeComponent();

            //dtModule.Columns.Add("ID");
            //dtModule.Columns.Add("Code");
            //dtModule.Columns.Add("Name");
            //dtModule.Columns.Add("Error");
            //dtModule.Columns.Add("KPH");
            //dtModule.Columns.Add("Hang");
            //dtModule.Columns.Add("Qty");
            //dtModule.Columns.Add("CodeHD");
            //dtModule.Columns.Add("NameHD");
            //dtModule.Columns.Add("Status");
            //dtModule.Columns.Add("CVersion");
            //dtModule.Columns.Add("NVersion");

            //dtMaterial.Columns.Add("ID");
            //dtMaterial.Columns.Add("Code");
            //dtMaterial.Columns.Add("Name");
            //dtMaterial.Columns.Add("Error");
            //dtMaterial.Columns.Add("KPH");
            //dtMaterial.Columns.Add("Hang");
            //dtMaterial.Columns.Add("Qty");
            //dtMaterial.Columns.Add("Status");
            //dtMaterial.Columns.Add("TonKho");
            //dtMaterial.Columns.Add("CVersion");
            //dtMaterial.Columns.Add("NVersion");
        }

        private void frmBaiTHDetail_Load(object sender, EventArgs e)
        {
            GridLocalizer.Active = new MyGridLocalizer();
            loadGroup();
            btnModuleHistory.Visible = false;

            DocUtils.InitFTPTK();

            loadGridModule();
            loadGridMaterial();
            loadGridFile();

            if (BaiThucHanh.ID != 0)
            {
                txtName.Text = BaiThucHanh.Name;
                txtCode.Text = BaiThucHanh.Code;
                txtDescription.Text = BaiThucHanh.Description;               
                cboGroup.EditValue = BaiThucHanh.GroupID;

                txtVersion.Text = BaiThucHanh.Version.ToString();
                txtTime.Text = BaiThucHanh.Time.ToString();

                txtRealPrice.Text = BaiThucHanh.RealPrice.ToString("n2");
                txtTradePrice.Text = BaiThucHanh.TradePrice.ToString("n2");
                txtUserPrice.Text = BaiThucHanh.UserPrice.ToString("n2");

                this.Text = this.Text + ": " + BaiThucHanh.Code + "-" + BaiThucHanh.Name;

                if (IsShowVersion)
                {
                    txtVersion.Text = Version.ToString();
                    btnSave.Enabled = btnSaveAndClose.Enabled = false;
                    toolStripFile.Enabled = toolStripModule.Enabled = toolStripVatTuPhu.Enabled = false;
                }
            }
            else
            {
                cboGroup.EditValue = GroupID;
                txtVersion.Text = "0";
            }           
        }

        void loadGridFile()
        {
            if (IsShowVersion)
            {
                dtFile = TextUtils.Select("select * from BaiThucHanhFile with(nolock) where BaiThucHanhID = " + BaiThucHanh.ID 
                    + " and Version = " + Version);
            }
            else
            {
                dtFile = TextUtils.Select("select * from BaiThucHanhFile with(nolock) where BaiThucHanhID =" + BaiThucHanh.ID 
                    + " and Version = " + BaiThucHanh.Version);
            }
            grdFile.DataSource = dtFile;
        }

        DataTable dtResult(int type)
        {
            if (IsShowVersion)
            {
                return TextUtils.Select("Select * from vBaiThucHanhModuleVersion with(nolock) where Type = " + type
                    + " and BaiThucHanhID = " + BaiThucHanh.ID
                    + " and Version = " + Version);
            }
            else
            {
                return TextUtils.Select("Select * from vBaiThucHanhModule with(nolock) where Type = " + type + " and BaiThucHanhID = " + BaiThucHanh.ID);
            }            
        }

        void loadGridModule()
        {
            dtModule = dtResult(0);
            grdModule.DataSource = dtModule;
        }

        void loadGridMaterial()
        {
            dtMaterial = dtResult(1);
            grdVT.DataSource = dtMaterial;
        }

        void loadGroup()
        {
            DataTable tbl = TextUtils.Select(@"SELECT ID, Code, Code+'-'+Name as Name FROM BaiThucHanhGroup WITH(NOLOCK) ORDER BY Code");
            if (tbl == null)
            {
                return;
            }
            TextUtils.PopulateCombo(cboGroup, tbl.Copy(), "Name", "ID", "");
        }

        bool ValidateForm()
        {
            if (txtCode.Text.Trim() == "")
            {
                MessageBox.Show("Xin hãy điền Mã.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            else
            {
                DataTable dt;
                if (BaiThucHanh.ID > 0)
                {
                    dt = TextUtils.Select("select Code from BaiThucHanh where Code = '" + txtCode.Text.Trim() + "' and ID <> " + BaiThucHanh.ID);
                }
                else
                {
                    dt = TextUtils.Select("select Code from BaiThucHanh where Code = '" + txtCode.Text.Trim() + "'");
                }
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        MessageBox.Show("Mã này đã tồn tại!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return false;
                    }
                }            
            }

            if (txtCode.Text.ToUpper().Trim().Substring(0, 3) != cboGroup.Text.ToUpper().Substring(0, 3))
            {
                MessageBox.Show("Mã không đúng định dạng.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (txtName.Text.Trim() == "")
            {
                MessageBox.Show("Xin hãy điền Tên.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (TextUtils.ToInt(cboGroup.EditValue)==0)
            {
                MessageBox.Show("Xin hãy chọn nhóm.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (txtTime.Text.Trim() == "")
            {
                MessageBox.Show("Xin hãy điền thời gian học.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            
            return true;
        }

        void CreateVersion(BaiThucHanhModel BaiThucHanh)
        {
            ProcessTransaction pt = new ProcessTransaction();
            pt.OpenConnection();
            pt.BeginTransaction();

            try
            {
                // Tạo phiên bản bài thực hành
                BaiThucHanhVersionModel versionModel = new BaiThucHanhVersionModel();
                versionModel.BaiThucHanhID = BaiThucHanh.ID;
                versionModel.Reason = "Tạo phiên bản đầu tiên";
                versionModel.Version = BaiThucHanh.Version;
                versionModel.ID = (int)pt.Insert(versionModel);

                //Tạo các phiên bản module bài thực hành
                ArrayList lisModules = BaiThucHanhModuleBO.Instance.FindByAttribute("BaiThucHanhID", BaiThucHanh.ID);
                if (lisModules.Count > 0)
                {
                    foreach (var item in lisModules)
                    {
                        BaiThucHanhModuleModel thisModule = (BaiThucHanhModuleModel)item;

                        BaiThucHanhModuleVersionModel moduleVersion = new BaiThucHanhModuleVersionModel();
                        moduleVersion.BTHVersionID = versionModel.ID;
                        moduleVersion.Code = thisModule.Code;
                        moduleVersion.CVersion = thisModule.CVersion;
                        moduleVersion.Hang = thisModule.Hang;
                        moduleVersion.Name = thisModule.Name;
                        moduleVersion.Qty = thisModule.Qty;
                        moduleVersion.Type = thisModule.Type;
                        moduleVersion.ID = (int)pt.Insert(moduleVersion);
                    }
                }

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

        void CreateVersion(BaiThucHanhModel BaiThucHanh, string reason)
        {
            ProcessTransaction pt = new ProcessTransaction();
            pt.OpenConnection();
            pt.BeginTransaction();

            try
            {
                #region Tạo phiên bản bài thực hành
                BaiThucHanhVersionModel versionModel = new BaiThucHanhVersionModel();
                versionModel.BaiThucHanhID = BaiThucHanh.ID;
                versionModel.Reason = reason;
                versionModel.Version = BaiThucHanh.Version + 1;
                versionModel.ID = (int)pt.Insert(versionModel);
                #endregion

                #region Tạo các phiên bản module bài thực hành
                ArrayList lisModules = BaiThucHanhModuleBO.Instance.FindByAttribute("BaiThucHanhID", BaiThucHanh.ID);
                if (lisModules.Count > 0)
                {
                    foreach (var item in lisModules)
                    {
                        BaiThucHanhModuleModel thisModule = (BaiThucHanhModuleModel)item;

                        BaiThucHanhModuleVersionModel moduleVersion = new BaiThucHanhModuleVersionModel();
                        moduleVersion.BTHVersionID = versionModel.ID;
                        moduleVersion.Code = thisModule.Code;
                        moduleVersion.CVersion = thisModule.CVersion;
                        moduleVersion.Hang = thisModule.Hang;
                        moduleVersion.Name = thisModule.Name;
                        moduleVersion.Qty = thisModule.Qty;
                        moduleVersion.Type = thisModule.Type;
                        moduleVersion.ID = (int)pt.Insert(moduleVersion);
                    }
                }
                #endregion

                #region Tạo phiên bản các file
                List<string> listFilePath = new List<string>();
                ArrayList listFiles = BaiThucHanhFileBO.Instance.FindByExpression(new Expression("BaiThucHanhID", BaiThucHanh.ID)
                    .And(new Expression("Version", BaiThucHanh.Version)));

                string ftpFolderPath = "BieuMau\\BaiThucHanh\\" + BaiThucHanh.Code + "\\" + versionModel.Version;
                if (!DocUtils.CheckExits(Path.GetDirectoryName(ftpFolderPath)))
                {
                    DocUtils.MakeDir(Path.GetDirectoryName(ftpFolderPath));
                }
                foreach (var item in listFiles)
                {
                    BaiThucHanhFileModel thisFile = (BaiThucHanhFileModel)item;
                    string path = Path.GetTempPath();

                    DocUtils.DownloadFile(path, Path.GetFileName(thisFile.Path), thisFile.Path);

                    BaiThucHanhFileModel file = new BaiThucHanhFileModel();
                    file.BaiThucHanhID = BaiThucHanh.ID;
                    file.Name = thisFile.Name;
                    file.Length = thisFile.Length;
                    file.LocalPath = path + "\\" + Path.GetFileName(thisFile.Path);
                    file.Path = ftpFolderPath + "\\" + file.Name;
                    file.Version = versionModel.Version;

                    pt.Insert(file);

                    listFilePath.Add(path + "\\" + Path.GetFileName(thisFile.Path));
                }
                #endregion

                BaiThucHanh.Version += 1;
                pt.Update(BaiThucHanh);

                pt.CommitTransaction();

                foreach (string filePath in listFilePath)
                {
                    if (!DocUtils.CheckExits(ftpFolderPath))
                    {
                        DocUtils.MakeDir(ftpFolderPath);
                    }
                    DocUtils.UploadFile(filePath, ftpFolderPath);
                }

                MessageBox.Show("Tạo phiên bản bài thực hành thành công!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        void save(bool close)
        {
            bool isAdd = false;
            ProcessTransaction pt = new ProcessTransaction();
            pt.OpenConnection();
            pt.BeginTransaction();

            try
            {
                if (!ValidateForm())
                    return;

                BaiThucHanh.GroupID = TextUtils.ToInt(cboGroup.EditValue);

                BaiThucHanh.Name = txtName.Text.Trim().ToUpper();
                BaiThucHanh.Code = txtCode.Text.Trim().ToUpper();
                BaiThucHanh.Description = txtDescription.Text.Trim();                
                
                BaiThucHanh.Time = TextUtils.ToDecimal(txtTime.Text.Trim());

                BaiThucHanh.RealPrice = TextUtils.ToDecimal(txtRealPrice.Text.Trim());
                BaiThucHanh.TradePrice = TextUtils.ToDecimal(txtTradePrice.Text.Trim());
                BaiThucHanh.UserPrice = TextUtils.ToDecimal(txtUserPrice.Text.Trim());

                if (BaiThucHanh.ID == 0)
                {
                    isAdd = true;
                    BaiThucHanh.Version = 0;
                    BaiThucHanh.ID = (int)pt.Insert(BaiThucHanh);
                }
                else
                {
                    DialogResult result = MessageBox.Show("Bạn có muốn tạo phiên bản cho bài thực hành này trước khi ghi?", TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        string reason = "";
                        frmVersionReason frm = new frmVersionReason();
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            reason = frm.Reason;
                            CreateVersion(BaiThucHanh, reason);
                        }
                    }
                    pt.Update(BaiThucHanh);
                }

                #region Module chính
                for (int i = 0; i < grvModule.RowCount; i++)
                {
                    int id = TextUtils.ToInt(grvModule.GetRowCellValue(i, colMID));
                    BaiThucHanhModuleModel link;
                    if (id == 0)
                    {
                        link = new BaiThucHanhModuleModel();                        
                    }
                    else
                    {
                        link = (BaiThucHanhModuleModel)BaiThucHanhModuleBO.Instance.FindByPK(id);
                    }

                    link.BaiThucHanhID = BaiThucHanh.ID;
                    link.Hang = grvModule.GetRowCellValue(i, colMHang).ToString();
                    link.Code = grvModule.GetRowCellValue(i, colMCode).ToString();
                    link.Name = grvModule.GetRowCellValue(i, colMName).ToString();
                    link.Qty = TextUtils.ToInt(grvModule.GetRowCellValue(i, colMQty));
                    link.Type = 0;
                    link.CVersion = TextUtils.ToInt(grvModule.GetRowCellValue(i, colMCVersion));

                    if (id == 0)
                    {
                        link.ID = (int)pt.Insert(link);                        
                    }
                    else
                    {
                        pt.Update(link);
                    }                    
                }
                #endregion

                #region Vật tư phụ
                for (int i = 0; i < grvVT.RowCount; i++)
                {
                    int id = TextUtils.ToInt(grvVT.GetRowCellValue(i, colMaID));
                    BaiThucHanhModuleModel link;
                    if (id == 0)
                    {
                        link = new BaiThucHanhModuleModel();
                    }
                    else
                    {
                        link = (BaiThucHanhModuleModel)BaiThucHanhModuleBO.Instance.FindByPK(id);
                    }

                    link.BaiThucHanhID = BaiThucHanh.ID;
                    link.Hang = grvVT.GetRowCellValue(i, colMaHang).ToString();
                    link.Code = grvVT.GetRowCellValue(i, colMaCode).ToString();
                    link.Name = grvVT.GetRowCellValue(i, colMaName).ToString();
                    link.Qty = TextUtils.ToInt(grvVT.GetRowCellValue(i, colMaQty));
                    link.Type = 1;
                    link.CVersion = TextUtils.ToInt(grvVT.GetRowCellValue(i, colMaCVersion));

                    if (id == 0)
                    {
                        pt.Insert(link);
                    }
                    else
                    {
                        pt.Update(link);
                    }
                }
                #endregion

                #region File
                string ftpFolderPath = "BieuMau\\BaiThucHanh\\" + BaiThucHanh.Code + "\\" + BaiThucHanh.Version;
                if (!DocUtils.CheckExits(Path.GetDirectoryName(ftpFolderPath)))
                {
                    DocUtils.MakeDir(Path.GetDirectoryName(ftpFolderPath));
                }
                List<string> listFilePath = new List<string>();
                for (int i = 0; i < grvFile.RowCount; i++)
                {
                    int id = TextUtils.ToInt(grvFile.GetRowCellValue(i, colFileID));                    
                    if (id == 0)
                    {
                        BaiThucHanhFileModel file = new BaiThucHanhFileModel();
                        file.BaiThucHanhID = BaiThucHanh.ID;
                        file.Name = grvFile.GetRowCellValue(i, colFileName).ToString();
                        file.Length = TextUtils.ToDecimal(grvFile.GetRowCellValue(i, colFileSize).ToString());
                        file.LocalPath = grvFile.GetRowCellValue(i, colFileLocalPath).ToString();
                        file.Path = ftpFolderPath + "\\" + Path.GetFileName(file.LocalPath);
                        file.Version = BaiThucHanh.Version;

                        pt.Insert(file);

                        listFilePath.Add(file.LocalPath);                       
                    }
                }
                #endregion
                
                pt.CommitTransaction();

                if (listFilePath.Count > 0)
                {
                    foreach (string filePath in listFilePath)
                    {
                        if (!DocUtils.CheckExits(ftpFolderPath))
                        {
                            DocUtils.MakeDir(ftpFolderPath);
                        }
                        DocUtils.UploadFile(filePath, ftpFolderPath);
                    }
                }

                //if (isAdd)
                //{
                //    CreateVersion(BaiThucHanh);
                //}

                _isSaved = true;
                if (close)
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    loadGridMaterial();
                    loadGridModule();
                    loadGridFile();
                    MessageBox.Show("Lưu trữ thành công!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            save(false);
        }

        private void btnSaveAndClose_Click(object sender, EventArgs e)
        {
            save(true);
        }

        private void frmBaiTHDetail_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_isSaved)
            {
                DialogResult = DialogResult.OK;
            }
        }

        private void cboGroup_EditValueChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    txtCode.Text = grvGroup.GetFocusedRowCellValue(colGroupCode).ToString();
            //}
            //catch (Exception)
            //{
            //}           
        }

        private void btnAddModule_Click(object sender, EventArgs e)
        {
            frmListModules frm = new frmListModules();            
            if (frm.ShowDialog() == DialogResult.OK)
            {
                foreach (DataRow row in frm.dtSeleted.Rows)
                {
                    DataRow[] rows = dtModule.Select("Code = '" + row["Code"].ToString() + "'");
                    if (rows.Count() > 0) continue;

                    DataRow dr = dtModule.NewRow();
                    dr["ID"] = 0;
                    dr["BaiThucHanhID"] = BaiThucHanh.ID;
                    dr["Code"] = row["Code"].ToString();
                    dr["Name"] = row["Name"].ToString();
                    dr["Qty"] = 1;
                    dr["Hang"] = row["Hang"].ToString();
                    dr["Type"] = 0;
                    dr["CVersion"] = row["CVersion"].ToString();
                    dr["NVersion"] = row["NVersion"].ToString();
                    dtModule.Rows.Add(dr);
                }
                
                grdModule.DataSource = dtModule;
            }
        }

        private void btnDeleteModule_Click(object sender, EventArgs e)
        {
            int iD = TextUtils.ToInt(grvModule.GetFocusedRowCellValue(colMID));
            string moduleCode = grvModule.GetFocusedRowCellValue(colMCode).ToString();
            if (MessageBox.Show("Bạn có chắc muốn xóa module này không?", TextUtils.Caption,
            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    if (iD > 0)
                    {
                        BaiThucHanhModuleBO.Instance.Delete(iD);
                        //DataTable dt = TextUtils.Select("select * from ProductModuleLink with(nolock) where BaiThucHanhID = " + BaiThucHanh.ID + " and ModuleCode ='" + moduleCode + "'");
                        //if (dt.Rows.Count > 0)
                        //{
                        //    foreach (DataRow item in dt.Rows)
                        //    {
                        //        int linkID = TextUtils.ToInt(item["ID"]);
                        //        ProductModuleLinkBO.Instance.Delete(linkID);
                        //    }
                        //}                       
                    }
                    grvModule.DeleteRow(grvModule.FocusedRowHandle);
                }
                catch
                {
                    MessageBox.Show("Có lỗi xảy ra khi thực hiện thao tác, xin vui lòng thử lại sau.");
                }
            }
        }

        private void btnAddVT_Click(object sender, EventArgs e)
        {
            frmListMaterial frm = new frmListMaterial();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                foreach (DataRow row in frm.dtAll.Rows)
                {
                    DataRow[] rows = dtMaterial.Select("Code = '" + row["Code"].ToString() + "'");
                    if (rows.Count() > 0) continue;

                    DataRow dr = dtMaterial.NewRow();
                    dr["ID"] = 0;
                    dr["BaiThucHanhID"] = BaiThucHanh.ID;
                    dr["Code"] = row["Code"].ToString();
                    dr["Name"] = row["Name"].ToString();
                    dr["Qty"] = 1;
                    dr["Hang"] = row["Hang"].ToString();
                    dr["Type"] = 1;
                    //if (row["Code"].ToString().StartsWith("TPAD"))
                    //{
                    //    DataTable dt = TextUtils.Select("SELECT ISNULL(MAX(Version), 0) FROM dbo.ModuleVersion WHERE (ModuleCode = '" + row["Code"].ToString() + "')");
                    //    dr["CVersion"] = dt.Rows.Count > 0 ? dt.Rows[0][0].ToString() : "0";
                    //    dr["NVersion"] = dr["CVersion"];
                    //}
                    //else
                    //{
                    //    dr["CVersion"] = "0";
                    //    dr["NVersion"] = "0";
                    //}
                    dr["CVersion"] = row["CVersion"].ToString();
                    dr["NVersion"] = row["NVersion"].ToString();
                    dtMaterial.Rows.Add(dr);
                    
                    //dtMaterial.Rows.Add(0, BaiThucHanh.ID, row["Code"].ToString(), row["Name"].ToString(), 1, row["Hang"].ToString(), 1);
                }

                grdVT.DataSource = dtMaterial;
            }
        }

        private void btnDeleteVT_Click(object sender, EventArgs e)
        {
            int iD = TextUtils.ToInt(grvVT.GetFocusedRowCellValue(colMaID));
            if (MessageBox.Show("Bạn có chắc muốn xóa module này không?", TextUtils.Caption,
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    if (iD > 0)
                    {
                        BaiThucHanhModuleBO.Instance.Delete(iD);
                    }
                    grvVT.DeleteRow(grvVT.FocusedRowHandle);
                }
                catch
                {
                    MessageBox.Show("Có lỗi xảy ra khi thực hiện thao tác, xin vui lòng thử lại sau.");
                }                
            }
        }

        private void grvModule_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.RowHandle < 0) return;
            GridView View = sender as GridView;
            int id = TextUtils.ToInt(View.GetRowCellValue(e.RowHandle, colMID));

            if (id == 0)
            {
                e.Appearance.BackColor = Color.Yellow;
            }
        }

        private void grvVT_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.RowHandle < 0) return;
            GridView View = sender as GridView;
            int id = TextUtils.ToInt(View.GetRowCellValue(e.RowHandle, colMaID));

            if (id == 0)
            {
                e.Appearance.BackColor = Color.Yellow;
            }
        }

        private void btnAddFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                foreach (string filePath in ofd.FileNames)
                {
                    FileInfo fInfo = new FileInfo(filePath);
                    DataRow[] rows = dtFile.Select("Name = '" + fInfo.Name + "'");
                    if (rows.Count() > 0) continue;
                    dtFile.Rows.Add(0, 0, fInfo.Name, fInfo.Length, "", fInfo.FullName);
                    grdFile.DataSource = dtFile;
                }
            }
        }

        private void btnDeleteFile_Click(object sender, EventArgs e)
        {
            int iD = TextUtils.ToInt(grvFile.GetFocusedRowCellValue(colFileID));
            if (iD == 0)
            {
                grvFile.DeleteRow(grvFile.FocusedRowHandle);
            }
            else
            {
                if (MessageBox.Show("Bạn có chắc muốn xóa file này không?", TextUtils.Caption,
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        string path = grvFile.GetFocusedRowCellValue(colFilePath).ToString();
                        BaiThucHanhFileBO.Instance.Delete(iD);
                        grvFile.DeleteRow(grvFile.FocusedRowHandle);
                        try
                        {
                            if (DocUtils.CheckExits(path))
                            {
                                DocUtils.DeleteFile(path);
                            }
                        }
                        catch
                        {                            
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Có lỗi xảy ra khi thực hiện thao tác, xin vui lòng thử lại sau.");
                    }
                }
            }   
        }

        private void grvFile_DoubleClick(object sender, EventArgs e)
        {
            if (grvFile.RowCount <= 0) return;
            if (grvFile.SelectedRowsCount > 0)
            {
                using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang mở file!"))
                {
                    int id = TextUtils.ToInt(grvFile.GetFocusedRowCellValue(colFileID));
                    if (id == 0) return;

                    string filePath = grvFile.GetFocusedRowCellValue(colFilePath).ToString();
                    string fileName = grvFile.GetFocusedRowCellValue(colFileName).ToString();
                    string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    DocUtils.DownloadFile(path, Path.GetFileName(filePath), filePath);

                    Process.Start(path + "/" + Path.GetFileName(filePath));
                }
            }
        }       
    }
}
