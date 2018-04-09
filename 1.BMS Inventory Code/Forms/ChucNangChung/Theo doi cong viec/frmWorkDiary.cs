using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BMS.Business;
using BMS.Model;
using BMS.Utils;

namespace BMS
{
    public partial class frmWorkDiary : _Forms
    {
        bool _isSaved = false;
        public delegate void LoadDataChangeHandler(object sender, EventArgs e);
        public event LoadDataChangeHandler LoadDataChange;
        DataTable _dtHistory = new DataTable();
        public TheoDoiModel WorkDiary = new TheoDoiModel();
        DateTime _oldEndDateDK;

        public frmWorkDiary()
        {
            InitializeComponent();
        }

        private void frmWorkDiary_Load(object sender, EventArgs e)
        {
            loadProject();
            loadUser();

            if (WorkDiary.ID > 0)
            {
                txtModuleCode.Text = WorkDiary.ModuleCode;
                txtName.Text = WorkDiary.Name;
                txtNote.Text = WorkDiary.GhiChu;
                txtProjectCode.Text = WorkDiary.ProjectCode;
                //txtTime.EditValue = WorkDiary.ThoiGianDuKien;

                cboUser.EditValue = WorkDiary.UserID;
                cboStatus.SelectedIndex = WorkDiary.Status;

                dtpEndDateDK.Value = (DateTime)WorkDiary.EndDateDK;
                dtpStartDate.Value = (DateTime)WorkDiary.StartDate;

                txtEndDate.Text = WorkDiary.EndDate != null ? ((DateTime)WorkDiary.EndDate).ToString("dd/MM/yyyy") : "";

                _oldEndDateDK = (DateTime)WorkDiary.EndDateDK;
            }
            else
            {
                cboStatus.SelectedIndex = 0;
                //dtpEndDateDK.Value = dtpEndDateDK.MinDate;
                cboUser.EditValue = Global.UserID;
            }

            loadHistory();            
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

        void loadHistory()
        {
            _dtHistory = TextUtils.Select("select * from TheoDoiHistory with(nolock) where TheoDoiID = " + WorkDiary.ID);
            grdHistory.DataSource = _dtHistory;
        }

        void loadUser()
        {
            DataTable dt = TextUtils.Select("Select * from vUserInfo WITH(NOLOCK)");
            cboUser.Properties.DataSource = dt;
            cboUser.Properties.DisplayMember = "FullName";
            cboUser.Properties.ValueMember = "ID";
        }

        private void cboProject_EditValueChanged(object sender, EventArgs e)
        {
            string projectCode = TextUtils.ToString(cboProject.EditValue);
            if (projectCode != "")
            {
                txtProjectCode.Text = projectCode;
            }
            if (projectCode != "")
            {
                try
                {
                    string[] paraName = new string[1];
                    string[] paraValue = new string[1];
                    paraName[0] = "@ProjectCode"; paraValue[0] = projectCode;
                    DataTable tbl = ModulesBO.Instance.LoadDataFromSP("spGetModuleOfProject", "Modules", paraName, paraValue);
                    TextUtils.PopulateCombo(cboModule, tbl, "ProductName", "ProductCode", "");

                }
                catch (Exception ex)
                {
                    cboModule.Properties.DataSource = null;
                }
            }
            else
            {
                cboModule.Properties.DataSource = null;
            }
        }

        bool ValidateForm()
        {
            //if (txtModuleCode.Text.Trim()=="")
            //{
            //    MessageBox.Show("Mã module không thể để trống!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    return false;
            //}

            //if (txtProjectCode.Text.Trim() == "")
            //{
            //    MessageBox.Show("Mã dự án không thể để trống!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    return false;
            //}

            if (txtName.Text.Trim() == "")
            {
                MessageBox.Show("Tên công việc không thể để trống!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (cboStatus.SelectedIndex < 0)
            {
                MessageBox.Show("Trạng thái không thể để trống!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (cboUser.EditValue == null)
            {
                MessageBox.Show("Người phụ trách không thể để trống!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (dtpStartDate.Value.Date > dtpEndDateDK.Value.Date)
            {
                MessageBox.Show("Ngày kết thúc dự kiến không đúng giá trị!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (_oldEndDateDK.Date != dtpEndDateDK.Value && WorkDiary.ID > 0)
            {
                if (txtReason.Text.Trim() == "")
                {
                    MessageBox.Show("Ngày kết thúc dự kiến đã thay đổi,\nBạn phải điền nguyên nhân.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return false;
                }
            }

            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ProcessTransaction pt = new ProcessTransaction();
            pt.OpenConnection();
            pt.BeginTransaction();
            try
            {
                if (!ValidateForm())
                    return;

                WorkDiary.EndDateDK = dtpEndDateDK.Value;
                WorkDiary.GhiChu = txtNote.Text.Trim();
                WorkDiary.ModuleCode = txtModuleCode.Text.Trim();
                WorkDiary.Name = txtName.Text.Trim();
                WorkDiary.ProjectCode = txtProjectCode.Text.Trim();
                WorkDiary.StartDate = dtpStartDate.Value;
                WorkDiary.Status = cboStatus.SelectedIndex;
                //WorkDiary.ThoiGianDuKien = TextUtils.ToInt(txtTime.EditValue);
                WorkDiary.UserID = TextUtils.ToInt(cboUser.EditValue);

                if (cboStatus.SelectedIndex == 1)
                {
                    WorkDiary.EndDate = DateTime.Now;
                }
                else
                {
                    WorkDiary.EndDate = null;
                }

                if (WorkDiary.ID == 0)
                {
                    WorkDiary.ID = (int)pt.Insert(WorkDiary);

                    TheoDoiHistoryModel history = new TheoDoiHistoryModel();
                    history.EndDateDK = WorkDiary.EndDateDK;
                    history.TheoDoiID = WorkDiary.ID;
                    history.Reason = "Thêm mới";
                    pt.Insert(history);
                }
                else
                {
                    pt.Update(WorkDiary);

                    if (_oldEndDateDK.Date != dtpEndDateDK.Value)
                    {
                        TheoDoiHistoryModel history = new TheoDoiHistoryModel();
                        history.EndDateDK = WorkDiary.EndDateDK;
                        history.TheoDoiID = WorkDiary.ID;
                        history.Reason = txtReason.Text.Trim();
                        pt.Insert(history);
                    }
                }

                pt.CommitTransaction();
                loadHistory();
                _isSaved = true;
                MessageBox.Show("Lưu trữ thành công!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);                
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

            if (_isSaved && this.LoadDataChange != null)
            {
                this.LoadDataChange(null, null);
            }
        }

        private void dtpEndDateDK_ValueChanged(object sender, EventArgs e)
        {
            if (WorkDiary.ID > 0)
                lblReason.Enabled = txtReason.Enabled = _oldEndDateDK.Date != dtpEndDateDK.Value.Date;
        }

        private void cboModule_EditValueChanged(object sender, EventArgs e)
        {
            string moduleCode = TextUtils.ToString(cboModule.EditValue);
            if (moduleCode != "")
            {
                txtModuleCode.Text = moduleCode;
            }
        }
    }
}
