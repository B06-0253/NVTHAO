using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.Utils;
using BMS.Model;
using BMS.Business;
using DevExpress.XtraGrid.Views.Grid;

namespace BMS
{
    public partial class frmWorkDiaryManager : _Forms
    {
        int _rownIndex = 0;
        bool isViewAll = false;
        DataTable _dtData = new DataTable();

        public frmWorkDiaryManager()
        {
            InitializeComponent();
        }

        //void loadUser()
        //{
        //    DataTable dt = TextUtils.Select("Select * from vUserInfo WITH(NOLOCK)");

        //    repositoryItemLookUpEdit1.DataSource = dt;
        //    repositoryItemLookUpEdit1.DisplayMember = "UserName";
        //    repositoryItemLookUpEdit1.ValueMember = "UserId";
        //}
        
        void LoadInfoSearch()
        {
            using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang load dữ liệu..."))
            {
                try
                {                    
                    if (isViewAll)
                    {
                        _dtData = TextUtils.Select("select * from vTheoDoi with(nolock)" + (chkNotComplete.Checked ? " where Status = 0" : ""));
                    }
                    else
                    {
                        _dtData = TextUtils.Select("select * from vTheoDoi with(nolock) where UserID = " + 
                            Global.UserID + (chkNotComplete.Checked ? " and Status = 0" : ""));
                    }

                    grdData.DataSource = _dtData;
                    if (_rownIndex >= grvData.RowCount)
                        _rownIndex = 0;
                    if (_rownIndex > 0)
                        grvData.FocusedRowHandle = _rownIndex;
                    grvData.SelectRow(_rownIndex);
                    grvData.BestFitColumns();
                }
                catch
                {
                }
            }
        }

        void main_LoadDataChange(object sender, EventArgs e)
        {
            LoadInfoSearch();
        }

        private void frmWorkDiaryManager_Load(object sender, EventArgs e)
        {
            //loadUser();
            //LoadInfoSearch();
            DataTable dt = TextUtils.Select("select * from vCheckPermission where Code = 'frmTheoDoiCongViec_ViewAll' and UserID = " + Global.UserID);
            isViewAll = dt.Rows.Count > 0;
            chkNotComplete.Checked = true;
            if (!isViewAll)
            {
                colDepartment.GroupIndex = -1;
                colNguoiPhuTrach.GroupIndex = -1;
                colDepartment.Visible = false;
                colNguoiPhuTrach.Visible = false;
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmWorkDiary frm = new frmWorkDiary();
            frm.LoadDataChange += main_LoadDataChange;
            frm.Show();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            int userID = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colUserID));
            if (userID != Global.UserID)
            {
                MessageBox.Show("Bạn không có quyền sửa công việc này?", TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                return;
            }
            long id = TextUtils.ToInt64(grvData.GetFocusedRowCellValue(colID));
            if (id == 0) return;
            TheoDoiModel model = (TheoDoiModel)TheoDoiBO.Instance.FindByPK(id);
            _rownIndex = grvData.FocusedRowHandle;

            frmWorkDiary frm = new frmWorkDiary();
            frm.WorkDiary = model;
            frm.LoadDataChange += main_LoadDataChange;
            frm.Show();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int userID = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colUserID));
            if (userID != Global.UserID)
            {
                MessageBox.Show("Bạn không có quyền xóa công việc này?", TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                return;
            }
            int id = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colID));
            if (id == 0) return;
            if (MessageBox.Show("Bạn có chắc muốn xóa công việc này không?",
                      TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            TheoDoiBO.Instance.Delete(id);
            LoadInfoSearch();
        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
            int userID = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colUserID));
            if (userID != Global.UserID)
            {
                MessageBox.Show("Bạn không có quyền sửa công việc này?", TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                return;
            }
            if (grvData.SelectedRowsCount == 0) return;
            foreach (int i in grvData.GetSelectedRows())
            {
                int id = TextUtils.ToInt(grvData.GetRowCellValue(i, colID));
                int status = TextUtils.ToInt(grvData.GetRowCellValue(i, colStatus));
                if (status == 1) continue;
                TheoDoiModel model = (TheoDoiModel)TheoDoiBO.Instance.FindByPK(id);
                model.Status = 1;
                model.EndDate = DateTime.Now;
                TheoDoiBO.Instance.Update(model);
            }
            LoadInfoSearch();
        }

        private void btnNoComplete_Click(object sender, EventArgs e)
        {
            int userID = TextUtils.ToInt(grvData.GetFocusedRowCellValue(colUserID));
            if (userID != Global.UserID)
            {
                MessageBox.Show("Bạn không có quyền sửa công việc này?", TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                return;
            }
            if (grvData.SelectedRowsCount == 0) return;
            foreach (int i in grvData.GetSelectedRows())
            {
                int id = TextUtils.ToInt(grvData.GetRowCellValue(i, colID));
                int status = TextUtils.ToInt(grvData.GetRowCellValue(i, colStatus));
                if (status == 0) continue;
                TheoDoiModel model = (TheoDoiModel)TheoDoiBO.Instance.FindByPK(id);
                model.Status = 0;
                model.EndDate = null;
                TheoDoiBO.Instance.Update(model);
            }
            LoadInfoSearch();
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

        private void popupNotifier1_Click(object sender, EventArgs e)
        {
            frmWorkDiaryManager frm = new frmWorkDiaryManager();
            frm.WindowState = FormWindowState.Maximized;
            TextUtils.OpenForm(frm);
        }

        public void showPopUp(string content)
        {
            popupNotifier1.TitleText = "Thông Báo";
            popupNotifier1.ContentText = content;
            popupNotifier1.ShowCloseButton = true;
            popupNotifier1.ShowOptionsButton = false;
            popupNotifier1.ShowGrip = false;
            popupNotifier1.BorderColor = Color.Green;
            popupNotifier1.Delay = 5000;//thời gian popup hiển thị trên màn hình
            popupNotifier1.AnimationInterval = 10;
            popupNotifier1.AnimationDuration = 1000;
            popupNotifier1.TitlePadding = new Padding(0);
            popupNotifier1.ContentPadding = new Padding(0);
            popupNotifier1.ImagePadding = new Padding(0);
            popupNotifier1.Scroll = true;
            popupNotifier1.Size = new Size(400, 100);
            popupNotifier1.TitleColor = Color.Red;
            popupNotifier1.Popup();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //WarningWork
            try
            {
                ConfigSystemModel model = (ConfigSystemModel)ConfigSystemBO.Instance.
                    FindByAttribute("KeyName", "WarningWork")[0];

                List<string> listTime = model.KeyValue.Split(',').ToList();
                string now = DateTime.Now.ToString("HH:mm:ss");
                if (listTime.Contains(now))
                {
                    DataRow[] drs = _dtData.Select("Status = 0 and UserID = " + Global.UserID);
                    DataRow[] drs1 = _dtData.Select("Status = 0 and ChenhLech <= 0 and UserID = " + Global.UserID);
                    if (drs.Length > 0)
                    {
                        if (drs1.Length > 0)
                        {
                            showPopUp("Có " + drs.Length + " công việc chưa hoàn thành.\n" + "Có " + drs1.Length + " công việc quá hạn");
                        }
                        else
                        {
                            showPopUp("Có " + drs.Length + " công việc chưa hoàn thành.");
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private void frmWorkDiaryManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Maximized;
        }

        private void btnMoi_Click(object sender, EventArgs e)
        {
            LoadInfoSearch();
        }

        private void chkNotComplete_CheckedChanged(object sender, EventArgs e)
        {
            LoadInfoSearch();
        }

        private void grvData_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.RowHandle < 0) return;
            GridView View = sender as GridView;
            int status = TextUtils.ToInt(View.GetRowCellValue(e.RowHandle, colStatus));
            int chenhlech = TextUtils.ToInt(View.GetRowCellValue(e.RowHandle, colChenhLech));
            if (status == 0 && chenhlech <= 0)
            {
                e.Appearance.BackColor = Color.Red;
            }
        }
    }
}
