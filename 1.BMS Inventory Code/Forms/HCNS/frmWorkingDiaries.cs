using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TPA.Business;
using TPA.Model;
using TPA.Utils;

namespace BMS
{
    public partial class frmWorkingDiaries : _Forms
    {
        #region Variables
        public WorkingDiariesModel WorkingDiaries = new WorkingDiariesModel();
        public int CatID = 0;
        public bool IsCopy = false;
        bool _isSaved = false;

        public delegate void LoadDataChangeHandler(object sender, EventArgs e);
        public event LoadDataChangeHandler LoadDataChange;
        bool _isError = false;

        #endregion
        public frmWorkingDiaries()
        {
            InitializeComponent();
        }

        private void frmWorkingDiaries_Load(object sender, EventArgs e)
        {
            loadLocation();
            loadUser();
            loadProject();
            loadPhongBan();
            loadModule();

            if (WorkingDiaries.ID > 0)
            {
                cboProject.EditValue = WorkingDiaries.ProjectId;
                cboUser.EditValue = WorkingDiaries.UserId;
                cboStatus.SelectedIndex = WorkingDiaries.Status;
                cboPhongBan.EditValue = WorkingDiaries.DepartmentId;
                cboModule.EditValue = WorkingDiaries.ModuleCode;

                dtpEndTime.EditValue = WorkingDiaries.EndTime;
                dtpStartTime.EditValue = WorkingDiaries.StartTime;
                dtpWorkingDate.EditValue = WorkingDiaries.WorkingDate;

                txtNote.Text = WorkingDiaries.Note;
                txtWorkingContent.Text = WorkingDiaries.WorkingContent;
                txtWorkPercent.EditValue = WorkingDiaries.WorkPercent;
                txtWorkTime.EditValue = WorkingDiaries.WorkTime;
                txtProjectCode.Text = WorkingDiaries.ProjectCode;
                txtProjectName.Text = WorkingDiaries.ProjectName;
                txtUserCode.Text = WorkingDiaries.UserCode;
                txtUserName.Text = WorkingDiaries.UserName;
                txtModuleCode.Text = WorkingDiaries.ModuleCode;
                txtModuleName.Text = WorkingDiaries.ModuleName;

                chkKhongAnToi.Checked = WorkingDiaries.IsAnToi;
                chkKhongNghiTrua.Checked = WorkingDiaries.IsNghiTrua;

                cboLocation.SelectedValue = WorkingDiaries.WorkingDiariesLocationID;

                loadData();
            }
            else
            {
                dtpWorkingDate.EditValue = DateTime.Now;
            }

            if (cboStatus.SelectedIndex == 1 || cboStatus.SelectedIndex == 4 || cboStatus.SelectedIndex == 5)
            {
                chkKhongNghiTrua.Visible = true;
            }
            else
            {
                chkKhongNghiTrua.Visible = false;
            }

            if (cboStatus.SelectedIndex == 2 || cboStatus.SelectedIndex == 4 || cboStatus.SelectedIndex == 5)
            {
                chkKhongAnToi.Visible = true;
            }
            else
            {
                chkKhongAnToi.Visible = false;
            }


            //if (cboStatus.SelectedIndex == 1 || cboStatus.SelectedIndex == 4 || cboStatus.SelectedIndex == 5)
            //{
            //    chkKhongNghiTrua.Visible = true;
            //}
            //else
            //{
            //    chkKhongNghiTrua.Visible = false;
            //}

            //chkKhongAnToi.Visible = cboStatus.SelectedIndex == 2;

            //if (!TextUtils.HasPermission("frmWorkingDiariesManager_AddAll"))
            //{
            //    UsersModel user = (UsersModel)UsersBO.Instance.FindByAttribute("Account", Global.AppUserName)[0];
            //    cboUser.EditValue = user.UserId;
            //    cboUser.Enabled = false;

            //    txtUserCode.Text = user.Code;
            //    txtUserName.Text = user.UserName;
            //}
        }

        void loadLocation()
        {
            DataTable dt = LibQLSX.Select("select * from WorkingDiariesLocation with(nolock)");
            cboLocation.DataSource = dt;
            cboLocation.ValueMember = "ID";
            cboLocation.DisplayMember = "Name";
        }
        void loadUser()
        {
            DataTable dt = LibQLSX.Select("select * from vUser with(nolock) where Code is not null order by Code");
            cboUser.Properties.DataSource = dt;
            cboUser.Properties.ValueMember = "UserId";
            cboUser.Properties.DisplayMember = "UserName";
        }

        void loadPhongBan()
        {
            DataTable dt = LibQLSX.Select("select * from Departments with(nolock) order by DName");
            cboPhongBan.Properties.DataSource = dt;
            cboPhongBan.Properties.ValueMember = "DepartmentId";
            cboPhongBan.Properties.DisplayMember = "DName";
        }

        void loadProject()
        {
            try
            {
                DataTable dt = LibQLSX.Select("select * from Project with(nolock)");
                cboProject.Properties.DataSource = dt;
                cboProject.Properties.ValueMember = "ProjectId";
                cboProject.Properties.DisplayMember = "ProjectCode";
                //TextUtils.PopulateCombo(cboProject, tbl, "ProjectCode", "ProjectId", "");
            }
            catch (Exception ex)
            {
            }
        }

        void loadModule()
        {
            DataTable tbl = TextUtils.Select("select * from Modules with(nolock) where Code like 'TPAD%' order by Code");
            //TextUtils.PopulateCombo(cboModule, tbl, "Name", "ID", "");
            cboModule.Properties.DataSource = tbl;
            cboModule.Properties.ValueMember = "Code";
            cboModule.Properties.DisplayMember = "Code";
        }

        private void cboUser_EditValueChanged(object sender, EventArgs e)
        {
            loadData();
            string departmentID = TextUtils.ToString(grvCboUser.GetFocusedRowCellValue(colDepartmentId));
            cboPhongBan.EditValue = departmentID;
            txtUserCode.Text = TextUtils.ToString(grvCboUser.GetFocusedRowCellValue(colUserCode));
            txtUserName.Text = TextUtils.ToString(grvCboUser.GetFocusedRowCellValue(colUserName));
        }

        private void cboProject_EditValueChanged(object sender, EventArgs e)
        {
            txtProjectCode.Text = TextUtils.ToString(grvCboProject.GetFocusedRowCellValue(colProjectCode));
            txtProjectName.Text = TextUtils.ToString(grvCboProject.GetFocusedRowCellValue(colProjectName));
        }

        bool ValidateForm()
        {
            //if (!TextUtils.HasPermission("frmWorkingDiariesManager_IsApproved") && cboStatus.SelectedIndex > 1)
            //{
            //    MessageBox.Show("Bạn chỉ có quyền nhập nhật ký công việc thời gian hành chính.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    return false;
            //}

            if (WorkingDiaries.IsApproved)
            {
                MessageBox.Show("Nhật ký công việc đã được duyệt, bạn không thể sửa được nữa.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (cboPhongBan.EditValue == null)
            {
                MessageBox.Show("Xin hãy chọn một phòng ban.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (cboUser.EditValue == null)
            {
                MessageBox.Show("Xin hãy chọn một nhân viên.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (txtUserCode.Text.Trim() == "")
            {
                MessageBox.Show("Nhân viên chưa có mã.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (txtProjectCode.Text.Trim() == "" && cboStatus.SelectedIndex != 8)
            {
                MessageBox.Show("Dự án chưa có mã.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
             
            if (cboProject.EditValue == null && cboStatus.SelectedIndex != 8)
            {
                MessageBox.Show("Xin hãy chọn một dự án.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (cboStatus.SelectedIndex <= 0)
            {
                MessageBox.Show("Xin hãy chọn một trạng thái.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (dtpWorkingDate.EditValue == null)
            {
                MessageBox.Show("Bạn chưa điền ngày làm việc.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (dtpStartTime.EditValue == null)
            {
                MessageBox.Show("Bạn chưa điền thời gian bắt đầu.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (dtpEndTime.EditValue == null)
            {
                MessageBox.Show("Bạn chưa điền thời gian kết thúc.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (TextUtils.ToString(cboModule.EditValue) == "")
            {
                MessageBox.Show("Bạn chưa chọn một module.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (TextUtils.ToDecimal(txtWorkTime.EditValue) == 0)
            {
                MessageBox.Show("Bạn chưa điền tổng thời gian.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (txtWorkingContent.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa điền nội dung công việc.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (TextUtils.ToDecimal(txtWorkTime.EditValue) <= 0)
            {
                MessageBox.Show("Thời gian làm việc phải lớn hơn 0.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (TextUtils.ToInt(cboLocation.SelectedValue) == 0)
            {
                 MessageBox.Show("Bạn chưa chọn một địa điểm làm việc.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            //1.Thời gian hành chính (8:00 - 17:00)
            //2.Tăng ca tối, thường (17:30 - 22:00, 6:00 - 8:00)
            //3.Tăng ca đêm ngày thường (22:00 - 6:00)
            //4.Tăng ca ngày nghỉ (6:00 - 22:00)
            //5.Tăng ca ngày lễ  (6:00 - 22:00)
            //6.Tăng ca đêm ngày nghỉ (22:00 - 6:00)
            //7.Tăng ca đêm ngày lễ (22:00 - 6:00)
            //8.Nghỉ phép (8:00 - 17:00)
            //9.Nghỉ không lương (8:00 - 17:00)
            //10.Nghỉ chế độ (8:00 - 17:00)

            //List<int> listHour = new List<int>(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23 });

            DateTime cDate = (DateTime)dtpWorkingDate.EditValue;
            DateTime startDate = new DateTime(cDate.Year, cDate.Month, cDate.Day, TextUtils.ToDate3(dtpStartTime.EditValue).Hour, TextUtils.ToDate3(dtpStartTime.EditValue).Minute, 0);
            DateTime endDate = new DateTime(cDate.Year, cDate.Month, cDate.Day, TextUtils.ToDate3(dtpEndTime.EditValue).Hour, TextUtils.ToDate3(dtpEndTime.EditValue).Minute, 0);
            string sql = "";
            if (WorkingDiaries.ID > 0)
            {
                sql = "select top 1 ID from WorkingDiaries where ((StartTime <= '" + startDate.ToString("yyyy-MM-dd HH:mm") + "' and EndTime > '" + startDate.ToString("yyyy-MM-dd HH:mm") + "') or "
                    + "(StartTime < '" + endDate.ToString("yyyy-MM-dd HH:mm") + "' and EndTime >= '" + endDate.ToString("yyyy-MM-dd HH:mm") + "')) "
                    //+ "and (DATEDIFF(day, '" + cDate.ToString("yyyy-MM-dd") + "', WorkingDate) = 0 "
                    + "and UserId = '" + TextUtils.ToString(cboUser.EditValue) + "' and ID <> " + WorkingDiaries.ID;
            }
            else
            {
                sql = "select top 1 ID from WorkingDiaries where ((StartTime <= '" + startDate.ToString("yyyy-MM-dd HH:mm") + "' and EndTime > '" + startDate.ToString("yyyy-MM-dd HH:mm") + "') or "
                        + "(StartTime < '" + endDate.ToString("yyyy-MM-dd HH:mm") + "' and EndTime >= '" + endDate.ToString("yyyy-MM-dd HH:mm") + "')) "
                        //+ "and (DATEDIFF(day, '" + cDate.ToString("yyyy-MM-dd") + "', WorkingDate) = 0 "
                        + "and UserId = '" + TextUtils.ToString(cboUser.EditValue) + "'";
            }

            DataTable dt = LibQLSX.Select(sql);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Khung thời gian đang bị trùng lặp.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (cboStatus.SelectedIndex == 1 || cboStatus.SelectedIndex == 8 || cboStatus.SelectedIndex == 9 || cboStatus.SelectedIndex == 10)
            {
                List<int> listHour = new List<int>(new int[] {8, 9, 10, 11, 12, 13, 14, 15, 16, 17});
                if (!listHour.Contains(startDate.Hour) || !listHour.Contains(endDate.Hour) || startDate.Hour > endDate.Hour 
                    || (endDate.Hour == 17 && endDate.Minute > 0)
                    || (startDate.Hour == 11 && startDate.Minute > 30)
                    || (startDate.Hour == 12 && startDate.Minute < 30)
                    || (endDate.Hour == 11 && endDate.Minute > 30)
                    || (endDate.Hour == 12 && endDate.Minute < 30)
                    )
                {
                    MessageBox.Show("Thời gian bắt đầu hoặc thời gian kết thúc không hợp lệ.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return false;
                }
            }

            if (cboStatus.SelectedIndex == 2)
            {
                List<int> listHour = new List<int>(new int[] {6,7,8, 17, 18, 19, 20, 21, 22 });
                if (!listHour.Contains(startDate.Hour) || !listHour.Contains(endDate.Hour) || startDate.Hour > endDate.Hour || (startDate.Hour == 17 && startDate.Minute < 30))
                {
                    MessageBox.Show("Thời gian bắt đầu hoặc thời gian kết thúc không hợp lệ.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return false;
                }
            }

            if (cboStatus.SelectedIndex == 4 || cboStatus.SelectedIndex == 5)
            {
                List<int> listHour = new List<int>(new int[] { 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22 });
                if (!listHour.Contains(startDate.Hour) || !listHour.Contains(endDate.Hour) || startDate.Hour > endDate.Hour 
                    || (endDate.Hour == 22 && endDate.Minute > 0)
                    || (startDate.Hour == 11 && startDate.Minute > 30)
                    || (startDate.Hour == 12 && startDate.Minute < 30)
                    || (endDate.Hour == 11 && endDate.Minute > 30)
                    || (endDate.Hour == 12 && endDate.Minute < 30)
                    )
                {
                    MessageBox.Show("Thời gian bắt đầu hoặc thời gian kết thúc không hợp lệ.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return false;
                }
            }

            if (cboStatus.SelectedIndex == 3 || cboStatus.SelectedIndex == 6 || cboStatus.SelectedIndex == 7)
            {
                List<int> listHour = new List<int>(new int[] { 0, 1, 2, 3, 4, 5, 6, 22, 23 });
                if (!listHour.Contains(startDate.Hour) || !listHour.Contains(endDate.Hour) || (endDate.Hour == 6 && endDate.Minute > 0))
                {
                    MessageBox.Show("Thời gian bắt đầu hoặc thời gian kết thúc không hợp lệ.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return false;
                }
            }

            if (cboStatus.SelectedIndex == 7 || cboStatus.SelectedIndex == 6)
            {
                if (endDate.Hour - startDate.Hour < 0)
                {
                    MessageBox.Show("Thời gian bắt đầu hoặc thời gian kết thúc không hợp lệ.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return false;
                }
            }

            return true;
        }

        void loadControl()
        {
            if (Global.AppUserName.ToLower() != "thao.nv")
            {
                cboProject.EditValue = null;
                //cboStatus.SelectedIndex = 0;

                dtpEndTime.EditValue = null;
                dtpStartTime.EditValue = null;
                dtpWorkingDate.EditValue = null;

                txtNote.Text = "";
                txtWorkingContent.Text = "";
                txtWorkPercent.EditValue = 100;
                txtWorkTime.EditValue = null;
                txtProjectCode.Text = "";
                txtProjectName.Text = "";
                //txtUserCode.Text = "";
                //txtUserName.Text = "";
            }

            chkKhongAnToi.Checked = chkKhongNghiTrua.Checked = false;

            WorkingDiaries = new WorkingDiariesModel();
        }

        
        void save()
        {
            grvData.Focus();

            ProcessTransaction pt = new ProcessTransaction();
            pt.OpenConnection();
            pt.BeginTransaction();

            try
            {
                if (!ValidateForm())
                {
                    _isError = true;
                    return;
                }

                WorkingDiaries.UserId = TextUtils.ToString(cboUser.EditValue);
                WorkingDiaries.UserName = txtUserName.Text.Trim();
                WorkingDiaries.UserCode = txtUserCode.Text.Trim();
                WorkingDiaries.DepartmentId = TextUtils.ToString(cboPhongBan.EditValue);
                WorkingDiaries.ProjectId = TextUtils.ToString(cboProject.EditValue);
                WorkingDiaries.ProjectCode = txtProjectCode.Text.Trim();
                WorkingDiaries.ProjectName = txtProjectName.Text.Trim();
                WorkingDiaries.ModuleCode = txtModuleCode.Text.Trim();
                WorkingDiaries.ModuleName = txtModuleName.Text.Trim();

                WorkingDiaries.WorkingContent = txtWorkingContent.Text.Trim();
                DateTime cDate = TextUtils.ToDate3(dtpWorkingDate.EditValue);
                WorkingDiaries.WorkingDate = cDate;
                WorkingDiaries.StartTime = new DateTime(cDate.Year, cDate.Month, cDate.Day, TextUtils.ToDate3(dtpStartTime.EditValue).Hour, TextUtils.ToDate3(dtpStartTime.EditValue).Minute, 0);
                if (Global.AppUserName.ToLower() == "hien.n")
                { }
                else if (!validateTimeStart(WorkingDiaries.StartTime.Value))
                {
                    MessageBox.Show("Không thể nhập nhật ký do quá thời hạn.(Chậm nhất là mùng 2 tháng kế tiếp)", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    pt.CloseConnection();
                    return;
                }
                WorkingDiaries.EndTime = new DateTime(cDate.Year, cDate.Month, cDate.Day, TextUtils.ToDate3(dtpEndTime.EditValue).Hour, TextUtils.ToDate3(dtpEndTime.EditValue).Minute, 0);
                WorkingDiaries.WorkTime = TextUtils.ToDecimal(txtWorkTime.EditValue);

                WorkingDiaries.Status = cboStatus.SelectedIndex;
                WorkingDiaries.Note = txtNote.Text.Trim();

                //WorkingDiaries.IsApproved = txtName.Text.Trim();
                WorkingDiaries.IsNghiTrua = chkKhongNghiTrua.Checked;
                WorkingDiaries.IsAnToi = chkKhongAnToi.Checked;
                WorkingDiaries.WorkPercent = TextUtils.ToDecimal(txtWorkPercent.EditValue);
                WorkingDiaries.WorkingDiariesLocationID = TextUtils.ToInt(cboLocation.SelectedValue);
               
                WorkingDiaries.UpdatedBy = Global.AppUserName;
                WorkingDiaries.UpdatedDate = DateTime.Now;

                if (WorkingDiaries.ID == 0)
                {
                    WorkingDiaries.CreatedBy = Global.AppUserName;
                    WorkingDiaries.CreatedDate = DateTime.Now;
                    WorkingDiaries.ID = (int)pt.Insert(WorkingDiaries);
                }
                else
                {
                    pt.Update(WorkingDiaries);
                }

                pt.CommitTransaction();

                _isSaved = true;
                loadData();

                MessageBox.Show("Lưu trữ thành công!", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                _isError = false;

                if (this.LoadDataChange != null)
                {
                    this.LoadDataChange(null, null);
                }
            }
            catch (Exception ex)
            {
                _isError = true;
                MessageBox.Show(ex.Message, TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                pt.CloseConnection();
            }
        }

        bool validateTimeStart(DateTime time)
        {
            bool valid = true;
            if ((DateTime.Now.Year - time.Year) > 1)
            {
                return false;
            }
            if ((DateTime.Now.Year - time.Year) == 1)
            {
                if (time.Month < 12)
                {
                    return false;
                }
                if (DateTime.Now.Month > 1)
                {
                    return false;
                }
                if (DateTime.Now.Day > 2)
                {
                    return false;
                }
            }
            if ((DateTime.Now.Year - time.Year) == 0)
            {
                if((DateTime.Now.Month - time.Month) > 1)
                {
                    return false;
                }
                if ((DateTime.Now.Month - time.Month) == 1)
                {
                    if (DateTime.Now.Day > 2)
                    {
                        return false;
                    }
                }
            }
            return valid;
        }

        void loadData()
        {
            if (dtpWorkingDate.EditValue == null) return;
            //if (dtpWorkingDate.EditValue == null) return;
            if (cboUser.EditValue == null) return;

            string[] _paraName = new string[4];
            object[] _paraValue = new object[4];
            _paraName[0] = "@StartDate"; _paraValue[0] = TextUtils.ToDate2(dtpWorkingDate.EditValue);
            _paraName[1] = "@EndDate"; _paraValue[1] = TextUtils.ToDate2(dtpWorkingDate.EditValue);
            _paraName[2] = "@UserId"; _paraValue[2] = TextUtils.ToString(cboUser.EditValue);
            _paraName[3] = "@DepartmentId"; _paraValue[3] = "";
            DataTable Source = LibQLSX.LoadDataFromSP("spGetWorkingDiaries1", "Source", _paraName, _paraValue);

            grdData.DataSource = Source;
        }

        void loadTotalTime()
        {
            //decimal totalTime = 0;
            if (cboStatus.SelectedIndex <= 0 || dtpWorkingDate.EditValue == null || dtpEndTime.EditValue == null || dtpStartTime.EditValue == null)
            {
                txtWorkTime.EditValue = 0;
            }
            else
            {
                //---Chọn-----
                //1.Thời gian hành chính (8:00 - 17:00)
                //2.Tăng ca tối, thường (17:30 - 22:00, 6:00 - 8:00)
                //3.Tăng ca đêm  ngày thường (22:00 - 6:00)
                //4.Tăng ca ngày nghỉ (6:00 - 22:00)
                //5.Tăng ca ngày lễ  (6:00 - 22:00)
                //6.Tăng ca đêm ngày nghỉ (22:00 - 6:00)
                //7.Tăng ca đêm ngày lễ (22:00 - 6:00)
                //8.Nghỉ phép  (8:00 - 17:00)
                //9.Nghỉ không lương  (8:00 - 17:00)
                //10.Nghỉ chế độ  (8:00 - 17:00)

                DateTime startDate = (DateTime)dtpStartTime.EditValue;
                DateTime endDate = (DateTime)dtpEndTime.EditValue;

                if (cboStatus.SelectedIndex == 1 || cboStatus.SelectedIndex == 4 || cboStatus.SelectedIndex == 5
                    || cboStatus.SelectedIndex == 8 || cboStatus.SelectedIndex == 9 || cboStatus.SelectedIndex == 10)
                {
                    TimeSpan priod = endDate - startDate;
                    double hour = 0;
                    //if (startDate.Hour <= 11 && startDate.Minute <= 30 && endDate.Hour >= 12)
                    if (startDate.Hour <= 11 && endDate.Hour >= 12)
                    {
                        hour = priod.TotalHours - 1;
                    }
                    else
                    {
                        hour = priod.TotalHours;
                    }
                    if (chkKhongNghiTrua.Checked) hour += 1;
                    if ((cboStatus.SelectedIndex == 4 || cboStatus.SelectedIndex == 5) && (endDate.Hour > 17 || (endDate.Hour == 17 && endDate.Minute > 30)))
                    {
                        if (!chkKhongAnToi.Checked) hour -= 0.5;
                    }
                    txtWorkTime.EditValue = hour;
                }

                if (cboStatus.SelectedIndex == 2)//Tăng ca tối
                {
                    TimeSpan priod = endDate - startDate;
                    if (endDate.Hour < 17)
                    {
                        txtWorkTime.EditValue = priod.TotalHours;
                    }
                    else
                    {
                        txtWorkTime.EditValue = priod.TotalHours + (chkKhongAnToi.Checked ? 0.5 : 0);
                    }
                }

                if (cboStatus.SelectedIndex == 3 || cboStatus.SelectedIndex == 6 || cboStatus.SelectedIndex == 7)//Tăng ca đêm
                {
                    if (endDate.Hour >= 22 || (startDate.Hour >= 0 && startDate.Hour <= 21))
                    {
                        TimeSpan priod = endDate - startDate;
                        double hour = priod.TotalHours + (endDate.Minute == 59 ? 1.00 / 60.00 : 0);
                        txtWorkTime.EditValue = Math.Round(hour, 2);
                    }
                    else
                    {
                        DateTime midNight = new DateTime(endDate.Year, endDate.Month, endDate.Day, 0, 0, 0).AddDays(1);
                        DateTime mid1 = new DateTime(endDate.Year, endDate.Month, endDate.Day, 0, 0, 0);
                        TimeSpan priod1 = midNight - startDate;
                        TimeSpan priod2 = endDate - mid1;

                        txtWorkTime.EditValue = priod1.TotalHours + priod2.TotalHours;
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            save();
        }

        private void btnSaveAndClose_Click(object sender, EventArgs e)
        {
            save();
            if (!_isError)
            {
                this.Close();
            }
        }

        private void btnSaveAndNext_Click(object sender, EventArgs e)
        {
            save();
            if (!_isError)
            {
                loadControl();
            }
        }        

        private void cboUser_Enter(object sender, EventArgs e)
        {
            //loadData();
        }

        private void dtpWorkingDate_EditValueChanged(object sender, EventArgs e)
        {
            loadTotalTime();
            loadData();
        }        

        private void dtpEndTime_EditValueChanged(object sender, EventArgs e)
        {
            loadTotalTime();
        }

        private void cboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboStatus.SelectedIndex == 1 || cboStatus.SelectedIndex == 4 || cboStatus.SelectedIndex == 5)
            {
                chkKhongNghiTrua.Visible = true;                
            }
            else
            {
                chkKhongNghiTrua.Visible = false;
            }

            if ( cboStatus.SelectedIndex == 2 || cboStatus.SelectedIndex == 4 || cboStatus.SelectedIndex == 5)
            {
                chkKhongAnToi.Visible = true;
            }
            else
            {
                chkKhongAnToi.Visible = false;
            }

            //chkKhongAnToi.Visible = cboStatus.SelectedIndex == 2;

            loadTotalTime();
        }

        private void dtpStartTime_EditValueChanged(object sender, EventArgs e)
        {
            loadTotalTime();
        }

        private void txtWorkTime_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void chkKhongAnCom_CheckedChanged(object sender, EventArgs e)
        {
            loadTotalTime();
        }

        private void grvData_DoubleClick(object sender, EventArgs e)
        {
            int id = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
            if (id == 0) return;

            WorkingDiaries = (WorkingDiariesModel)WorkingDiariesBO.Instance.FindByPK(id);
            if (WorkingDiaries.ID > 0)
            {
                cboProject.EditValue = WorkingDiaries.ProjectId;
                cboUser.EditValue = WorkingDiaries.UserId;
                cboStatus.SelectedIndex = WorkingDiaries.Status;
                cboPhongBan.EditValue = WorkingDiaries.DepartmentId;

                dtpEndTime.EditValue = WorkingDiaries.EndTime;
                dtpStartTime.EditValue = WorkingDiaries.StartTime;
                dtpWorkingDate.EditValue = WorkingDiaries.WorkingDate;

                txtNote.Text = WorkingDiaries.Note;
                txtWorkingContent.Text = WorkingDiaries.WorkingContent;
                txtWorkPercent.EditValue = WorkingDiaries.WorkPercent;
                txtWorkTime.EditValue = WorkingDiaries.WorkTime;
                txtProjectCode.Text = WorkingDiaries.ProjectCode;
                txtProjectName.Text = WorkingDiaries.ProjectName;
                txtUserCode.Text = WorkingDiaries.UserCode;
                txtUserName.Text = WorkingDiaries.UserName;

                chkKhongAnToi.Checked = WorkingDiaries.IsAnToi;
                chkKhongNghiTrua.Checked = WorkingDiaries.IsNghiTrua;
                //loadData();
            }
        }

        private void chkKhongAnToi_CheckedChanged(object sender, EventArgs e)
        {
            loadTotalTime();
        }

        private void cboModule_EditValueChanged(object sender, EventArgs e)
        {
            txtModuleCode.Text = TextUtils.ToString(grvCboModule.GetFocusedRowCellValue(colModuleCode));
            txtModuleName.Text = TextUtils.ToString(grvCboModule.GetFocusedRowCellValue(colModuleName));
        }

        private void btnIsApproved_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn duyệt nhật ký công việc này không?",
                      TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            foreach (int i in grvData.GetSelectedRows())
            {
                int id = TextUtils.ToInt(grvData.GetRowCellValue(i, colID));
                WorkingDiariesModel d = (WorkingDiariesModel)WorkingDiariesBO.Instance.FindByPK(id);
                d.IsApproved = true;
                WorkingDiariesBO.Instance.Update(d);
            }

            loadData();

            if (this.LoadDataChange != null)
            {
                this.LoadDataChange(null, null);
            }
        }
    }
}
