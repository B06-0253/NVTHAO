using BMS.Business;
using BMS.Model;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections;
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
    public partial class frmPhanBoCongViec : _Forms
    {
        public frmPhanBoCongViec()
        {
            InitializeComponent();
        }
        DataTable df;//= new DataTable();
        DataTable m_DataSource = new DataTable();
        DataTable Source = new DataTable();
        public string _maDuAn = "";
        #region Event
        private void btnNew_Click(object sender, EventArgs e)
        {
            grvData.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            PageBase.StateButton(true, btnNew, btnEdit, btnSave, btnCancel, btnDelete);
            PageBase.VisibleColumnInGrid(grvData, true);
            Global_Add.sFormStatus = Global_Add.FormStatus.Addnew;
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            PageBase.StateButton(true, btnNew, btnEdit, btnSave, btnCancel, btnDelete);
            PageBase.VisibleColumnInGrid(grvData, true);
            Global_Add.sFormStatus = Global_Add.FormStatus.Edit;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save(ref m_DataSource);
            {
                grvData.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
                PageBase.StateButton(false, btnNew, btnEdit, btnSave, btnCancel, btnDelete);
                PageBase.VisibleColumnInGrid(grvData, false);
                Global_Add.sFormStatus = Global_Add.FormStatus.View;
                SelectAll(ref m_DataSource, grdData);
                Source = TextUtils.Select("select * from vHangMucCongViec");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SelectAll(ref m_DataSource, grdData);
            PageBase.StateButton(false, btnNew, btnEdit, btnSave, btnCancel, btnDelete);
            PageBase.VisibleColumnInGrid(grvData, false);
            grvData.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (grvData.FocusedRowHandle < 0)
                {
                    XtraMessageBox.Show("Không có mẫu tin nào để xóa", "Thông báo", MessageBoxButtons.OK);
                    return;
                }
                if (grvData.GetSelectedRows().Count() < 0)
                {
                    return;
                }
                if (XtraMessageBox.Show("Bạn có chắc xóa mẫu tin này không?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int j = -1;
                    for (int i = 0; i < grvData.SelectedRowsCount; i++)
                    {
                        if (grvData.GetSelectedRows()[i] >= 0)
                            j = grvData.GetSelectedRows()[i];
                        if (j >= 0)
                        {
                            int IDs = Convert.ToInt32(grvData.GetRowCellValue(j, colID).ToString());
                            HangMucCongViecBO.Instance.Delete(IDs);
                        }
                    }
                    SelectAll(ref m_DataSource, grdData);
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void lookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (lookUpEdit1.EditValue != null)
                {
                    DataTable dt = TextUtils.Select("SELECT * FROM vSanPham WHERE (ProjectsID = N'" + lookUpEdit1.EditValue.ToString() + "')");
                    if (dt.Rows.Count <= 0)
                    {
                        dt = SanPhamDABO.KhoiTaoGrid();
                    }
                    grdDataSP.DataSource = dt;
                }
                else
                    grdDataSP.DataSource = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void grvData_Click(object sender, EventArgs e)
        {

            try
            {
                ArrayList model = ConfigSystemBO.Instance.FindByAttribute("KeyName", "HangMuc");
                repositoryItemLookUpEdit1.DataSource = model;
                repositoryItemLookUpEdit1.DisplayMember = "KeyValue";
                repositoryItemLookUpEdit1.ValueMember = "KeyValue";
                repositoryItemLookUpEdit1.NullText = "Chọn hạng mục";
                SelectAll(ref m_DataSource, grdData);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void frmPhanBoCongViec_Load(object sender, EventArgs e)
        {
            tinhgio();
            TextUtils.SetContainsFilter(searchLookUpEdit1View);

            TextUtils.SetContainsFilter(grvData);
            Source = TextUtils.Select("select * from vHangMucCongViec");
            NhanVien();
            loadYear();
            leYear.EditValue = DateTime.Now.Year;
            leWeek.ItemIndex = WeeksInYear(DateTime.Now) - 1;

            LoadComBo();
            grvData.BestFitColumns();
            PageBase.StateButton(false, btnNew, btnEdit, btnSave, btnCancel, btnDelete);
            PageBase.VisibleColumnInGrid(grvData, false);
            if (_maDuAn != "")
            {
                lookUpEdit1.EditValue = _maDuAn;
            }
        }
        void NhanVien()
        {
            //grdNhanVien.DataSource = UsersBO.Instance.FindAll();
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
            dt = TextUtils.Select("SELECT Users.FullName, UserGroup.Name FROM Users INNER JOIN UserGroup ON Users.UserGroupID = UserGroup.ID WHERE (Users.DepartmentID = " + Global.DepartmentID + ")");
            dt1 = dt.Copy();
            dt.Columns.Add("ff");
            dt1.Columns.Add("ff");
            foreach (DataRow item in dt1.Rows)
            {
                item["ff"] = "Dự kiến";
            }
            foreach (DataRow item in dt.Rows)
            {
                item["ff"] = "Thực tế";
            }
            dt1.Merge(dt);
            dt1 = dt1.Select("", "FullName ASC").CopyToDataTable();

            grdNhanVien.DataSource = dt1;
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
        private void leYear_EditValueChanged(object sender, EventArgs e)
        {
            if (leYear.EditValue == null) return;

            loadWeek(TextUtils.ToInt(leYear.EditValue));
            int lo = WeeksInYear(DateTime.Now) - 1;
            leWeek.ItemIndex = lo;
        }
        void getSEDate(string WeekInfo)
        {
            string[] str = WeekInfo.Split(':');
            DateTime sta = TextUtils.ToDate1((str[1].Split('-')[0]).Trim());
            int tj = Convert.ToInt32(str[0].Substring(str[0].Length - 2, 2));
            gridColumn9.Caption = "Thứ 2 (" + sta.ToString("dd/MM") + ")";
            gridColumn9.ToolTip = sta.ToString("dd/MM/yyyy");
            gridColumn10.Caption = "Thứ 3 (" + sta.AddDays(1).ToString("dd/MM") + ")";
            gridColumn10.ToolTip = sta.AddDays(1).ToString("dd/MM/yyyy");
            gridColumn11.Caption = "Thứ 4 (" + sta.AddDays(2).ToString("dd/MM") + ")";
            gridColumn11.ToolTip = sta.AddDays(2).ToString("dd/MM/yyyy");
            gridColumn12.Caption = "Thứ 5 (" + sta.AddDays(3).ToString("dd/MM") + ")";
            gridColumn12.ToolTip = sta.AddDays(3).ToString("dd/MM/yyyy");

            gridColumn13.Caption = "Thứ 6 (" + sta.AddDays(4).ToString("dd/MM") + ")";
            gridColumn13.ToolTip = sta.AddDays(4).ToString("dd/MM/yyyy");

            gridColumn14.Caption = "Thứ 7 (" + sta.AddDays(5).ToString("dd/MM") + ")";
            gridColumn14.ToolTip = sta.AddDays(5).ToString("dd/MM/yyyy");
            gridColumn9.FieldName = sta.ToString("dd/MM/yyyy");
            //10.Caption = "Thứ 3 (" + sta.AddDays(1).ToString("dd/MM") + ")";
            gridColumn10.FieldName = sta.AddDays(1).ToString("dd/MM/yyyy");
            //11.Caption = "Thứ 4 (" + sta.AddDays(2).ToString("dd/MM") + ")";
            gridColumn11.FieldName = sta.AddDays(2).ToString("dd/MM/yyyy");
            //12.Caption = "Thứ 5 (" + sta.AddDays(3).ToString("dd/MM") + ")";
            gridColumn12.FieldName = sta.AddDays(3).ToString("dd/MM/yyyy");

            //13.Caption = "Thứ 6 (" + sta.AddDays(4).ToString("dd/MM") + ")";
            gridColumn13.FieldName = sta.AddDays(4).ToString("dd/MM/yyyy");

            //14.Caption = "Thứ 7 (" + sta.AddDays(5).ToString("dd/MM") + ")";
            gridColumn14.FieldName = sta.AddDays(5).ToString("dd/MM/yyyy");
            grdNhanVien.Refresh();

        }
        public void loadWeek(int Year)
        {
            leWeek.Properties.DataSource = TextUtils.LoadAllWeekOfYear(Year);
        }
        private void frmPhanBoCongViec_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void grvData_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {

            if (e.Value == null)
            {
                return;
            }
            try
            {
                if (grvData.FocusedColumn == colThoiGianTK || grvData.FocusedColumn == colThuTuUuTien)
                {
                    if (Convert.ToInt32(e.Value) < 0)
                    {
                        e.ErrorText = "Số phải lớn hơn hoặc bằng 0";
                        e.Valid = false;
                    }
                }
            }
            catch (Exception ex)
            {
                e.ErrorText = "Số phải lớn hơn hoặc bằng 0";
                e.Valid = false;
            }
        }
        string[] _paraName = new string[2];
        object[] _paraValue = new object[2];
        private void grvNhanVien_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            try
            {
                GridView View = sender as GridView;

                if (df != null)
                {
                    foreach (DataRow item1 in df.Rows)
                    {
                        if (View.GetRowCellValue(e.RowHandle, colNhanVien).ToString() == item1["FullName"].ToString())
                        {
                            if (View.GetRowCellValue(e.RowHandle, colThoiGian).ToString() == "Dự kiến")
                            {
                                DateTime Tomau = TextUtils.ToDate(item1["ThoiGianBDDuKien"].ToString());
                                DateTime Tomau1 = TextUtils.ToDate(item1["ThoiGianKTDuKien"].ToString());
                                _paraName[0] = "@NgayBD"; _paraValue[0] = Tomau;
                                _paraName[1] = "@NgayKT"; _paraValue[1] = Tomau1;
                                //DataTable hu = TextUtils.Select("select distinct ThoiGianBDDuKienSP as ThoiGianBDDuKien,ThoiGianKTDuKienSP as ThoiGianKTDuKien,Name from vHangMucCongViec where ThoiGianKTDuKien between " + NgayBD + " and " + NgayKT);
                                DataTable Source2 = ModulesBO.Instance.LoadDataFromSP("sp_ThongKeTHeoNhom1", "Source", _paraName, _paraValue);
                                if (Source2 != null)
                                {
                                    if (Source2.Rows.Count > 0)
                                    {
                                        Tomau1 = Tomau1.AddDays(Source2.Rows.Count);
                                    }
                                }
                                if (TextUtils.DateDiff("d", Tomau1, Tomau) >= 0)
                                {
                                    foreach (GridColumn item in View.Columns)
                                    {
                                        for (int i = 0; i <= TextUtils.DateDiff("d", Tomau1, Tomau); i++)
                                        {
                                            DateTime tBNgay = Tomau.AddDays(i);
                                            if (TextUtils.DateDiff("d", Tomau1, tBNgay) > 0)
                                            {
                                                if (tBNgay.ToString("dd/MM/yyyy") == item.ToolTip)
                                                {
                                                    if (e.Column == item)
                                                    {
                                                        {
                                                            e.DisplayText = "8";
                                                            e.Appearance.BackColor = Color.Orange;
                                                        }
                                                        break;
                                                    }
                                                }
                                            }else
                                            if (TextUtils.DateDiff("d", Tomau1, tBNgay) == 0)
                                            {
                                                if (tBNgay.ToString("dd/MM/yyyy") == item.ToolTip)
                                                {
                                                    if (e.Column == item)
                                                    {
                                                        {
                                                            e.DisplayText = item1["du"].ToString();
                                                            e.Appearance.BackColor = Color.Orange;
                                                        }
                                                        break;
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                return;
                                            }

                                        }

                                    }
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
            //try
            //{
            //    GridView View = sender as GridView;

            //    if (df != null)
            //    {
            //        foreach (DataRow item1 in df.Rows)
            //        {
            //            if (View.GetRowCellValue(e.RowHandle, colNhanVien).ToString() == item1["FullName"].ToString())
            //            {
            //                if (View.GetRowCellValue(e.RowHandle, colThoiGian).ToString() == "Dự kiến")
            //                {
            //                    DateTime Tomau = TextUtils.ToDate(item1["ThoiGianBDDuKien"].ToString());
            //                    DateTime Tomau1 = TextUtils.ToDate(item1["ThoiGianKTDuKien"].ToString());

            //                    if (TextUtils.DateDiff("d", Tomau1, Tomau) > 0)
            //                    {

            //                        for (int i = 0; i <= TextUtils.DateDiff("d", Tomau1, Tomau); i++)
            //                        {
            //                            DateTime tBNgay = Tomau.AddDays(i);
            //                            if (TextUtils.DateDiff("d", Tomau1, tBNgay) > 0)
            //                            {
            //                                foreach (GridColumn item in View.Columns)
            //                                {

            //                                    if (tBNgay.ToString("dd/MM/yyyy") == item.ToolTip)
            //                                    {
            //                                        if (e.Column == item)
            //                                        {
            //                                                e.Appearance.BackColor = Color.Orange;
            //                                                e.DisplayText = "8";
            //                                                break;
            //                                        }
            //                                    }
            //                                }
            //                            }
            //                            if (TextUtils.DateDiff("d", Tomau1, tBNgay) == 0)
            //                            {
            //                                foreach (GridColumn item in View.Columns)
            //                                {
            //                                    if (tBNgay.ToString("dd/MM/yyyy") == item.ToolTip)
            //                                    {
            //                                        if (e.Column == item)
            //                                        {
            //                                            {
            //                                                e.Appearance.BackColor = Color.Orange;
            //                                                e.DisplayText = item1["du"].ToString();
            //                                            }
            //                                            break;
            //                                        }
            //                                    }
            //                                }
            //                            }
            //                        }
            //                    }
            //                }
            //            }
            //        }
            //    }


            //}
            //catch (Exception)
            //{
            //    return;
            //    throw;
            //}
            //try
            //{
            //    GridView View = sender as GridView;
            //    if (df != null)
            //    {
            //        foreach (GridColumn item in View.Columns)
            //        {
            //            foreach (DataRow item1 in df.Rows)
            //            {
            //                DateTime Tomau = TextUtils.ToDate(item1["ThoiGianBDDuKien"].ToString());
            //                if (Tomau.ToString("dd/MM/yyyy") == item.ToolTip)
            //                {
            //                    if (View.GetRowCellValue(e.RowHandle, colNhanVien).ToString() == item1["FullName"].ToString())
            //                    {
            //                        if (View.GetRowCellValue(e.RowHandle, colThoiGian).ToString() == "Dự kiến")
            //                        {
            //                            if (e.Column == item)
            //                            {
            //                                int tongh = Convert.ToInt32(item1["tongtg"].ToString());
            //                                if (tongh <= 8)
            //                                {
            //                                    e.DisplayText = item1["tongtg"].ToString();
            //                                }
            //                                else
            //                                {
            //                                    int giat = tongh / 8;
            //                                    int thua = tongh % 8;
            //                                    e.DisplayText = tongh.ToString();
            //                                    grvNhanVien.SetFocusedRowCellValue("thu2", thua);
            //                                }
            //                            }
            //                        }
            //                    }
            //                }
            //                else
            //                    continue;
            //            }
            //        }
            //    }

            //}
            //catch (Exception)
            //{
            //    return;
            //    throw;
            //}
        }

        private void grvDataSP_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {

            int l = grvDataSP.FocusedRowHandle;
            if (l < 0)
            {
                return;
            }

            try
            {
                ArrayList model = ConfigSystemBO.Instance.FindByAttribute("KeyName", "HangMuc");
                repositoryItemLookUpEdit1.DataSource = model;
                repositoryItemLookUpEdit1.DisplayMember = "KeyValue";
                repositoryItemLookUpEdit1.ValueMember = "KeyValue";
                SelectAll(ref m_DataSource, grdData);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void grvData_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            GridView view = sender as GridView;
            try
            {
                #region checkvailidate
                if (view.GetRowCellValue(e.RowHandle, colTenHangMuc).ToString() == string.Empty)
                {
                    e.Valid = false;
                    return;
                }
                else
                    if (view.GetRowCellValue(e.RowHandle, colThoiGianTK).ToString() == string.Empty)
                    {
                        e.Valid = false;
                        return;
                    }
                    else
                        if (view.GetRowCellValue(e.RowHandle, colThoiGianBDDuKien).ToString() == string.Empty)
                        {
                            e.Valid = false;
                            return;
                        }
                        else
                            if (view.GetRowCellValue(e.RowHandle, colUserTK).ToString() == string.Empty)
                            {
                                e.Valid = false;
                                return;
                            }
                            else
                                if (view.GetRowCellValue(e.RowHandle, colThuTuUuTien).ToString() == string.Empty)
                                {
                                    e.Valid = false;
                                    return;
                                }

                int l = Convert.ToInt32(view.GetRowCellValue(e.RowHandle, colThoiGianTK));
                int k = l / 8;
                int lp = l % 8;
                if (lp == 0)
                {
                    k--;
                }
                if (view.GetRowCellValue(e.RowHandle, colThoiGianBDDuKien).ToString() != string.Empty)
                {
                    view.SetRowCellValue(e.RowHandle, colThoiGianKTDuKien, Convert.ToDateTime(view.GetRowCellValue(e.RowHandle, colThoiGianBDDuKien)).AddDays(k));
                }
                #endregion
                HangMucCongViecModel model = new HangMucCongViecModel();
                model.TenHangMuc = view.GetRowCellValue(e.RowHandle, colTenHangMuc).ToString(); // dtRemine.Rows[i]["TenHangMuc"].ToString();
                model.ThoiGianTK = TextUtils.ToInt(view.GetRowCellValue(e.RowHandle, colThoiGianTK).ToString()); //dtRemine.Rows[i]["ThoiGianTK"].ToString());
                model.ThoiGianBDDuKien = TextUtils.ToDate(view.GetRowCellValue(e.RowHandle, colThoiGianBDDuKien).ToString()); //dtRemine.Rows[i]["ThoiGianBDDuKien"].ToString());
                model.ThoiGianKTDuKien = TextUtils.ToDate(view.GetRowCellValue(e.RowHandle, colThoiGianKTDuKien).ToString()); //dtRemine.Rows[i]["ThoiGianKTDuKien"].ToString());
                model.TinhTrang = view.GetRowCellValue(e.RowHandle, colTinhTrang).ToString(); // dtRemine.Rows[i]["TinhTrang"].ToString();
                model.NguoiThietKe = view.GetRowCellValue(e.RowHandle, colUserTK).ToString(); // dtRemine.Rows[i]["NguoiThietKe"].ToString();
                model.MucDoUuTien = view.GetRowCellValue(e.RowHandle, colMucDoUuTien).ToString(); // dtRemine.Rows[i]["MucDoUuTien"].ToString();
                model.KieuCongViec = view.GetRowCellValue(e.RowHandle, colKieuCongViec).ToString(); //dtRemine.Rows[i]["KieuCongViec"].ToString();
                model.Loi = view.GetRowCellValue(e.RowHandle, colLoi).ToString(); //dtRemine.Rows[i]["Loi"].ToString();
                if (XtraMessageBox.Show("Dữ liệu đã bị thay đổi\nBạn có muốn lưu vào cơ sở dữ liệu không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    model.SanPhamDAID = Convert.ToInt32(grvDataSP.GetRowCellValue(grvDataSP.FocusedRowHandle, colID).ToString());
                    if (view.GetRowCellValue(e.RowHandle, colID) == DBNull.Value) //add new
                    {
                        //insert
                        HangMucCongViecBO.Instance.Insert(model);
                    }
                    else
                    {
                        model.ID = TextUtils.ToInt(view.GetRowCellValue(e.RowHandle, colID).ToString());
                        //update
                        HangMucCongViecBO.Instance.Update(model);
                    }
                }
                else
                    e.Valid = false;
                lookUpEdit1_EditValueChanged(null, null);
                tinhgio();
                grvNhanVien_CustomDrawCell(null, null);
                //grvNhanVien.FocusedRowHandle = -1; grvNhanVien.FocusedRowHandle = 0;
                ////DataTable hu = grdNhanVien.DataSource as DataTable;


            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Method
        public void Save(ref DataTable dt)
        {
            grvData.FocusedRowHandle = -1;
            //DataTable dtRemine;
            //dtRemine = dt.GetChanges();
            //if (dtRemine != null)
            //{
            //    for (int i = 0; i < dtRemine.Rows.Count; i++)
            //    {
            //        HangMucCongViecModel model = new HangMucCongViecModel();
            //        model.TenHangMuc = dtRemine.Rows[i]["TenHangMuc"].ToString();
            //        model.ThoiGianTK =TextUtils.ToInt(dtRemine.Rows[i]["ThoiGianTK"].ToString());
            //        model.ThoiGianBDDuKien = TextUtils.ToDate(dtRemine.Rows[i]["ThoiGianBDDuKien"].ToString());
            //        model.ThoiGianKTDuKien = TextUtils.ToDate(dtRemine.Rows[i]["ThoiGianKTDuKien"].ToString());
            //        model.TinhTrang = dtRemine.Rows[i]["TinhTrang"].ToString();
            //        model.NguoiThietKe = dtRemine.Rows[i]["NguoiThietKe"].ToString();
            //        model.MucDoUuTien = dtRemine.Rows[i]["MucDoUuTien"].ToString();
            //        model.KieuCongViec = dtRemine.Rows[i]["KieuCongViec"].ToString();
            //        model.Loi = dtRemine.Rows[i]["Loi"].ToString();
            //        if (XtraMessageBox.Show("Dữ liệu đã bị thay đổi\nBạn có muốn lưu vào cơ sở dữ liệu không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //        {
            //            model.SanPhamDAID = Convert.ToInt32(grvDataSP.GetRowCellValue(grvDataSP.FocusedRowHandle, colID).ToString());
            //            if (dtRemine.Rows[i][colID.FieldName] == DBNull.Value) //add new
            //            {
            //                //insert
            //                HangMucCongViecBO.Instance.Insert(model);
            //            }
            //            else
            //            {
            //                model.ID = TextUtils.ToInt(dtRemine.Rows[i]["ID"].ToString());
            //                //update
            //                HangMucCongViecBO.Instance.Update(model);
            //            }
            //        }
            //    }
            //}
        }
        public void SelectAll(ref DataTable dt, GridControl grd)
        {
            try
            {

                LeNhanVien.DataSource = TextUtils.Select("SELECT Code,ID, FullName FROM Users WHERE (UserGroupID =" + grvDataSP.GetFocusedRowCellValue(colNhomPhuTrach) + ")");
                LeNhanVien.DisplayMember = "FullName";
                LeNhanVien.ValueMember = "ID";
                if (grvData.RowCount < 0)
                {
                    return;
                }
                dt = TextUtils.Select("SELECT * FROM HangMucCongViec WHERE (SanPhamDAID = " + grvDataSP.GetFocusedRowCellValue(colID) + ")");
                if (dt == null)
                {
                    dt = HangMucCongViecBO.KhoiTaoGrid();
                }
                grdData.DataSource = dt;

                grvData.BestFitColumns();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void LoadComBo()
        {
            DataTable dt = TextUtils.Select("select ProjectName collate SQL_Latin1_General_CP1_CI_AS as ProjectName,ProjectCode,ProjectId  collate SQL_Latin1_General_CP1_CI_AS as ProjectId from ProjectSyn");
            lookUpEdit1.Properties.DataSource = dt;
            lookUpEdit1.Properties.DisplayMember = "ProjectName";
            lookUpEdit1.Properties.ValueMember = "ProjectId";
            LeNhom.DataSource = TextUtils.Select("SELECT Code,ID,Name FROM UserGroup");
            LeNhom.DisplayMember = "Name";
            LeNhom.ValueMember = "ID";
        }
        #endregion

        private void repositoryItemLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {

            //string fff =grvData.GetRowCellValue(grvData.FocusedRowHandle,colTenHangMuc).ToString();//.GetRowCellValue(grvData.FocusedRowHandle,colTenHangMuc).ToString();

            //DataTable dt= TextUtils.Select("SELECT KeyValue1 FROM ConfigSystem WHERE (KeyName = N'HangMuc') AND (KeyValue = N'Danh mục bài thực hành')");

            //string s = repositoryItemLookUpEdit1.GetDisplayText(grvData.GetFocusedRowCellValue(colTenHangMuc.FieldName));
        }

        private void grvData_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column != colTenHangMuc) return;
            try
            {
                string s = e.Value.ToString();
                DataTable dt = TextUtils.Select("SELECT KeyValue1 FROM ConfigSystem WHERE (KeyName = N'HangMuc') AND (KeyValue = N'" + s + "')");
                grvData.SetFocusedRowCellValue(colMucDoUuTien, dt.Rows[0][0].ToString());
                grvData.SetFocusedRowCellValue(colTimeBDdukien, grvDataSP.GetFocusedRowCellValue(colThoiGianBDDuKien));
            }
            catch (Exception)
            {
            }
        }

        private void grvData_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            //if (e.Column != colTenHangMuc) return;
            //try
            //{
            //    string s = e.Value.ToString();
            //    DataTable dt = TextUtils.Select("SELECT KeyValue1 FROM ConfigSystem WHERE (KeyName = N'HangMuc') AND (KeyValue = N'" + s + "')");
            //    grvData.SetFocusedRowCellValue(colMucDoUuTien, dt.Rows[0][0].ToString());
            //}
            //catch (Exception)
            //{
            //}
        }

        private void grvDataSP_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            try
            {
                GridView View = sender as GridView;
                if (TextUtils.ToInt(View.GetRowCellValue(e.RowHandle, colTG).ToString()) < TextUtils.ToInt(View.GetRowCellValue(e.RowHandle, colTongTG).ToString()))
                {
                    e.Appearance.BackColor = Color.Green;
                }
                if (TextUtils.ToInt(View.GetRowCellValue(e.RowHandle, colTongTG).ToString())==0)
                {
                    e.Appearance.BackColor = Color.Yellow;
                }
            }
            catch (Exception)
            {
                return;
                throw;
            }
        }

        void tinhgio()
        {
            try
            {
                df = TextUtils.Select("SELECT HangMucCongViec.NguoiThietKe, HangMucCongViec.ThoiGianBDDuKien, SUM(HangMucCongViec.ThoiGianTK) AS tongtg, Users.FullName, SUM(HangMucCongViec.ThoiGianTK)%8 as du,DATEADD(day,SUM(HangMucCongViec.ThoiGianTK)/8,HangMucCongViec.ThoiGianBDDuKien)as ThoiGianKTDuKien,HangMucCongViec.ID FROM HangMucCongViec LEFT OUTER JOIN Users ON HangMucCongViec.NguoiThietKe = Users.ID GROUP BY HangMucCongViec.NguoiThietKe, HangMucCongViec.ThoiGianBDDuKien, Users.FullName,HangMucCongViec.ID");
               // gggggggg();
                fff();
            }
            catch (Exception)
            {

                throw;
            }
        }
        void gggggggg()
        {
            DataTable dt = new DataTable();
            foreach (GridColumn colum in grvNhanVien.Columns)
            {
                dt.Columns.Add(colum.FieldName, colum.ColumnType);
            }
            for (int i = 0; i < grvNhanVien.DataRowCount; i++)
            {
                DataRow row = dt.NewRow();
                foreach (GridColumn colum in grvNhanVien.Columns)
                {
                    row[colum.FieldName] = grvNhanVien.GetRowCellValue(i, colum);
                }
                dt.Rows.Add(row);
            }


            foreach (DataRow item1 in df.Rows)
            {
                DateTime Tomau = TextUtils.ToDate(item1["ThoiGianBDDuKien"].ToString());
                foreach (DataRow  item in dt.Rows)
                {
                    if (item1["FullName"]==item["FullName"])
                    {
                        if (item["ff"] == "Dự kiến")
                        {
                            foreach (DataColumn item2 in dt.Columns)
                            {
                                if (item2.ColumnName == Tomau.ToString("dd/MM/yyyy"))
                                {
                                    item[item2.ColumnName] = item1["tongtg"].ToString();
                                }
                            }
                        }
                    	
                    }else
                    {
                    
                    }
                }
                //foreach (DataColumn item2 in dt.Columns)
                //{
                //    if (item.ColumnName == Tomau.ToString("dd/MM/yyyy"))
                //    {
                        //if (item == item1["FullName"].ToString())
                        //{
                        //    if (View.GetRowCellValue(e.RowHandle, colThoiGian).ToString() == "Dự kiến")
                        //    {
                        //        if (e.Column == item)
                        //        {
                        //            int tongh = Convert.ToInt32(item1["tongtg"].ToString());
                        //            if (tongh <= 8)
                        //            {
                        //                e.DisplayText = item1["tongtg"].ToString();
                        //            }
                        //            else
                        //            {
                        //                int giat = tongh / 8;
                        //                int thua = tongh % 8;
                        //                e.DisplayText = "8";
                        //                grvNhanVien.SetFocusedRowCellValue("thu2", thua);
                        //            }
                        //        }
                        //    }
                        //}
                //    }
                //}
            }
        }
        void fff()
        {
            foreach (DataRow item in df.Rows)
            {

                DateTime dat = Convert.ToDateTime(item["ThoiGianBDDuKien"]);

                foreach (DataRow item1 in df.Rows)
                {
                    string p = item["ID"].ToString();
                    string p1 = item1["ID"].ToString();
                    if (item["ID"].ToString() != item1["ID"].ToString()&&Convert.ToDateTime(item1["ThoiGianKTDuKien"]) == dat && Convert.ToInt32(item1["du"]) != 0 && item["NguoiThietKe"].ToString() == item1["NguoiThietKe"].ToString())
                    {
                        item["tongtg"] = Convert.ToInt32(item["tongtg"]) + Convert.ToInt32(item1["du"]);
                        item1["du"] = 0.ToString();
                        if (Convert.ToInt32(item["tongtg"].ToString())>8)
                        {
                            item["du"] = (Convert.ToInt32(item["tongtg"].ToString()) % 8).ToString();
                            item["ThoiGianKTDuKien"] = Convert.ToDateTime(item["ThoiGianBDDuKien"]).AddDays((Convert.ToInt32(item["tongtg"].ToString()) / 8)).ToString();
                        }
                    }
                }
            }
            DataTable dh = df;
        }
    }
}