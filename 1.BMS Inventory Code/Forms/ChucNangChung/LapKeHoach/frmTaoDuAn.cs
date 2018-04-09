using BMS.Business;
using BMS.Model;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BMS
{
    public partial class frmTaoDuAn : _Forms
    {
        #region Constructor

        public frmTaoDuAn()
        {
            InitializeComponent();
        }
        public string _MaDuAn = "";
       
        private void frmTaoDuAn_Load(object sender, EventArgs e)
         {
             TextUtils.SetContainsFilter(grvData);
             TextUtils.SetContainsFilter(searchLookUpEdit1View);
             using (WaitDialogForm fWait = new WaitDialogForm("Vui lòng chờ trong giây lát...", "Đang xử lý dữ liệu"))
             {
                 loadYear();
                 leYear.EditValue = DateTime.Now.Year;
                 DataTable df = new DataTable();
                 df.Columns.Add("Name");
                 DataRow dr = df.NewRow();
                 dr["Name"] = "Hàng ngày";
                 df.Rows.Add(dr);
                 dr = df.NewRow();
                 dr["Name"] = "Phát sinh";
                 df.Rows.Add(dr);
                 leCongViec.DataSource = df;
                 leCongViec.DisplayMember = "Name";
                 leCongViec.ValueMember = "Name";
                 leCongViec.NullText = "Hàng ngày";
                 DataTable gh = TextUtils.Select("SELECT Code FROM [QLKHCV].[dbo].[Modules]");
                 leMaThietKe.DataSource = gh;
                 leMaThietKe.DisplayMember = "Code";
                 leMaThietKe.ValueMember = "Code";
                 //leMaThietKe
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
            leYear.Properties.DataSource = listYear;
        }
        private void leWeek_EditValueChanged(object sender, EventArgs e)
        {
            if (leWeek.EditValue == null) return;
            getSEDate(leWeek.EditValue.ToString());
            HienThi();
        }
        private void leYear_EditValueChanged(object sender, EventArgs e)
        {
            if (leYear.EditValue == null) return;

            loadWeek(TextUtils.ToInt(leYear.EditValue));
            leWeek.ItemIndex = WeeksInYear(DateTime.Now) - 1;
        }
        string[] _paraName = new string[2];
        object[] _paraValue = new object[2];
        DateTime NgayBD = TextUtils.ToDate1("01/01/1990 12:00:00 AM"), NgayKT = DateTime.Now.AddYears(1);
        DataTable Source;
        public void HienThi()
        {
            //_paraName[0] = "@NgayBD"; _paraValue[0] = NgayBD;
            //_paraName[1] = "@NgayKT"; _paraValue[1] = NgayKT;
            //DataTable hu = TextUtils.Select("select distinct ThoiGianBDDuKienSP as ThoiGianBDDuKien,ThoiGianKTDuKienSP as ThoiGianKTDuKien,Name from vHangMucCongViec where ThoiGianKTDuKien between " + NgayBD + " and " + NgayKT);
            Source = ModulesBO.Instance.LoadDataFromSP("sp_ThongKeTHeoNhom", "Source", null, null);
            //gridControl1.DataSource = Source;
            
        }
        void getSEDate(string WeekInfo)
        {
            string[] str = WeekInfo.Split(':');
            DateTime sta = TextUtils.ToDate1((str[1].Split('-')[0]).Trim());
            int tj = Convert.ToInt32(str[0].Substring(str[0].Length - 2, 2));

            gridBand1.Caption = "Tuần: " + tj;
            gridBand2.Caption = "Tuần: " + (tj + 1).ToString();
            gridColumn9.Caption = "Thứ 2 (" + sta.ToString("dd/MM") + ")";
            
            gridColumn9.ToolTip = sta.ToString("dd/MM/yyyy");
            NgayBD = TextUtils.ToDate1(gridColumn9.ToolTip);
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

            gridColumn15.Caption = "Thứ 2 (" + sta.AddDays(7).ToString("dd/MM") + ")";
            gridColumn15.ToolTip = sta.AddDays(7).ToString("dd/MM/yyyy");
            gridColumn16.Caption = "Thứ 3 (" + sta.AddDays(8).ToString("dd/MM") + ")";
            gridColumn16.ToolTip = sta.AddDays(8).ToString("dd/MM/yyyy");
            gridColumn17.Caption = "Thứ 4 (" + sta.AddDays(9).ToString("dd/MM") + ")";
            gridColumn17.ToolTip = sta.AddDays(9).ToString("dd/MM/yyyy");
            gridColumn18.Caption = "Thứ 5 (" + sta.AddDays(10).ToString("dd/MM") + ")";
            gridColumn18.ToolTip = sta.AddDays(10).ToString("dd/MM/yyyy");

            gridColumn19.Caption = "Thứ 6 (" + sta.AddDays(11).ToString("dd/MM") + ")";
            gridColumn19.ToolTip = sta.AddDays(11).ToString("dd/MM/yyyy");

            gridColumn20.Caption = "Thứ 7 (" + sta.AddDays(12).ToString("dd/MM") + ")";
            gridColumn20.ToolTip = sta.AddDays(12).ToString("dd/MM/yyyy");
            NgayKT = TextUtils.ToDate1(gridColumn20.ToolTip);
           
            gridControl1.Refresh();
        }
        public void loadWeek(int Year)
        {
            List<string> hgh = new List<string>();
            hgh = TextUtils.LoadAllWeekOfYear(Year);
            leWeek.Properties.DataSource = TextUtils.LoadAllWeekOfYear(Year);
        }
        void KT()
        {
            DataTable dt = TextUtils.Select("Select Name from UserGroup");
            //dt.Columns.Add("Thu2", typeof(string));
            //dt.Columns.Add("Thu3", typeof(string));
            //dt.Columns.Add("Thu4", typeof(string));
            //dt.Columns.Add("Thu5", typeof(string));
            //dt.Columns.Add("Thu6", typeof(string));
            //dt.Columns.Add("Thu7", typeof(string));

            //dt.Columns.Add("Thu21", typeof(string));
            //dt.Columns.Add("Thu31", typeof(string));
            //dt.Columns.Add("Thu41", typeof(string));
            //dt.Columns.Add("Thu51", typeof(string));
            //dt.Columns.Add("Thu61", typeof(string));
            //dt.Columns.Add("Thu71", typeof(string));
            gridControl1.DataSource = dt;


            //DataTable dt1 = TextUtils.Select("select * from vHangMucCongViec");

        }
        #endregion

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
            try
            {
                Save(ref m_DataSource);
                if (kt==false)
                {
                    return;
                }else
                {
                
                }
                {
                    grvData.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
                    PageBase.StateButton(false, btnNew, btnEdit, btnSave, btnCancel, btnDelete);
                    PageBase.VisibleColumnInGrid(grvData, false);
                    Global_Add.sFormStatus = Global_Add.FormStatus.View;
                    SelectAll(ref m_DataSource, grdData);
                }
                HienThi();
                bandedGridView1.FocusedRowHandle = -1; bandedGridView1.FocusedRowHandle = 0;
            }
            catch (Exception)
            {
                
                throw;
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
                                 if (HangMucCongViecBO.Instance.CheckExist("SanPhamDAID", IDs))
                                 {
                                     XtraMessageBox.Show("Mẫu tin " + "" + " đang được sử dụng, bạn không thể xóa nó", "Thông báo");
                                     return;
                                 }
                                 SanPhamDABO.Instance.Delete(IDs);
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

        private void searchLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                SelectAll(ref m_DataSource, grdData);
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        
        private void frmTaoDuAn_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
        #endregion

        #region Variable

        DataTable m_DataSource = new DataTable(); 
        #endregion

        #region Method
        public void Save(ref DataTable dt)
        {
            if (searchLookUpEdit1.EditValue == null)
            {
                XtraMessageBox.Show("Xin mời bạn chọn dự án");
                return;
            }
            grvData.FocusedRowHandle = -1;
            if (kt==false)
            {
                return;
            }
            DataTable dtRemine;
            dtRemine = grdData.DataSource as DataTable;
            {
                for (int i = 0; i < dtRemine.Rows.Count; i++)
                {
                    SanPhamDAModel model = new SanPhamDAModel();
                    model.ProjectsID = searchLookUpEdit1.EditValue.ToString();
                    model.TenTheoHopDong = dtRemine.Rows[i]["TenTheoHopDong"].ToString();
                    model.MaTheoHopDong = dtRemine.Rows[i]["MaTheoHopDong"].ToString();
                    model.TenTheoThietKe = dtRemine.Rows[i]["TenTheoThietKe"].ToString();
                    model.MaTheoThietKe = dtRemine.Rows[i]["MaTheoThietKe"].ToString();
                    model.ThoiGianThietKe = TextUtils.ToInt(dtRemine.Rows[i]["ThoiGianThietKe"].ToString());
                    model.ThoiGianBDDuKien = TextUtils.ToDate(dtRemine.Rows[i]["ThoiGianBDDuKien"].ToString());
                    model.ThoiGianBDThucTe = (dtRemine.Rows[i]["ThoiGianBDThucTe"].ToString());
                    model.ThoiGianKTDuKien = TextUtils.ToDate(dtRemine.Rows[i]["ThoiGianKTDuKien"].ToString());
                    model.ThoiGianKTThucTe = (dtRemine.Rows[i]["ThoiGianKTThucTe"].ToString());
                    model.TinhTrang = dtRemine.Rows[i]["TinhTrang"].ToString(); ;
                    model.NhomPhuTrach = dtRemine.Rows[i]["NhomPhuTrach"].ToString(); ;
                    model.MucDoUuTien = dtRemine.Rows[i]["MucDoUuTien"].ToString(); ;
                    model.LoaiCongViec = dtRemine.Rows[i]["LoaiCongViec"].ToString(); ;
                    if (dtRemine.Rows[i][colID.FieldName] == DBNull.Value) //add new)
                    {
                        //if (XtraMessageBox.Show("Dữ liệu đã bị thay đổi\nBạn có muốn lưu vào cơ sở dữ liệu không?","Xác nhận",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
                        {
                            SanPhamDABO.Instance.Insert(model);
                        }
                        {
                            
                        }
                    }
                    else
                    {
                        //if (XtraMessageBox.Show("Dữ liệu đã bị thay đổi\nBạn có muốn lưu vào cơ sở dữ liệu không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            model.ID = Convert.ToInt32(dtRemine.Rows[i]["ID"].ToString());
                            SanPhamDABO.Instance.Update(model);
                        }
                        //XtraMessageBox.Show("U thành công!", "Thông báo");
                    }
                }
                XtraMessageBox.Show("Xử lý thành công!", "Thông báo");
            }
        }
        public void SelectAll(ref DataTable dt, GridControl grd)
        {
            
            LoadComBo();
            try
            {
                if (searchLookUpEdit1.EditValue!=null)
                {
                    dt = TextUtils.Select("SELECT * FROM vSanPham WHERE (ProjectsID = N'" + searchLookUpEdit1.EditValue.ToString() + "')");
                    if (dt==null)
                    {
                        dt = SanPhamDABO.KhoiTaoGrid();
                    }
                    grdData.DataSource = dt;
                }
            }
            catch (Exception)
            {
                throw;
            }
            //leWeek_EditValueChanged(null, null);
        } 
        public void LoadComBo()
        {
            DataTable dt = TextUtils.Select("select ProjectName collate SQL_Latin1_General_CP1_CI_AS as ProjectName,ProjectCode,ProjectId  collate SQL_Latin1_General_CP1_CI_AS as ProjectId from ProjectSyn");
            searchLookUpEdit1.Properties.DataSource = dt;
            searchLookUpEdit1.Properties.DisplayMember = "ProjectName";
            searchLookUpEdit1.Properties.ValueMember = "ProjectId";
          //lookUpEdit1.Properties.DataSource
        }

        #endregion

        private void bandedGridView1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            try
            {
                GridView View = sender as GridView;

                if (Source!=null)
                {
                    foreach (DataRow item1 in Source.Rows)
                    {
                        if (View.GetRowCellValue(e.RowHandle, colNhom).ToString() == item1["Name"].ToString())
                        {
                            DateTime Tomau = TextUtils.ToDate(item1["ThoiGianBDDuKien"].ToString());
                            DateTime Tomau1 = TextUtils.ToDate(item1["ThoiGianKTDuKien"].ToString());
                            _paraName[0] = "@NgayBD"; _paraValue[0] = Tomau;
                            _paraName[1] = "@NgayKT"; _paraValue[1] = Tomau1;
                            //DataTable hu = TextUtils.Select("select distinct ThoiGianBDDuKienSP as ThoiGianBDDuKien,ThoiGianKTDuKienSP as ThoiGianKTDuKien,Name from vHangMucCongViec where ThoiGianKTDuKien between " + NgayBD + " and " + NgayKT);
                            DataTable Source2 = ModulesBO.Instance.LoadDataFromSP("sp_ThongKeTHeoNhom1", "Source",_paraName, _paraValue);
                            if (Source2!=null)
                            {
                                if(Source2.Rows.Count>0)
                                {
                                    Tomau1=Tomau1.AddDays(Source2.Rows.Count);
                                }
                            }
                            if (TextUtils.DateDiff("d", Tomau1, Tomau) >= 0)
                            {
                                foreach (GridColumn item in View.Columns)
                                {
                                    for (int i = 0; i <= TextUtils.DateDiff("d", Tomau1, Tomau); i++)
                                    {
                                        DateTime tBNgay = Tomau.AddDays(i);
                                        if (TextUtils.DateDiff("d", Tomau1, tBNgay) >= 0)
                                        {
                                            if (tBNgay.ToString("dd/MM/yyyy") == item.ToolTip)
                                            {
                                                if (e.Column == item)
                                                {
                                                    if (e.Appearance.BackColor == Color.Orange)
                                                    {
                                                        e.Appearance.BackColor = Color.Red;
                                                    }
                                                    else
                                                    {
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
            catch (Exception)
            {
                return;
                throw;
            }
        }

        private void grvData_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.Value == null)
            {
                return;
            }
            try
            {
                if (grvData.FocusedColumn == colThoiGianThietKe)
                {
                    if (Convert.ToInt32(e.Value) < 0)
                    {
                        e.ErrorText = "Số phải lớn hơn hoặc bằng 0";
                        e.Valid = false;
                    }
                }else
                if (grvData.FocusedColumn == colThoiGianBDDuKien)
                {
                    string gg = Convert.ToDateTime(e.Value).ToString("yyyy/MM/dd");
                    DataTable fg = TextUtils.Select("SELECT ThoiGianBDDuKien FROM SanPhamDA WITH (NOLOCK) WHERE ThoiGianBDDuKien = '" + gg + "' AND (NhomPhuTrach = N'" + view.GetFocusedRowCellValue(colNhomPhuTrach) + "')");
                    if (fg.Rows.Count>0)
                    {
                        e.ErrorText = "Ngày tháng bị trùng";
                        e.Valid = false;
                        return;
                    }
                }
            }
            catch (Exception)
            {
                e.ErrorText = "Số phải lớn hơn hoặc bằng 0";
                e.Valid = false;
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                string FileName = Application.StartupPath + "\\Templates\\ImportSP.xlsx";
                Process.Start(FileName);
                if (MessageBox.Show("Bạn đã lưu lại file Excel chưa?\n Sẵn sàng Import vào phần mềm!", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    btnNew_Click(null, null);
                    btnSave.Visible = true;
                    DataTable dt = TextUtils.ExcelToDatatable(FileName, "SanPhamDA");

                    if (dt.Rows.Count <= 0) return;

                    dt.Columns[0].ColumnName = "TenTheoHopDong";
                    dt.Columns[1].ColumnName = "MaTheoHopDong";
                    dt.Columns[2].ColumnName = "SL";

                    if (dt.Rows.Count > 0)
                    {
                        IEnumerable<DataRow> dr= (from order in dt.AsEnumerable()
                              where order.Field<string>("TenTheoHopDong") != "" && order.Field<string>("TenTheoHopDong") != null
                              select order);
                        if (dr.Count() > 0)
                        {
                            dt = dr.CopyToDataTable();
                        }
                        else
                            dt = new DataTable();
                        //.CopyToDataTable();
                    }
                    DataTable dtt = m_DataSource;
                    foreach (DataRow item in dt.Rows)
                    {
                        dtt.ImportRow(item);
                    }
                    grdData.DataSource = dtt;
                    grvData.BestFitColumns();
                    grdData.Focus();
                }
            }
            catch (Exception ex)
            {
                TextUtils.ShowError(ex);
            }
        }

        private void frmTaoDuAn_Shown(object sender, EventArgs e)
        {
            SelectAll(ref m_DataSource, grdData);
            if (_MaDuAn != "")
            {
                searchLookUpEdit1.EditValue = _MaDuAn;
            }
            KT();
            grvData.BestFitColumns();
            PageBase.StateButton(false, btnNew, btnEdit, btnSave, btnCancel, btnDelete);
            PageBase.VisibleColumnInGrid(grvData, false);

            LeNhom.DataSource = TextUtils.Select("SELECT Name,Code,ID FROM UserGroup");
            LeNhom.DisplayMember = "Name";
            LeNhom.ValueMember = "ID"; 
        }
        bool kt = false;
        private void grvData_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            GridView view = sender as GridView;
            try
            {
                kt = true;
                #region check vailidate
                //string gg=Convert.ToDateTime(view.GetRowCellValue(e.RowHandle, colThoiGianBDDuKien)).ToString("yyyy/MM/dd");
                //if (SanPhamDABO.Instance.CheckExist("ThoiGianBDDuKien",gg))
                //{
                //    e.Valid = false;
                //    return;
                //}else
                //{
                
                //}
                if (view.GetRowCellValue(e.RowHandle, colTenTheoHopDong).ToString() == string.Empty)
                {
                    e.Valid = false; kt = false;
                    return;
                }
                else
                    if (view.GetRowCellValue(e.RowHandle, colMaTheoThietKe).ToString() == string.Empty)
                    {
                        e.Valid = false; kt = false;
                        return;
                    }
                    else
                        if (view.GetRowCellValue(e.RowHandle, colThoiGianThietKe).ToString() == string.Empty)
                        {
                            kt = false;e.Valid = false;
                            return;
                        }
                        else
                            if (view.GetRowCellValue(e.RowHandle, colThoiGianBDDuKien).ToString() == string.Empty)
                            {
                                kt = false;e.Valid = false;
                                return;
                            }
                            else
                                if (view.GetRowCellValue(e.RowHandle, colNhomPhuTrach).ToString() == string.Empty)
                                {
                                    kt = false;e.Valid = false;
                                    return;
                                }
                                else
                                    if (view.GetRowCellValue(e.RowHandle, colMucDoUuTien).ToString() == string.Empty)
                                    {
                                        kt = false;e.Valid = false;
                                        return;
                                    }
                                    else
                                        if (view.GetRowCellValue(e.RowHandle, colLoaiCongViec).ToString() == string.Empty)
                                        {
                                            kt = false;e.Valid = false;
                                            return;
                                        }

                int l = Convert.ToInt32(view.GetRowCellValue(e.RowHandle, colThoiGianThietKe));
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
                SanPhamDAModel model = new SanPhamDAModel();
                model.ProjectsID = searchLookUpEdit1.EditValue.ToString();
                model.TenTheoHopDong = view.GetRowCellValue(e.RowHandle, colTenTheoHopDong).ToString(); //dtRemine.Rows[i]["TenTheoHopDong"].ToString();
                model.MaTheoHopDong = view.GetRowCellValue(e.RowHandle, colMaTheoHopDong).ToString();//dtRemine.Rows[i]["MaTheoHopDong"].ToString();
                model.TenTheoThietKe = view.GetRowCellValue(e.RowHandle, colTenTheoThietKe).ToString();//dtRemine.Rows[i]["TenTheoThietKe"].ToString();
                model.MaTheoThietKe = view.GetRowCellValue(e.RowHandle, colMaTheoThietKe).ToString();//dtRemine.Rows[i]["MaTheoThietKe"].ToString();
                model.ThoiGianThietKe = TextUtils.ToInt(view.GetRowCellValue(e.RowHandle, colThoiGianThietKe).ToString());//dtRemine.Rows[i]["ThoiGianThietKe"].ToString());
                model.ThoiGianBDDuKien = TextUtils.ToDate(view.GetRowCellValue(e.RowHandle, colThoiGianBDDuKien).ToString());//dtRemine.Rows[i]["ThoiGianBDDuKien"].ToString());
                model.ThoiGianBDThucTe = view.GetRowCellValue(e.RowHandle, colThoiGianBDThucTe).ToString();//(dtRemine.Rows[i]["ThoiGianBDThucTe"].ToString());
                model.ThoiGianKTDuKien = TextUtils.ToDate(view.GetRowCellValue(e.RowHandle, colThoiGianKTDuKien).ToString());//dtRemine.Rows[i]["ThoiGianKTDuKien"].ToString());
                model.ThoiGianKTThucTe = view.GetRowCellValue(e.RowHandle, colThoiGianKTThucTe).ToString();//(dtRemine.Rows[i]["ThoiGianKTThucTe"].ToString());
                model.TinhTrang =view.GetRowCellValue(e.RowHandle, colTinhTrang).ToString(); //dtRemine.Rows[i]["TinhTrang"].ToString(); ;
                model.NhomPhuTrach =view.GetRowCellValue(e.RowHandle, colNhomPhuTrach).ToString(); //dtRemine.Rows[i]["NhomPhuTrach"].ToString(); ;
                model.MucDoUuTien = view.GetRowCellValue(e.RowHandle, colMucDoUuTien).ToString();//dtRemine.Rows[i]["MucDoUuTien"].ToString(); ;
                model.LoaiCongViec = view.GetRowCellValue(e.RowHandle, colLoaiCongViec).ToString();//dtRemine.Rows[i]["LoaiCongViec"].ToString(); ;
                if (view.GetRowCellValue(e.RowHandle, colID) == DBNull.Value) //add new)
                {
                    if (XtraMessageBox.Show("Dữ liệu đã bị thay đổi\nBạn có muốn lưu vào cơ sở dữ liệu không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        SanPhamDABO.Instance.Insert(model);
                    }
                    else
                        e.Valid = true;
                }
                else
                {
                    if (XtraMessageBox.Show("Dữ liệu đã bị thay đổi\nBạn có muốn lưu vào cơ sở dữ liệu không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        model.ID = Convert.ToInt32(view.GetRowCellValue(e.RowHandle, colID).ToString());
                        SanPhamDABO.Instance.Update(model);
                    }
                    else
                        e.Valid = true;
                }
                HienThi(); bandedGridView1.FocusedRowHandle = -1; bandedGridView1.FocusedRowHandle = 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void grvData_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            try
            {
                GridView View = sender as GridView;
                if (TextUtils.ToInt(View.GetRowCellValue(e.RowHandle, colThoiGianThietKe).ToString()) < TextUtils.ToInt(View.GetRowCellValue(e.RowHandle, colTongTG).ToString()))
                {
                    e.Appearance.BackColor = Color.Green;
                }
            }
            catch (Exception)
            {
                return;
                throw;
            }
        }

        private void grvData_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            //if (e.Column == colMaTheoHopDong)
            //{
            //    string s = e.Value.ToString();
            //    grvData.SetRowCellValue(e.RowHandle, colMaTheoHopDong, s.ToUpper());
            //    return;
            //}
            if (e.Column != colTenTheoHopDong)
            {
                return;
            }
            grvData.SetFocusedRowCellValue(colLoaiCongViec, "Hàng ngày");
        }
      
    }
}
