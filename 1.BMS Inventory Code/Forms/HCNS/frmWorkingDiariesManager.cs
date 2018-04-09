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
using Excel = Microsoft.Office.Interop.Excel;

namespace BMS
{
    public partial class frmWorkingDiariesManager : _Forms
    {
        int _rownIndex = 0; 
        int type = 0;
        public frmWorkingDiariesManager()
        {
            InitializeComponent();
        }

        private void frmWorkingDiariesManager_Load(object sender, EventArgs e)
        {
            loadDepartment();
            loadUser();
            dtpEndDate.EditValue = dtpStartDate.EditValue = DateTime.Now;
        }

        void loadUser()
        {
            //DataTable dt = LibQLSX.Select("select * from vUser with(nolock)");
            //grdUser.DataSource = dt;
        }

        void loadDepartment()
        {
            DataTable dt = LibQLSX.Select("select * from Departments with(nolock)");
            cboDepartment.Properties.DataSource = dt;
            cboDepartment.Properties.ValueMember = "DepartmentId";
            cboDepartment.Properties.DisplayMember = "DName";
        }

        void main_LoadDataChange(object sender, EventArgs e)
        {
            btnXemTatCa_Click(null, null);
        }

        void loadGrid()
        {
            DataTable dt = LibQLSX.Select("select top 1 * from vChucVu where Account = '" + Global.LoginName + "'");
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Tài khoản trên QLSX và quản lý thiết kế của bạn đang khác nhau", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            string[] _paraName = new string[6];
            object[] _paraValue = new object[6];
            _paraName[0] = "@StartDate"; _paraValue[0] = TextUtils.ToDate2(dtpStartDate.EditValue);
            _paraName[1] = "@EndDate"; _paraValue[1] = TextUtils.ToDate2(dtpEndDate.EditValue);
            _paraName[2] = "@UserId"; _paraValue[2] = TextUtils.ToString(dt.Rows[0]["UserId"]);
            _paraName[3] = "@DepartmentId"; _paraValue[3] = TextUtils.ToString(cboDepartment.EditValue);
            _paraName[4] = "@GroupUserId";
            _paraName[5] = "@LeaderId";
            if (TextUtils.HasPermission("frmWorkingDiariesManager_ViewAll"))
            {
                _paraValue[2] = "1";
                _paraValue[4] = "";
                _paraValue[5] = "";
            }
            else
            {                
                string departmentCode = TextUtils.ToString(dt.Rows[0]["DCode"]);
                string groupCode = TextUtils.ToString(dt.Rows[0]["GroupCode"]);
                if (departmentCode == "" && groupCode == "")
                {
                    _paraValue[4] = "0";
                    _paraValue[5] = "0"; 
                }
                else
                {
                    _paraValue[4] = groupCode != "" ? TextUtils.ToString(dt.Rows[0]["UserId"]) : "";
                    _paraValue[5] = departmentCode != "" ? TextUtils.ToString(dt.Rows[0]["UserId"]) : "";    
                }
            }
            
            DataTable Source = LibQLSX.LoadDataFromSP("spGetWorkingDiaries", "Source", _paraName, _paraValue);

            grdData.DataSource = Source;
        }
        private void btnXemTatCa_Click(object sender, EventArgs e)
        {
            loadGrid();
           
            type = 2;
        }
        private void btnFindAll_Click(object sender, EventArgs e)
        {            
            loadGrid();
            //Focus con trỏ chuột tại dòng đã select khi load lại dữ liệu
            if (_rownIndex >= grvData.RowCount)
                _rownIndex = 0;
            if (_rownIndex > 0)
                grvData.FocusedRowHandle = _rownIndex;
            grvData.SelectRow(_rownIndex);

            type = 1;
        }

        private void grvUser_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            btnFindAll_Click(null, null);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DataTable dt = LibQLSX.Select("select top 1 UserId from Users where Account = '" + Global.AppUserName + "'");
            if (dt.Rows.Count <= 0)
            { 
                MessageBox.Show("Bạn chưa có tài khoản trên phần mềm quản lý sản xuất.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            
            frmWorkingDiaries frm = new frmWorkingDiaries();
            frm.LoadDataChange += main_LoadDataChange;
            frm.Show();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int id = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
            if (id == 0) return;
            WorkingDiariesModel model = (WorkingDiariesModel)WorkingDiariesBO.Instance.FindByPK(id);
            if (model.IsApproved)
            {
                MessageBox.Show("Nhật ký công việc đã được duyệt, bạn không thể sửa được.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            DataTable dt = LibQLSX.Select("select top 1 UserId from Users where Account = '" + Global.AppUserName + "'");
            if (dt.Rows.Count <= 0)
            {
                MessageBox.Show("Bạn chưa có tài khoản trên phần mềm quản lý sản xuất.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            else
            {
                if (!TextUtils.HasPermission("frmWorkingDiariesManager_AddAll"))
                {
                    string account = TextUtils.ToString(grvData.GetFocusedRowCellValue(colAccount1));
                    if (account.ToUpper() != Global.AppUserName.ToUpper())
                    {
                        MessageBox.Show("Bạn không có quyền sửa nhật ký công việc này.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                }
            }
           
            _rownIndex = grvData.FocusedRowHandle;
            frmWorkingDiaries frm = new frmWorkingDiaries();
            frm.WorkingDiaries = model;
            frm.LoadDataChange += main_LoadDataChange;
            frm.Show();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            int id = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
            if (id == 0) return;
            WorkingDiariesModel model = (WorkingDiariesModel)WorkingDiariesBO.Instance.FindByPK(id);
            if (model.IsApproved)
            {
                MessageBox.Show("Nhật ký công việc đã được duyệt, bạn không thể xóa được.", TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            //ProcessTransaction pt = new ProcessTransaction();
            //pt.OpenConnection();
            //pt.BeginTransaction();
            //try
            //{
                if (MessageBox.Show("Bạn có chắc muốn xóa nhật ký công việc này không?",
                    TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;
                WorkingDiariesBO.Instance.Delete(id);

                //pt.CommitTransaction();
                btnFindAll_Click(null, null);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, TextUtils.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //finally
            //{
            //    pt.CloseConnection();
            //}
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (grvData.RowCount > 0)
                {
                    TextUtils.ExportExcel(grvData);
                }
            }
            catch (Exception)
            {
            }
        }      

        private void btnIsApproved_Click(object sender, EventArgs e)
        {
            _rownIndex = grvData.FocusedRowHandle;
            if (MessageBox.Show("Bạn có chắc muốn duyệt những nhật ký công việc này không?",
                      TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return; 
            foreach (int i in grvData.GetSelectedRows())
            {
                int id = TextUtils.ToInt(grvData.GetRowCellValue(i, colID));
                WorkingDiariesModel d = (WorkingDiariesModel)WorkingDiariesBO.Instance.FindByPK(id);
                d.IsApproved = true;
                WorkingDiariesBO.Instance.Update(d);
            }
            if (type == 1)
            {
                btnFindAll_Click(null, null);
            }
            if (type == 2)
            {
                btnXemTatCa_Click(null, null);
            }
        }

        private void hủyDuyệtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _rownIndex = grvData.FocusedRowHandle;
            if (MessageBox.Show("Bạn có chắc muốn hủy duyệt những nhật ký công việc này không?",
                      TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            foreach (int i in grvData.GetSelectedRows())
            {
                int id = TextUtils.ToInt(grvData.GetRowCellValue(i, colID));
                WorkingDiariesModel d = (WorkingDiariesModel)WorkingDiariesBO.Instance.FindByPK(id);
                d.IsApproved = false;
                WorkingDiariesBO.Instance.Update(d);
            }
            if (type == 1)
            {
                btnFindAll_Click(null, null);
            }
            if (type == 2)
            {
                btnXemTatCa_Click(null, null);
            }
        }

        private void grvData_DoubleClick(object sender, EventArgs e)
        {
            btnEdit_Click(null, null);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            frmReport_NKCV_ForDate frm = new frmReport_NKCV_ForDate();
            TextUtils.OpenForm(frm);
        }

        private void btnLocation_Click(object sender, EventArgs e)
        {
            frmWorkingDiariesLocation frm = new frmWorkingDiariesLocation();
            TextUtils.OpenForm(frm);
        }
    }
}
