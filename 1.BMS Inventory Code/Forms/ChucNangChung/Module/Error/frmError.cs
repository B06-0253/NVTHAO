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
using BMS.Business;
using System.IO;
using DevExpress.Utils;
using System.Diagnostics;

namespace BMS
{
    public partial class frmError : _Forms
    {
        #region Variables
        public ModuleErrorModel ErrorModel = new ModuleErrorModel();
        public int ModuleID = 0;
        bool _isSaved = false;
            
        #endregion

        public frmError()
        {
            InitializeComponent();
        }      

        private void frmError_Load(object sender, EventArgs e)
        {
            loadAllCombo();
            loadDepartment();
            cboStatus.SelectedIndex = 0;
            if (ErrorModel.ID > 0)
            {
                txtHuongKhacPhuc.Text = ErrorModel.HuongKhacPhuc;
                txtHuongKhacPhucTamThoi.Text = ErrorModel.HuongKhacPhucTamThoi;

                cboBPkhacphuc.SelectedValue = ErrorModel.DepartmentKPID;
                cboLoiChiPhi.SelectedValue = ErrorModel.PLLCP;
                txtReason.Text = ErrorModel.Reason;
                cboStatus.SelectedIndex = ErrorModel.StatusTK;
                dateEditEndDK.EditValue = ErrorModel.EndTimeDK;
                dateEditEndTT.EditValue = ErrorModel.EndTimeTT;
                dateEditStartDK.EditValue = ErrorModel.StartTimeDK;
                dateEditStartTT.EditValue = ErrorModel.StartTimeTT;
                txtNote.Text = ErrorModel.Note;

                this.Text += ": " + ErrorModel.Code;

                loadGridUser();

                loadGrid();
            }
        }
   
        #region Functions
        void loadDepartment()
        {
            try
            {
                DataTable dt = TextUtils.Select("select * from Department WITH(NOLOCK)");

                cboBPkhacphuc.DataSource = dt;
                cboBPkhacphuc.ValueMember = "ID";
                cboBPkhacphuc.DisplayMember = "Name";

                cboBPkhacphuc.SelectedIndex = -1;
            }
            catch (Exception)
            {
            }
        }

        void loadGrid()
        {
            DataTable dt = TextUtils.Select("ModuleErrorImage", new Expression("ModuleErrorID", ErrorModel.ID));
            grvErrorImage.AutoGenerateColumns = false;
            grvErrorImage.DataSource = dt;
        }

        void loadComboLoaiLoi()
        {                    
            try
            {
                //load lỗi theo chi phí
                DataTable tbl2 = TextUtils.Select("ModuleErrorType", new Expression("Type", 2));
                TextUtils.PopulateCombo(cboLoiChiPhi, tbl2.Copy(), "Name", "ID", "");
            }
            catch (Exception)
            {
            }
        }

        void loadAllCombo()
        {           
            try
            {
                DataTable dt = TextUtils.Select("Select * from vUserInfo WITH(NOLOCK)");
                cboUser.Properties.DataSource = dt;
                cboUser.Properties.DisplayMember = "FullName";
                cboUser.Properties.ValueMember = "ID";
            }
            catch (Exception)
            {                
            }           

            loadComboLoaiLoi();
        }
        
        private bool ValidateForm()
        {
            if (cboStatus.SelectedIndex < 0)
            {
                MessageBox.Show("Xin hãy chọn tình trạng lỗi.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            else
            {
                if (cboStatus.SelectedIndex==1)
                {
                    if (txtHuongKhacPhuc.Text.Trim()=="")
                    {
                        MessageBox.Show("Xin hãy điền hướng khắc phục lâu dài.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return false;
                    }
                }
            }

            if (txtHuongKhacPhucTamThoi.Text.Trim() == "")
            {
                MessageBox.Show("Xin hãy điền hướng khắc phục tạm thời.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (grvData.Rows.Count < 1)
            {
                MessageBox.Show("Xin hãy chọn nhân viên gây lỗi.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (txtReason.Text.Trim() == "")
            {
                MessageBox.Show("Xin hãy điền nguyên nhân.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (cboBPkhacphuc.SelectedIndex < 0)
            {
                MessageBox.Show("Xin hãy chọn bộ phận khắc phục.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (dateEditEndTT.EditValue == null && cboStatus.SelectedIndex == 1)
            {
                MessageBox.Show("Xin hãy chọn ngày kết thúc thực tế.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            if (dateEditStartDK.EditValue == null && cboStatus.SelectedIndex == 1)
            {
                MessageBox.Show("Xin hãy chọn ngày bắt đầu dự kiến.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            if (dateEditEndDK.EditValue == null && cboStatus.SelectedIndex == 1)
            {
                MessageBox.Show("Xin hãy chọn ngày kết thúc kiến.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            return true;
        }

        void loadGridUser()
        {
            DataTable dt = TextUtils.Select("select * from vModuleErrorUser where ModuleErrorID = '" + ErrorModel.ID + "'");
            grvData.AutoGenerateColumns = false;
            grvData.DataSource = dt;
           
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

                if (ErrorModel.ID > 0)
                {
                    ErrorModel = (ModuleErrorModel)ModuleErrorBO.Instance.FindByPK(ErrorModel.ID);
                }

                ErrorModel.StatusTK = cboStatus.SelectedIndex;
                ErrorModel.PLLCP = cboLoiChiPhi.SelectedValue != null ? TextUtils.ToInt(cboLoiChiPhi.SelectedValue) : 0;
                ErrorModel.Reason = txtReason.Text.Trim();
                ErrorModel.IsTK = 1;
                ErrorModel.DepartmentKPID = TextUtils.ToInt(cboBPkhacphuc.SelectedValue);

                ErrorModel.HuongKhacPhucTamThoi = txtHuongKhacPhucTamThoi.Text.Trim();
                ErrorModel.HuongKhacPhuc = txtHuongKhacPhuc.Text.Trim();

                ErrorModel.CompleteTimeTK = cboStatus.SelectedIndex == 0 ? (DateTime?)null : DateTime.Now;

                ErrorModel.StartTimeDK = (DateTime?)dateEditStartDK.EditValue;
                ErrorModel.StartTimeTT = (DateTime?)dateEditStartTT.EditValue;
                ErrorModel.EndTimeDK = (DateTime?)dateEditEndDK.EditValue;
                ErrorModel.EndTimeTT = (DateTime?)dateEditEndTT.EditValue;
                ErrorModel.Note = txtNote.Text.Trim();

                if (ErrorModel.ID == 0)
                {
                    ErrorModel.ID = (int)pt.Insert(ErrorModel);
                }
                else
                {
                    ErrorModel.UpdatedDate = TextUtils.GetSystemDate();
                    ErrorModel.UpdatedBy = Global.AppUserName;
                    pt.Update(ErrorModel);
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

        void sendEmail()
        {
            ModulesModel product = (ModulesModel)ModulesBO.Instance.FindByPK(ErrorModel.ModuleID);
            string productCode = product.Code;

            string nguoiGayLoi = "";
            string userMails = "";
            foreach (DataGridViewRow item in grvData.Rows)
            {
                nguoiGayLoi += item.Cells[colFullName.Index].Value.ToString() + ",";
                userMails += item.Cells[colLoginName.Index].Value.ToString() + ";";
            }

            frmSendEmailAttach frm = new frmSendEmailAttach();
            frm.To = "kcs@tpa.com.vn";
            frm.CC = //"info@tpa.com.vn";
            "vt@tpa.com.vn;tk1@tpa.com.vn;tk2@tpa.com.vn;sxlr@tpa.com.vn;";
            frm.Subject = string.Format("ERROR REPORT - {0} - {1}", ErrorModel.Code, productCode);
            DataTable dtConfig = TextUtils.Select("select KeyValue from [ConfigSystem] where [KeyName]='TKToKCS_Email'");
            string content = dtConfig.Rows[0][0].ToString();
            frm.Content = content.Replace("<ErrorCode>", "<b>" + ErrorModel.Code + "</b>")
                .Replace("<ProjectCode>", "<b>" + ErrorModel.ProjectCode + "</b>")
                .Replace("<ProductCode>", "<b>" + productCode + "</b>")
                .Replace("<ProductName>", product.Name)
                .Replace("<ErrorStatus>", "<b>" + cboStatus.Text + "</b>")
                .Replace("<ErrorUser>", nguoiGayLoi)
                .Replace("<TamThoi>", ErrorModel.HuongKhacPhucTamThoi)
                .Replace("<LauDai>", ErrorModel.HuongKhacPhuc == "" ? "Chưa có" : ErrorModel.HuongKhacPhuc);
            frm.Show();
        }
        #endregion

        private void btnSaveAndClose_Click(object sender, EventArgs e)
        {
            save(true);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            save(false);
        }

        private void btnAddErrorType2_Click(object sender, EventArgs e)
        {
            frmModuleErrorType frm = new frmModuleErrorType();
            frm.Type = 2;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                loadComboLoaiLoi();
            }
        }       

        private void frmError_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_isSaved)
            {
                DialogResult = DialogResult.OK;
            }
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            if (cboUser.EditValue == null)
            {
                MessageBox.Show("Bạn phải chọn một nhân viên!");
                return;
            }
            DataTable dt = TextUtils.Select("select * from vModuleErrorUser where ModuleErrorID = '" + ErrorModel.ID + "' and UserID= " + TextUtils.ToInt(cboUser.EditValue));
            if (dt.Rows.Count>0)
            {
                MessageBox.Show("Nhân viên này đã được gán!");
                return;
            }
            ModuleErrorUserModel model = new ModuleErrorUserModel();
            model.ModuleErrorID = ErrorModel.ID;
            model.UserID = TextUtils.ToInt(cboUser.EditValue);
            ModuleErrorUserBO.Instance.Insert(model);
            MessageBox.Show("Thêm nhân viên thành công!", TextUtils.Caption);
            loadGridUser();
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            int id = TextUtils.ToInt(grvData.SelectedRows[0].Cells[colID.Index].Value);
            string name = grvData.SelectedRows[0].Cells[colFullName.Index].Value.ToString();
            if (id > 0)
            {
                if (MessageBox.Show("Bạn có chắc muốn xóa nhân viên [" + name + "] ra khỏi danh sách?", TextUtils.Caption, 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ModuleErrorUserBO.Instance.Delete(id);
                    loadGridUser();
                }
            }
        }

        private void grvErrorImage_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grvErrorImage.RowCount <= 0) return;
            if (grvErrorImage.SelectedRows.Count > 0)
            {
                try
                {
                    using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang mở file!"))
                    {
                        int id = TextUtils.ToInt(grvErrorImage.SelectedRows[0].Cells[colImageID.Index].Value);
                        if (id == 0) return;

                        string filePath = grvErrorImage.SelectedRows[0].Cells[colFilePath.Index].Value.ToString();
                        string fileName = grvErrorImage.SelectedRows[0].Cells[colFileName.Index].Value.ToString();
                        DocUtils.InitFTPTK();
                        string desktopFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                        DocUtils.DownloadFile(desktopFolder, Path.GetFileName(filePath), filePath);
                        Process.Start(desktopFolder + "/" + Path.GetFileName(filePath));
                    }
                }
                catch
                {                   
                }               
            }
        }      
    }
}
