using DevExpress.Utils;
using DevExpress.XtraBars.Docking;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Localization;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BMS
{
    public partial class frmNhatKyCongViec : _Forms
    {
        public frmNhatKyCongViec()
        {
            InitializeComponent();
        }
        private void Test_Load(object sender, EventArgs e)
        {
            RegistryKey rkey = Registry.CurrentUser.OpenSubKey(@"Control Panel\International", true);
            if (!rkey.GetValue("sShortDate", "MM/dd/yy").ToString().Contains("M/yyyy"))
            {
                if (MessageBox.Show("Định dạng ngày tháng trên máy của bạn không phải là định dạng của Việt Nam (ngày/tháng/năm - dd/MM/yyyy)\n Bạn có muốn đổi lại định dạng ngày tháng không ?", TextUtils.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    rkey.SetValue("sShortDate", "dd/MM/yyyy");
                }
            }
            rkey.Close(); 
            LoadData();
            this.grdData.ToolTipController = this.toolTipController1;
        }
        ToolTipControlInfo lastInfo = null;
        int lastRowHandle = -1;
        GridColumn lastColumn = null;
        public void LoadData()
        {
            try
            {
                DataTable dt = TextUtils.Select("select * from vHangMucCongViec");
                grdData.DataSource = dt;
                DataTable dtf = TextUtils.Select("SELECT DISTINCT ProjectSyn.ProjectName + '- ' + ProjectSyn.ProjectCode AS ProjectName, ProjectSyn.ProjectCode, ProjectSyn.DateFinishE,datediff(d,getdate(),ProjectSyn.DateFinishE) as NgayConLai FROM SanPhamDA INNER JOIN ProjectSyn ON SanPhamDA.ProjectsID COLLATE Vietnamese_CI_AS = ProjectSyn.ProjectId order by ProjectName asc");
                grdTinhTrangDA.DataSource = dtf;
                repositoryItemLookUpEdit1.DataSource = TextUtils.Select("SELECT ID,Code, FullName FROM Users where DepartmentID="+Global.DepartmentID);
                repositoryItemLookUpEdit1.DisplayMember = "FullName";
                repositoryItemLookUpEdit1.ValueMember = "ID";

                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow[] dt12 = dt.Select("TinhTrang <> ''", "ProjectName asc");
                    DataTable dt1 = new DataTable();
                    if (dt12.Count() > 0)
                    {
                        dt1=dt12.CopyToDataTable(); // TextUtils.Select("SELECT DISTINCT ProjectSyn.ProjectName + '- ' + ProjectSyn.ProjectCode AS ProjectName, ProjectSyn.ProjectCode, SanPhamDA.TenTheoHopDong + '- ' + SanPhamDA.MaTheoHopDong AS TenTheoHopDong, SanPhamDA.MaTheoHopDong, UserGroup.Name, HangMucCongViec.ID, HangMucCongViec.TenHangMuc, HangMucCongViec.ThoiGianTK, HangMucCongViec.ThoiGianBDDuKien, HangMucCongViec.ThoiGianKTDuKien, HangMucCongViec.NguoiThietKe, HangMucCongViec.MucDoUuTien, HangMucCongViec.TinhTrang, HangMucCongViec.KieuCongViec, HangMucCongViec.Loi, HangMucCongViec.SanPhamDAID FROM SanPhamDA INNER JOIN UserGroup ON SanPhamDA.NhomPhuTrach = UserGroup.ID INNER JOIN ProjectSyn ON SanPhamDA.ProjectsID COLLATE Vietnamese_CI_AS = ProjectSyn.ProjectId LEFT OUTER JOIN HangMucCongViec ON SanPhamDA.ID = HangMucCongViec.SanPhamDAID WHERE (HangMucCongViec.TinhTrang <>'')"); ;
                    }
                    if (dt1 != null)
                    {
                        grdDAVanDe.DataSource = dt1;
                    } 
                }
                grvData.BestFitColumns();
                grvDAVanDe.BestFitColumns();
                grvTinhTrangDA.BestFitColumns();
                loadYear();
                int y = WeeksInYear(DateTime.Now);
                leWeek.ItemIndex = y - 1;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public static int WeeksInYear(DateTime date)
        {
            GregorianCalendar cal = new GregorianCalendar(GregorianCalendarTypes.Localized);
            return cal.GetWeekOfYear(date, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
        }

        public void loadYear()
        {
            List<int> listYear = new List<int>();

            for (int i = 0; i < 30; i++)
            {
                listYear.Add(2010 + i);
            }
            leYear.EditValue = DateTime.Now.Year;
            leYear.Properties.DataSource = listYear;
        }
        private void leWeek_EditValueChanged(object sender, EventArgs e)
        {
            if (leWeek.EditValue == null) return;
            getSEDate(leWeek.EditValue.ToString());
        }
        void getSEDate(string WeekInfo)
        {
            string[] str = WeekInfo.Split(':');
            DateTime sta = TextUtils.ToDate1((str[1].Split('-')[0]).Trim());
            //string end = (str[1].Split('-')[1]).Trim();

            //DateTime dd = TextUtils.ToDate(end);
            gridColumn25.Caption = "Thứ 2 (" + sta.ToString("dd/MM") + ")";

            gridColumn25.ToolTip = sta.ToString("dd/MM/yyyy");
            gridColumn26.Caption = "Thứ 3 (" + sta.AddDays(1).ToString("dd/MM") + ")";
            gridColumn26.ToolTip = sta.AddDays(1).ToString("dd/MM/yyyy");
            gridColumn27.Caption = "Thứ 4 (" + sta.AddDays(2).ToString("dd/MM") + ")";
            gridColumn27.ToolTip = sta.AddDays(2).ToString("dd/MM/yyyy");
            gridColumn28.Caption = "Thứ 5 (" + sta.AddDays(3).ToString("dd/MM") + ")";
            gridColumn28.ToolTip = sta.AddDays(3).ToString("dd/MM/yyyy");

            gridColumn29.Caption = "Thứ 6 (" + sta.AddDays(4).ToString("dd/MM") + ")";
            gridColumn29.ToolTip = sta.AddDays(4).ToString("dd/MM/yyyy");

            gridColumn30.Caption = "Thứ 7 (" + sta.AddDays(5).ToString("dd/MM") + ")";
            gridColumn30.ToolTip = sta.AddDays(5).ToString("dd/MM/yyyy");

            grdData.Refresh();

        }
        public void loadWeek(int Year)
        {
            List<string> hgh = new List<string>();
            hgh = TextUtils.LoadAllWeekOfYear(Year);
            leWeek.Properties.DataSource = TextUtils.LoadAllWeekOfYear(Year);
        }
        private void dockPanel3_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmCreateDuAn frm = new frmCreateDuAn();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Test_Load(null, null);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                frmTaoDuAn frm = new frmTaoDuAn();
                frm._MaDuAn = MaDuAn;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    Test_Load(null, null);
                }
            }
            catch (Exception)
            {
                
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            frmPhanBoCongViec frm = new frmPhanBoCongViec();
            frm._maDuAn = MaDuAn;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Test_Load(null, null);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            frmThongKeKeHoach frm = new frmThongKeKeHoach();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Test_Load(null, null);
            }
        }

        private void panelContainer1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grvDAVanDe_Click(object sender, EventArgs e)
        {
            if (grvData.IsDataRow(grvDAVanDe.FocusedRowHandle))
            {
                ckBox.Checked = true;
                string ff = grvDAVanDe.GetFocusedRowCellValue(colIDVANDE).ToString();

                grdData.Refresh();
                grvData.Focus();
                grvData.FocusedRowHandle = fncGetfocusedLastsavedrecord(ff, true);
                grvData.ShowEditor(); 
            }
        }

        private int fncGetfocusedLastsavedrecord(string Sname, bool f)
        {

            for (int i = 0; i < grvData.RowCount; i++)
            {
                if (f)
                {
                    if (grvData.GetRowCellValue(i, "ID").ToString().ToUpper() == Sname.ToUpper())
                    {
                        return i;
                    }
                }
                else
                {
                    if (grvData.GetRowCellValue(i, "ProjectCode").ToString().ToUpper() == Sname.ToUpper())
                    {
                        return i;
                    }
                }
            }
            return 0;
        }

        private void grvTinhTrangDA_Click(object sender, EventArgs e)
        {
            ckBox.Checked = true;
            string ff = grvTinhTrangDA.GetFocusedRowCellValue(colProjectCode).ToString();

            grdData.Refresh();
            grvData.Focus();
            grvData.FocusedRowHandle = fncGetfocusedLastsavedrecord(ff, false);
            grvData.ShowEditor();
        }

        private void ckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (ckBox.Checked)
            {
                grvData.OptionsBehavior.AutoExpandAllGroups = true;
            }
            else
            {
                grvData.OptionsBehavior.AutoExpandAllGroups = false;
                LoadData();
            }
        }

        private void leYear_EditValueChanged(object sender, EventArgs e)
        {
            if (leYear.EditValue == null) return;

            loadWeek(TextUtils.ToInt(leYear.EditValue));
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void grvData_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            try
            {
                GridView View = sender as GridView;
                if (e.RowHandle >= 0)
                {
                    if (View.GetRowCellValue(e.RowHandle, colThoiGianBDDuKien).ToString().Trim() != "")
                    {
                        if (View.GetRowCellValue(e.RowHandle, colThoiGianKTDuKien).ToString().Trim() != "")
                        {
                            DateTime Tomau = TextUtils.ToDate(View.GetRowCellValue(e.RowHandle, colThoiGianBDDuKien).ToString().Trim());
                            DateTime Tomau1 = TextUtils.ToDate(View.GetRowCellValue(e.RowHandle, colThoiGianKTDuKien).ToString().Trim());

                            if (TextUtils.DateDiff("d", Tomau1, Tomau) < 0)
                            {
                                return;
                            }
                            else
                                if (TextUtils.DateDiff("d", Tomau1, Tomau) > 0)
                                {
                                    foreach (GridColumn item in View.Columns)
                                    {
                                        for (int i = 0; i < 55; i++)
                                        {
                                            DateTime tBNgay = Tomau.AddDays(i);
                                            if (TextUtils.DateDiff("d", Tomau1, tBNgay) > 0)
                                            {
                                                if (tBNgay.ToString("dd/MM/yyyy") == item.ToolTip)
                                                {
                                                    if (e.Column == item)
                                                    {
                                                        e.Appearance.BackColor = Color.Orange;
                                                        break;
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                break;
                                            }

                                        }

                                    }
                                }
                            foreach (GridColumn item in View.Columns)
                            {
                                if (Tomau1.ToString("dd/MM/yyyy") == item.ToolTip)
                                {
                                    if (e.Column == item)
                                        e.Appearance.BackColor = Color.Orange;
                                }
                            }
                        }
                    }
                }

            }
            catch (Exception)
            {
                return;
                throw;
            }
        }

        private void toolTipController1_GetActiveObjectInfo(object sender, ToolTipControllerGetActiveObjectInfoEventArgs e)
        {
            if (e.Info == null && e.SelectedControl == grdData)
            {
                GridView view = grdData.FocusedView as GridView;
                GridHitInfo info = view.CalcHitInfo(e.ControlMousePosition);
                if (info.RowHandle>=0)
                {
                    if (info.InRowCell)
                    {
                        if (lastRowHandle != info.RowHandle || lastColumn != info.Column)
                        {
                            lastColumn = info.Column;
                            lastRowHandle = info.RowHandle;
                            string text = "";
                            if (view.GetRowCellValue(info.RowHandle, info.Column)!=null)
                            {
                                text = view.GetRowCellValue(info.RowHandle, info.Column).ToString();
                            }
                            lastInfo = new ToolTipControlInfo(new GridToolTipInfo(view, new CellToolTipInfo(info.RowHandle, info.Column, "Text")), text);
                        }
                        e.Info = lastInfo;
                    } 
                }
            }
        }
        string MaDuAn = "";
        private void grvData_Click(object sender, EventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                if (view.IsGroupRow(grvData.FocusedRowHandle))
                {
                    int k = view.GetDataRowHandleByGroupRowHandle(view.FocusedRowHandle);
                    MaDuAn = view.GetRowCellValue(k, colProjectId).ToString();
                    //MessageBox.Show(l);
                }
                else
                    if (view.IsDataRow(view.FocusedRowHandle))
                    {

                        MaDuAn = (view.GetFocusedRowCellValue(colProjectId).ToString());
                    }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void grvData_DataSourceChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    GridView view = sender as GridView;
            //    if (view.IsGroupRow(grvData.FocusedRowHandle))
            //    {
            //        int k = view.GetDataRowHandleByGroupRowHandle(view.FocusedRowHandle);
            //        MaDuAn = view.GetRowCellValue(k, colProjectId).ToString();
            //        //MessageBox.Show(l);
            //    }
            //    else
            //    {
            //        MaDuAn = (view.GetFocusedRowCellValue(colProjectId).ToString());
            //    }
            //}
            //catch (Exception)
            //{

            //    throw;
            //}
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            frmPhanGio frm = new frmPhanGio();
            frm.Show();
        }
    }
}
