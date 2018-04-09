using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BMS.Model;
using BMS.Utils;
using BMS.Business;
using DevExpress.Utils;
using System.IO;
using System.Diagnostics;
using iTextSharp.text.pdf;

namespace BMS
{
    public partial class frmBCLError : _Forms
    {
        public ModuleErrorModel ErrorModel = new ModuleErrorModel();
        bool _isSaved = false;
        DateTime? _completeTimeKCS;
        int _type = 0;
        string _des = "";
        string _projectCode = "";
        int _moduleID = 0;

        #region Constructors and Load
        public frmBCLError()
        {
            InitializeComponent();
        }

        public frmBCLError(int type)
        {
            InitializeComponent();
            _type = type;            
        }

        public frmBCLError(string des, string projectCode, int moduleID)
        {
            InitializeComponent();

            _des = des;
            _projectCode = projectCode;
            _moduleID = moduleID;
        }

        private void frmBCLError_Load(object sender, EventArgs e)
        {
            //txtCode.Enabled = false;
            loadModule();
            loadDepartment();
            loadUserFind();
            loadProject();
            loadComboLoaiLoi();
            loadSupplier();

            cboStatus.SelectedIndex = 0;

            if (ErrorModel.ID > 0)
            {
                txtCode.Text = ErrorModel.Code;
                txtDescription.Text = ErrorModel.Description;

                cboProject.EditValue = ErrorModel.ProjectCode;
                //cboBPkhacphuc.SelectedValue = ErrorModel.DepartmentKPID;
                cboBPgayloi.SelectedValue = ErrorModel.DepartmentID;
                if (ErrorModel.ModuleID > 0)
                {
                    //cboModule.EditValue = ((ModulesModel)ModulesBO.Instance.FindByPK(ErrorModel.ModuleID)).Code;
                    cboModule.EditValue = ErrorModel.ModuleID;
                }
                cboStatus.SelectedIndex = ErrorModel.Status;
                cboUser.EditValue = ErrorModel.UserFindID;

                cboLoiTrucQuan.EditValue = ErrorModel.PLLTQ;
                //_completeTimeKCS = ErrorModel.CompleteTimeKCS;

                cboSupplier.EditValue = ErrorModel.SupplierId;

                this.Text = ErrorModel.Code;
            }
            else
            {
                //groupBox1.Enabled = false;
                DataTable dt = TextUtils.Select("SELECT top 1 Code FROM [ModuleError] order by ID desc");
                int code = TextUtils.ToInt(dt.Rows[0][0].ToString().Split('.')[1]);
                txtCode.Text = DateTime.Now.ToString("yy") + "L." + (code + 1);

                cboUser.EditValue = Global.UserID;

                txtDescription.Text = _des;
                cboModule.EditValue = _moduleID;
                cboProject.EditValue = _projectCode;
            }

            loadGrid();

            if (_type > 0)
            {
                btnSave.Enabled = btnSaveAndClose.Enabled = btnAddErrorType0.Enabled =
                    btnAddFileImage.Enabled = btnAddFile.Enabled = btnDeleteFile.Enabled = false;
            }
        }
        #endregion
        
        #region Methods

        void loadSupplier()
        {
            DataTable dt = LibQLSX.Select("select * from vSuppliers with(nolock) where SupplierCode not like 'nv%'");
            cboSupplier.Properties.DataSource = dt;
            cboSupplier.Properties.DisplayMember = "SupplierName";
            cboSupplier.Properties.ValueMember = "SupplierId";
            grvCboSupplier.BestFitColumns();
        }

        void loadModule()
        {
            DataTable tbl = TextUtils.Select("select * from Modules with(nolock) where status = 2 order by Code");
            TextUtils.PopulateCombo(cboModule, tbl, "Code", "ID", "");
        }

        void loadComboLoaiLoi()
        {
            try
            {
                DataTable tbl1 = TextUtils.Select("vModuleErrorType", new Expression("Type", 0));
                TextUtils.PopulateCombo(cboLoiTrucQuan, tbl1, "Name", "ID", "");
            }
            catch (Exception)
            {
            }
        }

        void loadDepartment()
        {
            try
            {
                DataTable dt = TextUtils.Select("select * from Department WITH(NOLOCK)");

                cboBPgayloi.DataSource = dt;
                cboBPgayloi.ValueMember = "ID";
                cboBPgayloi.DisplayMember = "Name";

                //cboBPkhacphuc.DataSource = dt;
                //cboBPkhacphuc.ValueMember = "ID";
                //cboBPkhacphuc.DisplayMember = "Name";

                cboBPgayloi.SelectedIndex = -1;
                //cboBPkhacphuc.SelectedIndex = -1;
            }
            catch (Exception)
            {               
            }              
        }

        void loadUserFind()
        {
            DataTable dt = TextUtils.Select("Select * from vUserInfo WITH(NOLOCK)");
            cboUser.Properties.DataSource = dt;
            cboUser.Properties.DisplayMember = "FullName";
            cboUser.Properties.ValueMember = "ID";
        }

        void loadProject()
        {
            try
            {
                DataTable tbl = LibQLSX.Select("exec spGetAllProject");
                TextUtils.PopulateCombo(cboProject, tbl, "ProjectName", "ProjectCode", "");
            }
            catch (Exception ex)
            {
            }
        }

        private bool ValidateForm()
        {
            if (txtCode.Text.Trim() == "")
            {
                MessageBox.Show("Xin hãy điền Mã.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            else
            {
                DataTable dt;
                if (ErrorModel.ID > 0)
                {
                    dt = TextUtils.Select("select Code from ModuleError with (nolock) where Code = '" + txtCode.Text.Trim() + "' and ID <> " + ErrorModel.ID);
                }
                else
                {
                    dt = TextUtils.Select("select Code from ModuleError with (nolock) where Code = '" + txtCode.Text.Trim() + "'");
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

            if (cboLoiTrucQuan.EditValue ==null)
            {
                MessageBox.Show("Xin hãy chọn loại lỗi trực quan.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (cboStatus.SelectedIndex < 0)
            {
                MessageBox.Show("Xin hãy chọn tình trạng lỗi.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            //if (cboProject.EditValue == null || cboProject.EditValue.ToString() == "")
            //{
            //    MessageBox.Show("Xin hãy chọn một dự án.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //        return false;
            //}

            if (cboModule.EditValue == null || cboModule.EditValue.ToString() == "")
            {
                MessageBox.Show("Xin hãy chọn một sản phẩm.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (txtDescription.Text.Trim() == "")
            {
                MessageBox.Show("Xin hãy nhập mô tả lỗi.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (TextUtils.ToInt(cboUser.EditValue) == 0)
            {
                MessageBox.Show("Xin hãy chọn người phát hiện lỗi.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            return true;
        }

        void save(bool close)
        {
            bool isNew = false;
            ProcessTransaction pt = new ProcessTransaction();
            pt.OpenConnection();
            pt.BeginTransaction();

            try
            {
                if (!ValidateForm())
                    return;

                if (ErrorModel.ID > 0)
                {
                    ErrorModel = (ModuleErrorModel)ModuleErrorBO.Instance.FindByPK(ErrorModel.ID);
                }

                ErrorModel.Code = txtCode.Text.Trim().ToUpper();

                ErrorModel.Description = txtDescription.Text.Trim();
                ErrorModel.PLLTQ = cboLoiTrucQuan.EditValue != null ? TextUtils.ToInt(cboLoiTrucQuan.EditValue) : 0;
                ErrorModel.Status = cboStatus.SelectedIndex;
                ErrorModel.ProjectCode = TextUtils.ToString(cboProject.EditValue);
                //ErrorModel.ModuleID = cboModule.EditValue != null ? ((ModulesModel)ModulesBO.Instance.FindByAttribute("Code", cboModule.EditValue.ToString())[0]).ID : 0;
                ErrorModel.ModuleID = TextUtils.ToInt(cboModule.EditValue);
                ErrorModel.UserFindID = TextUtils.ToInt(cboUser.EditValue);
                ErrorModel.DepartmentID = TextUtils.ToInt(cboBPgayloi.SelectedValue);
                //ErrorModel.DepartmentKPID = TextUtils.ToInt(cboBPkhacphuc.SelectedValue);

                ErrorModel.CompleteTimeKCS = _completeTimeKCS;

                //if (ErrorModel.DepartmentID == 1)//phong thiet ke
                //{
                                //}

                if (ErrorModel.DepartmentID == 6)//Phòng vật tư
                {
                    ErrorModel.SupplierId = TextUtils.ToString(cboSupplier.EditValue);
                    ErrorModel.SupplierCode = grvCboSupplier.GetFocusedRowCellValue(colSupplierCode) == null ? ErrorModel.SupplierCode : TextUtils.ToString(grvCboSupplier.GetFocusedRowCellValue(colSupplierCode));
                    ErrorModel.SupplierName = grvCboSupplier.GetFocusedRowCellValue(colSupplierName) == null ? ErrorModel.SupplierName : TextUtils.ToString(grvCboSupplier.GetFocusedRowCellValue(colSupplierName));
                }

                if (ErrorModel.ID == 0)
                {
                    ErrorModel.CreatedDate = TextUtils.GetSystemDate();
                    ErrorModel.CreatedBy = Global.AppUserName;
                    ErrorModel.UpdatedDate = ErrorModel.CreatedDate;
                    ErrorModel.UpdatedBy = Global.AppUserName;
                    ErrorModel.ID = (int)pt.Insert(ErrorModel);

                    ErrorModel.ConfirmManager = 0;
                    isNew = true;
                }
                else
                {
                    ErrorModel.UpdatedDate = TextUtils.GetSystemDate();
                    ErrorModel.UpdatedBy = Global.AppUserName;
                    pt.Update(ErrorModel);
                    isNew = false;
                }

                pt.CommitTransaction();
                _isSaved = true;                

                if (close)
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
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

        void loadGrid()
        {
            DataTable dt = TextUtils.Select("ModuleErrorImage", new Expression("ModuleErrorID", ErrorModel.ID));
            grvData.AutoGenerateColumns = false;
            grvData.DataSource = dt;
        }

        string getAddressMail(string personName)
        {
            if (personName != "")
            {
                DataTable dt = TextUtils.Select(string.Format("select * from dbo.Users where LoginName =N'{0}' or FullName=N'{0}'", personName));
                if (dt.Rows.Count>0)
                {
                    return dt.Rows[0]["LoginName"].ToString();
                }
            }
            return "";
        }

        string NVCoKhi;
        string NVDien;
        string NVDT;

        List<string> getListMail(string ProductCode)
        {            
            NVCoKhi="";
            NVDien = "";
            NVDT = "";

            DocUtils.InitFTPQLSX();
            List<string> listMailAddress = new List<string>();
            string personDien = "";
            try
            {
                string fdfFileName = string.Format("Thietke.Dn\\{0}\\{1}.Dn\\PRD.{1}\\{1}.Dn.pdf", ProductCode.Substring(0, 6), ProductCode);
                if (DocUtils.CheckExits(fdfFileName))
                {
                    DocUtils.DownloadFile("C:/", Path.GetFileName(fdfFileName), fdfFileName);
                    PdfReader reader1 = new PdfReader("C:/" + Path.GetFileName(fdfFileName));
                    personDien = reader1.Info["Author"];
                    reader1.Close();
                    File.Delete("C:/" + Path.GetFileName(fdfFileName));
                }
                else
                {
                    fdfFileName = string.Format("Thietke.Dn/{0}/{1}.Dn/{1}.Dn.pdf", ProductCode.Substring(0, 6), ProductCode);
                    if (DocUtils.CheckExits(fdfFileName))
                    {
                        DocUtils.DownloadFile("C:/", Path.GetFileName(fdfFileName), fdfFileName);
                        PdfReader reader1 = new PdfReader("C:/" + Path.GetFileName(fdfFileName));
                        personDien = reader1.Info["Author"];
                        reader1.Close();
                        File.Delete("C:/" + Path.GetFileName(fdfFileName));
                    }
                }
                         
                if (personDien!="")
                {
                    NVDien = personDien;
                    personDien = getAddressMail(personDien);
                    if (personDien != "")
                    {
                        listMailAddress.Add(getAddressMail(personDien) + "@tpa.com.vn");
                    }
                }                        
            }
            catch
            {
            }

            string _serverPathCK = "Thietke.Ck/" + ProductCode.Substring(0, 6) + "/" + ProductCode + ".Ck/" + "/VT." + ProductCode + ".xlsm";

            try
            {
                if (DocUtils.CheckExits(_serverPathCK))
                {
                    if (File.Exists("C:/VT." + ProductCode + ".xlsm"))
                    {
                        File.Delete("C:/VT." + ProductCode + ".xlsm");
                    }
                    //Download file danh mục vật tư
                    DocUtils.DownloadFile("C:/", "VT." + ProductCode + ".xlsm", _serverPathCK);
                    DataTable dtDMVT = TextUtils.ExcelToDatatable("C:/VT." + ProductCode + ".xlsm", "DMVT");
                    File.Delete("C:/VT." + ProductCode + ".xlsm");

                    NVCoKhi = dtDMVT.Rows[2]["F3"].ToString();
                    string ck = getAddressMail(dtDMVT.Rows[2]["F3"].ToString());
                    if (ck != "")
                    {
                        listMailAddress.Add(ck + "@tpa.com.vn");
                    }

                    try
                    {
                        DataTable dtDT = dtDMVT.Select("F4 like '%PCB%'").CopyToDataTable();
                        if (dtDT.Rows.Count > 0)
                        {
                            string dienTuPath = "Thietke.Dt/PCB/";
                            foreach (DataRow item in dtDT.Rows)
                            {
                                string code = item["F4"].ToString();
                                if (code != "")
                                {
                                    string pathDMVT_DT = dienTuPath + "/" + code + "/PRD." + code + "/VT." + code + ".xls";

                                    if (DocUtils.CheckExits(pathDMVT_DT))
                                    {
                                        try
                                        {
                                            DocUtils.DownloadFile("C:/", Path.GetFileName(pathDMVT_DT), pathDMVT_DT);
                                            DataTable dtDMVT_DT = TextUtils.ExcelToDatatable("C:/VT." + code + ".xls", "DMVT");
                                            File.Delete("C:/VT." + code + ".xls");
                                            NVDT += dtDMVT_DT.Rows[2]["F3"].ToString() + " - " + code + ",";
                                            string dt = getAddressMail(dtDMVT_DT.Rows[2]["F3"].ToString());
                                            if (dt != "")
                                            {
                                                string personDT = dt + "@tpa.com.vn";
                                                if (!listMailAddress.Contains(personDT))
                                                {
                                                    listMailAddress.Add(personDT);
                                                }  
                                            }
                                        }
                                        catch (Exception)
                                        {
                                        }
                                    }
                                }
                            }
                        }
                    }
                    catch
                    {
                    }
                }
            }
            catch
            {
            }
            return listMailAddress;
        }

        void sendMail()
        {
            if (ErrorModel.DepartmentID == 1)//Phong TK
            {
                //ModulesModel product = (ModulesModel)ModulesBO.Instance.FindByAttribute("Code", cboModule.EditValue.ToString())[0];
                ModulesModel product = (ModulesModel)ModulesBO.Instance.FindByPK(TextUtils.ToInt(cboModule.EditValue));
                string productCode = product.Code;
                List<string> listEmail = getListMail(productCode);

                #region Mở outlook
                int count = Process.GetProcesses().Where(o => o.ProcessName.Contains("OUTLOOK")).Count();
                if (count == 0)
                {
                    try
                    {
                        Process.Start("outlook.exe");
                    }
                    catch (Exception)
                    {
                    }
                }
                #endregion Mở outlook

                string subject = string.Format("ERROR REPORT - {0} - {1}", ErrorModel.Code, productCode);
                string content = "Mã lỗi: <b>" + ErrorModel.Code + "</b><br>"
                    + "Mã dự án: <b>" + cboProject.EditValue.ToString() + "<b><br>"
                    + "Mã sản phẩm: <b>" + productCode + "<b><br>"
                    + "Tên sản phẩm: <b>" + product.Name + "<b><br>"
                    + "Mô tả lỗi: " + ErrorModel.Description + "<br>"
                    + "Hình ảnh lỗi: <a>" + ErrorModel.FolderPathError + "</a>" + "<br>"
                    + "Danh sách nhân viên thiết kế: " + "<br>"
                    + "Thiết kế cơ khí: " + NVCoKhi + "<br>"
                    + "Thiết kế điện: " + NVDien + "<br>"
                    + "Thiết kế điện tử: " + NVDT
                    ;
                string to = "";
                foreach (string item in listEmail)
                {
                    to += item.ToLower() + ";";
                }

                frmSendEmailAttach frm = new frmSendEmailAttach();
                frm.Subject = subject;
                frm.CC = "tk@tpa.com.vn";
                frm.To = to;
                frm.Content = content;
                TextUtils.OpenForm(frm);
                //bool success = TextUtils.SetEmailSend(subject, content, to.Substring(0, to.Length - 1), "tk@tpa.com.vn");
                //if (!success)
                //{
                //    TextUtils.SetEmailSend(subject, content, "tk@tpa.com.vn", "");
                //}
            }            
        }

        void addFile(bool allFile)
        {
            DocUtils.InitFTPTK();
            OpenFileDialog ofd = new OpenFileDialog();
            if (!allFile)
            {
                ofd.Filter = "Image files (*.jpg, *.jpeg, *.png,*.gif) | *.jpg; *.jpeg; *.png; *.gif";
            }
            ofd.Multiselect = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang up file lên server!"))
                {
                    foreach (string filePath in ofd.FileNames)
                    {
                        ProcessTransaction pt = new ProcessTransaction();
                        pt.OpenConnection();
                        pt.BeginTransaction();
                        try
                        {
                            ModuleErrorImageModel errorImageModel;
                            bool isAdd = true;
                            if (!ModuleErrorImageBO.Instance.CheckExist("FileName", Path.GetFileName(filePath)))
                            {
                                errorImageModel = new ModuleErrorImageModel();
                            }
                            else
                            {
                                errorImageModel = (ModuleErrorImageModel)ModuleErrorImageBO.Instance.FindByAttribute("FileName", Path.GetFileName(filePath))[0];
                                isAdd = false;
                            }

                            FileInfo fInfo = new FileInfo(filePath);

                            string ftpFolderPath = "Modules\\ErrorImage\\" + ErrorModel.Code;

                            errorImageModel.DateCreated = TextUtils.GetSystemDate();
                            errorImageModel.FileName = Path.GetFileName(filePath);
                            errorImageModel.Size = fInfo.Length;
                            errorImageModel.FilePath = ftpFolderPath + "\\" + errorImageModel.FileName;
                            errorImageModel.ModuleErrorID = ErrorModel.ID;

                            if (isAdd)
                            {
                                errorImageModel.ID = (int)pt.Insert(errorImageModel);
                            }
                            else
                            {
                                pt.Update(errorImageModel);
                            }

                            if (!DocUtils.CheckExits(ftpFolderPath))
                            {
                                DocUtils.MakeDir(ftpFolderPath);
                            }
                            DocUtils.UploadFile(filePath, ftpFolderPath);

                            pt.CommitTransaction();
                        }
                        catch (Exception)
                        {
                        }
                        finally
                        {
                            pt.CloseConnection();
                        }
                    }

                    loadGrid();
                }
            }
        }

        #endregion

        #region Events
        private void cboProject_EditValueChanged(object sender, EventArgs e)
        {
            //string projectCode = cboProject.EditValue.ToString();
            //if (projectCode != "")
            //{
            //    try
            //    {
            //        //DataTable tbl = TextUtils.Select("Select ID, Code, Name from Modules with(nolock) where Code like '%TPAD%' and " +
            //        //                                  " code in (SELECT MaTheoThietKe FROM [QLKHCV].[dbo].[SanPhamDA] where ProjectsID='" + projectID + "') order by Code");
            //        string[] paraName = new string[1];
            //        string[] paraValue = new string[1];
            //        paraName[0] = "@ProjectCode"; paraValue[0] = projectCode;
            //        DataTable tbl = ModulesBO.Instance.LoadDataFromSP("spGetModuleOfProject", "Modules", paraName, paraValue);
            //        TextUtils.PopulateCombo(cboModule, tbl, "ProductName", "ProductCode", "");
            //    }
            //    catch (Exception ex)
            //    {
            //        cboModule.Properties.DataSource = null;
            //    }
            //}
            //else
            //{
            //    cboModule.Properties.DataSource = null;
            //}
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            save(false);
            if (_isSaved)
            {
                groupBox1.Enabled = true;
            }
        }

        private void btnSaveAndClose_Click(object sender, EventArgs e)
        {
            save(true);
        }

        private void cboStatus_SelectionChangeCommitted(object sender, EventArgs e)
        {           
            if (cboStatus.SelectedIndex == 1)
            {
                if (ErrorModel.StatusTK == 0)
                {
                    cboStatus.SelectedIndex = 0;
                }
                else
                {
                    _completeTimeKCS = DateTime.Now;
                }
                
            }
            else
            {
                _completeTimeKCS = null;
            }
        }

        private void frmBCLError_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_isSaved)
            {
                DialogResult = DialogResult.OK;
            }
        }

        private void btnAddFile_Click(object sender, EventArgs e)
        {
            if (ErrorModel.ID == 0)
            {
                MessageBox.Show("Bạn phải ghi lại trước khi thêm file!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            addFile(true);
        }

        private void btnAddFileImage_Click(object sender, EventArgs e)
        {
            if (ErrorModel.ID == 0)
            {
                MessageBox.Show("Bạn phải ghi lại trước khi thêm file!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            addFile(false);
        }

        private void btnDeleteFile_Click(object sender, EventArgs e)
        {
            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang xóa file lên server!"))
            {
                DocUtils.InitFTPTK();
                if (grvData.RowCount <= 0) return;

                int id = TextUtils.ToInt(grvData.SelectedRows[0].Cells[colID.Name].Value);
                if (id == 0) return;

                string filePath = grvData.SelectedRows[0].Cells[colFilePath.Name].Value.ToString();
                string fileName = grvData.SelectedRows[0].Cells[colFileName.Name].Value.ToString();

                if (MessageBox.Show("Bạn có thật sự muốn xóa file [" + fileName + "] này không?", TextUtils.Caption,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;

                ProcessTransaction pt = new ProcessTransaction();
                pt.OpenConnection();
                pt.BeginTransaction();
                try
                {
                    pt.Delete("ModuleErrorImage", id);

                    if (DocUtils.CheckExits(filePath))
                    {
                        DocUtils.DeleteFile(filePath);
                    }
                    
                    pt.CommitTransaction();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Xóa file [" + fileName + "] không thành công!" + Environment.NewLine + ex.Message,
                        TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                finally
                {
                    pt.CloseConnection();
                }
                loadGrid();
            }
        }

        private void btnShowErrorImage_Click(object sender, EventArgs e)
        {
            if (grvData.RowCount <= 0) return;
            if (grvData.SelectedRows.Count > 0)
            {
                using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang download file từ server!"))
                {
                    int id = TextUtils.ToInt(grvData.SelectedRows[0].Cells[colID.Name].Value);
                    if (id == 0) return;

                    string filePath = grvData.SelectedRows[0].Cells[colFilePath.Name].Value.ToString();
                    string fileName = grvData.SelectedRows[0].Cells[colFileName.Name].Value.ToString();
                    DocUtils.InitFTPTK();
                    DocUtils.DownloadFile(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), Path.GetFileName(filePath), filePath);

                    Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/" + Path.GetFileName(filePath));
                }
            }
        }
        #endregion

        private void grvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grvData.RowCount <= 0) return;
            if (grvData.SelectedRows.Count > 0)
            {
                using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang mở file!"))
                {
                    int id = TextUtils.ToInt(grvData.SelectedRows[0].Cells[colID.Index].Value);
                    if (id == 0) return;

                    string localPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    string filePath = grvData.SelectedRows[0].Cells[colFilePath.Index].Value.ToString();
                    string fileName = grvData.SelectedRows[0].Cells[colFileName.Index].Value.ToString();

                    DocUtils.InitFTPTK();
                    DocUtils.DownloadFile(localPath, Path.GetFileName(filePath), filePath);

                    Process.Start(localPath + "/" + Path.GetFileName(filePath));
                }
            }
        }

        private void btnAddErrorType0_Click(object sender, EventArgs e)
        {
            frmModuleErrorType frm = new frmModuleErrorType();
            frm.Type = 0;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                loadComboLoaiLoi();
            }
        }

        private void grvData_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                var files = (string[])e.Data.GetData(DataFormats.FileDrop);
                DocUtils.InitFTPTK();
                using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang up file lên server!"))
                {
                    foreach (string filePath in files)
                    {
                        ProcessTransaction pt = new ProcessTransaction();
                        pt.OpenConnection();
                        pt.BeginTransaction();
                        try
                        {
                            ModuleErrorImageModel errorImageModel;
                            bool isAdd = true;
                            if (!ModuleErrorImageBO.Instance.CheckExist("FileName", Path.GetFileName(filePath)))
                            {
                                errorImageModel = new ModuleErrorImageModel();
                            }
                            else
                            {
                                errorImageModel = (ModuleErrorImageModel)ModuleErrorImageBO.Instance.FindByAttribute("FileName", Path.GetFileName(filePath))[0];
                                isAdd = false;
                            }

                            FileInfo fInfo = new FileInfo(filePath);

                            string ftpFolderPath = "Modules\\ErrorImage\\" + ErrorModel.Code;

                            errorImageModel.DateCreated = TextUtils.GetSystemDate();
                            errorImageModel.FileName = Path.GetFileName(filePath);
                            errorImageModel.Size = fInfo.Length;
                            errorImageModel.FilePath = ftpFolderPath + "\\" + errorImageModel.FileName;
                            errorImageModel.ModuleErrorID = ErrorModel.ID;

                            if (isAdd)
                            {
                                errorImageModel.ID = (int)pt.Insert(errorImageModel);
                            }
                            else
                            {
                                pt.Update(errorImageModel);
                            }

                            if (!DocUtils.CheckExits(ftpFolderPath))
                            {
                                DocUtils.MakeDir(ftpFolderPath);
                            }
                            DocUtils.UploadFile(filePath, ftpFolderPath);

                            pt.CommitTransaction();
                        }
                        catch (Exception)
                        {
                        }
                        finally
                        {
                            pt.CloseConnection();
                        }
                    }
                }
                loadGrid();
                              
            }
        }

        private void grvData_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        private void cboBPgayloi_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboBPgayloi_SelectedValueChanged(object sender, EventArgs e)
        {
            int id = TextUtils.ToInt(cboBPgayloi.SelectedValue);
            if (id == 6)
            {
                cboSupplier.Enabled = true;
            }
            else
            {
                cboSupplier.Enabled = false;
                cboSupplier.EditValue = null;
            }
        }

    }
}
