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
using DevExpress.Utils;
using System.IO;

namespace BMS
{
    public partial class frmRequire : _Forms
    {        
        #region Variables
        public RequireSolutionModel Require = new RequireSolutionModel();
        public string CustomerCode = "";
        DataTable _dtFile = new DataTable();
        bool _isSaved = false;

        public delegate void LoadDataChangeHandler(object sender, EventArgs e);
        public event LoadDataChangeHandler LoadDataChange;
        #endregion

        public frmRequire()
        {
            InitializeComponent();
        }

        private void frmRequire_Load(object sender, EventArgs e)
        {
            loadGrid();
            loadUser();
            loadKhachHang();

            if (Require.ID > 0)
            {
                txtCode.Text = Require.Code;
                txtCost.EditValue = Require.Cost;
                txtDescription.Text = Require.Description;
                txtEmail.Text = Require.Email;
                txtName.Text = Require.Name;
                txtNguoiDaiDien.Text = Require.NguoiDaiDien;
                txtPhone.Text = Require.Phone;

                dtpSolutionDate.EditValue = Require.SolutionDate;
                dtpRequestDate.EditValue = Require.RequireDate;

                cboCustomer.EditValue = Require.CustomerCode;
                cboNguoiPhuTrach.EditValue = Require.NguoiPhuTrach;
                cboNguoiYeuCau.EditValue = Require.RequirePerson;
                cboPriority.SelectedIndex = Require.Priority;
            }
            else
            {
                cboPriority.SelectedIndex = 0;
                cboCustomer.EditValue = CustomerCode;

                DataTable dt = LibQLSX.Select(" SELECT top 1 Code FROM RequireSolution order by ID desc");
                string code = "YC.000001";
                if (dt.Rows.Count > 0)
                {
                    code = TextUtils.ToString(dt.Rows[0]["Code"]);
                    code = code.Substring(3, code.Length - 3);
                    code = "YC." + string.Format("{0:000000}", TextUtils.ToInt(code) + 1);
                }
                txtCode.Text = code;
            }
        }

        void loadUser()
        {
            DataTable dt = TextUtils.Select("Select * from vUserInfo WITH(NOLOCK)");

            cboNguoiYeuCau.Properties.DataSource = dt;
            cboNguoiYeuCau.Properties.DisplayMember = "FullName";
            cboNguoiYeuCau.Properties.ValueMember = "ID";

            cboNguoiPhuTrach.Properties.DataSource = dt;
            cboNguoiPhuTrach.Properties.DisplayMember = "FullName";
            cboNguoiPhuTrach.Properties.ValueMember = "ID";
        }

        void loadGrid()
        {
            _dtFile = TextUtils.Select("RequireSolutionFile", new Expression("RequireSolutionID", Require.ID));
            _dtFile.Columns.Add("LocalPath");
            grdFile.DataSource = _dtFile;
        }

        void loadKhachHang()
        {
            DataTable dt = LibQLSX.Select("Select * from Customers with(nolock)");
            cboCustomer.Properties.DataSource = dt;
            cboCustomer.Properties.ValueMember = "CustomerCode";
            cboCustomer.Properties.DisplayMember = "CustomerName";
        }

        bool ValidateForm()
        {
            if (txtName.Text.Trim() == "")
            {
                MessageBox.Show("Xin hãy điền tên.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            if (txtDescription.Text.Trim() == "")
            {
                MessageBox.Show("Xin hãy điền mô tả yêu cầu.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            if (cboCustomer.EditValue == null)
            {
                MessageBox.Show("Xin hãy chọn khách hàng.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            if (cboNguoiPhuTrach.EditValue == null)
            {
                MessageBox.Show("Xin hãy chọn người phụ trách.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            if (cboNguoiYeuCau.EditValue == null)
            {
                MessageBox.Show("Xin hãy chọn người yêu cầu.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            if (cboPriority.SelectedIndex<0)
            {
                 MessageBox.Show("Xin hãy chọn mức độ ưu tiên.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            if (dtpRequestDate.EditValue == null)
            {
                MessageBox.Show("Xin hãy thêm ngày yêu cầu.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            if (dtpSolutionDate.EditValue == null)
            {
                MessageBox.Show("Xin hãy thêm hạn cấp giải pháp.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            return true;
        }

        void save(bool close)
        {
            ProcessTransaction pt = new ProcessTransaction();
            pt.OpenConnection();
            pt.BeginTransaction();
            try
            {
                if (!ValidateForm())
                    return;

                grvFile.FocusedRowHandle = -1;

                Require.Name = txtName.Text.Trim().ToUpper();
                Require.Code = txtCode.Text.Trim();
                Require.CustomerCode = TextUtils.ToString(cboCustomer.EditValue);
                Require.CustomerName = TextUtils.ToString(grvCboKhachHang.GetFocusedRowCellValue(colCboCustomerName));

                Require.Description = txtDescription.Text;
                Require.RequireDate = (DateTime?)dtpRequestDate.EditValue;
                Require.SolutionDate = (DateTime?)dtpSolutionDate.EditValue;
                Require.RequirePerson = TextUtils.ToInt(cboNguoiYeuCau.EditValue);
                Require.NguoiPhuTrach = TextUtils.ToInt(cboNguoiPhuTrach.EditValue);
                Require.Priority = cboPriority.SelectedIndex;
                Require.NguoiDaiDien = txtNguoiDaiDien.Text.Trim();
                Require.Phone = txtPhone.Text;
                Require.Email = txtEmail.Text;
                Require.Cost = TextUtils.ToDecimal(txtCost.Text);
                Require.UpdatedDate = TextUtils.GetSystemDate();
                Require.UpdatedBy = Global.AppUserName;

                if (Require.ID <= 0)
                {
                    Require.CreatedDate = TextUtils.GetSystemDate();
                    Require.CreatedBy = Global.AppUserName;                    
                    Require.ID = (int)pt.Insert(Require);
                }
                else
                {                    
                    pt.Update(Require);
                }

                //update tên cho file ipt
                DataRow[] drs = _dtFile.Select("ID = 0 or ID is null");
                if (drs.Length > 0)
                {
                    DocUtils.InitFTPTK();

                    using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang update tên cho file..."))
                    {
                        for (int i = 0; i < grvFile.RowCount; i++)
                        {
                            long id = TextUtils.ToInt64(grvFile.GetRowCellValue(i, colFileID));
                            if (id > 0) continue;

                            string name = TextUtils.ToString(grvFile.GetRowCellValue(i, colFileName));
                            string extension = Path.GetExtension(name);
                            decimal length = TextUtils.ToDecimal(grvFile.GetRowCellValue(i, colFileLenght));
                            string description = TextUtils.ToString(grvFile.GetRowCellValue(i, colFileDescription));
                            string path = "YeuCau/" + Require.Code + "/" + name;
                            string createdBy = Global.AppUserName;
                            DateTime? createdDate = DateTime.Now;

                            string localPath = TextUtils.ToString(grvFile.GetRowCellValue(i, colFileLocalPath));

                            if (!DocUtils.CheckExits("YeuCau/" + Require.Code))
                            {
                                DocUtils.MakeDir("YeuCau/" + Require.Code);
                            }

                            RequireSolutionFileModel fileModel = new RequireSolutionFileModel();
                            fileModel.CreatedBy = createdBy;
                            fileModel.CreatedDate = createdDate;
                            fileModel.Description = description;
                            fileModel.Extension = extension;
                            fileModel.Length = length;
                            fileModel.Name = name;
                            fileModel.Path = path;
                            fileModel.RequireSolutionID = Require.ID;
                            pt.Insert(fileModel);

                            DocUtils.UploadFile(localPath, "YeuCau/" + Require.Code);
                        }
                    }
                }

                pt.CommitTransaction();

                loadGrid();
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
                MessageBox.Show("Lưu trữ không thành công!" + Environment.NewLine + ex.Message, TextUtils.Caption,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                pt.CloseConnection();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            save(false);
            if (_isSaved)
            {
                this.Text = "Yêu cầu: " + Require.Code + " - " + Require.Name;
                if (this.LoadDataChange != null)
                {
                    this.LoadDataChange(null, null);
                }
            }
        }

        private void btnDeleteFile_Click(object sender, EventArgs e)
        {
            DocUtils.InitFTPTK();
            if (grvFile.RowCount <= 0) return;

            int id = TextUtils.ToInt(grvFile.GetFocusedRowCellValue(colFileID));
            //if (id == 0) return;

            string filePath = TextUtils.ToString(grvFile.GetFocusedRowCellValue(colFileLocalPath));
            string fileName = Path.GetFileName(filePath);

            if (MessageBox.Show("Bạn có thật sự muốn xóa file [" + fileName + "] này không?", TextUtils.Caption,
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;

            if (id == 0)
            {
                
            }
            else
            {
                ProcessTransaction pt = new ProcessTransaction();
                pt.OpenConnection();
                pt.BeginTransaction();
                try
                {
                    pt.Delete("RequireSolutionFile", id);

                    if (DocUtils.CheckExits(filePath))
                    {
                        DocUtils.DeleteFile(filePath);
                    }

                    pt.CommitTransaction();
                    grvFile.DeleteSelectedRows();
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
            }
        }

        private void btnAddFile_Click(object sender, EventArgs e)
        {
            DocUtils.InitFTPTK();
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                foreach (string item in ofd.FileNames)
                {
                    FileInfo fInfo = new FileInfo(item);
                    DataRow r = _dtFile.NewRow();
                    r["LocalPath"] = fInfo.FullName;
                    r["Name"] = fInfo.Name;
                    r["Extension"] = fInfo.Extension;
                    r["Length"] = fInfo.Length;
                    _dtFile.Rows.Add(r);
                }
            }
        }

        private void downloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string localPath = "";
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                localPath = fbd.SelectedPath;
                DocUtils.InitFTPTK();
            }
            else
            {
                return;
            }
            foreach (int i in grvFile.GetSelectedRows())
            {
                string ftpFilePath = grvFile.GetRowCellValue(i, colFilePath).ToString();
                DocUtils.DownloadFile(localPath, Path.GetFileName(ftpFilePath), ftpFilePath);
            }
        }
    }
}
