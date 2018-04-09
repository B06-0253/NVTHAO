using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
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
using DevExpress.Data;
using DevExpress.XtraGrid.Columns;

namespace BMS
{
    public partial class frmMainVatTu : _Forms
    {
        #region Constructor
        public frmMainVatTu()
        {
            InitializeComponent();
        } 
        #endregion

        #region Bien
        DataTable m_DataSource = new DataTable(); 
        List<string> kkkkkk = new List<string>();
        string[] TimeSet;//////=new string[]();
        #endregion

        #region Constructor
        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                SelectAll(ref m_DataSource, grdData);
                //grvData.BestFitColumns();
                PageBase.StateButton(false, btnNew, btnSua, btnGhi, btnHuy, btnXoa);
                PageBase.VisibleColumnInGrid(grvData, false);
                // kkk();
                //Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                //key.SetValue("Theo dõi vật tư", @Application.StartupPath+"\\TheoDoiVatTu.exe");

                grvData.OptionsView.AllowHtmlDrawHeaders = true;
                grvData.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
                grvData.ColumnPanelRowHeight = 40;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        } 
        #endregion

        #region Method
        public void View_popup()
        {
            string ngaydukien = "", ngaythucte = "", Tb = "";
            for (int i = 0; i < grvData.RowCount; i++)
            {
                DataTable dt = TextUtils.Select("select * from vCheckPermission where Code ='frmMainVatTu_ThongBao' and UserID=" + Global.UserID);
                if (dt.Rows.Count > 0 || grvData.GetRowCellValue(i, colUserID).ToString() == Global.UserID.ToString())
                {
                    string ma = grvData.GetRowCellValue(i, colMaVatTu).ToString();
                    string ten = grvData.GetRowCellValue(i, colTenVatTu).ToString();
                    string tenNV = grvData.GetRowCellDisplayText(i,colUserID).ToString();
                    if (grvData.GetRowCellValue(i, colNgayVeDuKien).ToString() == "")
                    {
                        ngaydukien += "Chưa có ngày dự kiến cho vật tư " + ten + "- " + ma + " " + tenNV + "\n";
                        continue;
                    }
                    if (DateTime.Now >= Convert.ToDateTime(grvData.GetRowCellValue(i, colNgayVeDuKien)))
                    {
                        if (grvData.GetRowCellValue(i, colNgayThucTe).ToString() == "")
                        {
                            ngaythucte += "Chưa có ngày về thực tế cho vật tư " + ten + "- " + ma + " " + tenNV + "\n";
                            continue;
                        }
                    }
                }
                //else
                //{
                //    if (grvData.GetRowCellValue(i, colUserID).ToString() == Global.UserID.ToString())
                //    {
                //        string ma = grvData.GetRowCellValue(i, colMaVatTu).ToString();
                //        if (grvData.GetRowCellValue(i, colNgayVeDuKien).ToString() == "")
                //        {
                //            ngaydukien += "Chưa có ngày dự kiến cho vật tư mã " + ma + "\n";
                //            continue;
                //        }
                //        if (DateTime.Now >= Convert.ToDateTime(grvData.GetRowCellValue(i, colNgayVeDuKien)))
                //        {
                //            if (grvData.GetRowCellValue(i, colNgayThucTe).ToString() == "")
                //            {
                //                ngaythucte += "Chưa có ngày về thực tế cho vật tư mã " + ma + "\n";
                //                continue;
                //            }
                //        }
                //    }
                //}
            }
            if (ngaythucte.Trim() != "")
            {
                Tb += ngaythucte;
            }
            if (ngaydukien.Trim() != "")
            {
                Tb += ngaydukien;
            }
            if (Tb.Trim() != "")
            {
                PopUp_No(Tb);
            }
        }
        public void PopUp_No(string ttt)
        {
            popupNotifier1.TitleText = "Thông Báo";
            popupNotifier1.ContentText = ttt;
            popupNotifier1.ShowCloseButton = true;
            popupNotifier1.ShowOptionsButton = false;
            popupNotifier1.ShowGrip = false;
            popupNotifier1.BorderColor = Color.Green;
            popupNotifier1.Delay = 10000000;
            popupNotifier1.AnimationInterval = 10;
            popupNotifier1.AnimationDuration = 1000;
            popupNotifier1.TitlePadding = new Padding(0);
            popupNotifier1.ContentPadding = new Padding(0);
            popupNotifier1.ImagePadding = new Padding(0);
            //for (int i = 0; i < ttt.Length; i++)
            //{
            //    if (ttt[i]=='\')
            //    {

            //    }
            //}
            popupNotifier1.Scroll = true; 
            popupNotifier1.Size = new Size(400, 200);
            popupNotifier1.TitleColor = Color.Red;
            popupNotifier1.Popup();
        }
        private bool Check_Valid(DataTable dt)
        {
            DataTable dtRemine;
            dtRemine = dt.GetChanges();
            if (dtRemine != null)
            {
                for (int i = 0; i < dtRemine.Rows.Count; i++)
                {
                    if (dtRemine.Rows[i]["MaVatTu"].ToString().Trim() == "")
                    {
                        XtraMessageBox.Show("Vui lòng điền mã vật tư!", "Thông báo");
                        return false;
                    }
                }
            }
            return true;
        }
        
        public void Save(ref DataTable dt)
        {
            Luu = false;
            grvData.PostEditor();
            //if (!Check_Valid(dt))
            //{

            //    return;
            //}
            try
            {
                TheoDoiVatTu_BLL.YeuCauVatTu_BLL obj = new TheoDoiVatTu_BLL.YeuCauVatTu_BLL();
                DataTable dtRemine;
                dtRemine = dt.GetChanges();
                if (dtRemine != null)
                {
                    for (int i = 0; i < dtRemine.Rows.Count; i++)
                    {
                        if (dtRemine.Rows[i]["Status"].ToString() == "3" || dtRemine.Rows[i]["Status"].ToString() == "2")
                        {
                            continue;
                        }
                        YeuCauVatTuModel model = new YeuCauVatTuModel();
                        model.UserID = Global.UserID;
                        model.TenVatTu = dtRemine.Rows[i]["TenVatTu"].ToString();
                        model.MaVatTu = dtRemine.Rows[i]["MaVatTu"].ToString();
                        model.Hang = dtRemine.Rows[i]["Hang"].ToString();
                        model.MaSP = dtRemine.Rows[i]["MaSP"].ToString();
                        model.TenDuAn = dtRemine.Rows[i]["TenDuAn"].ToString();
                        model.MaDuAn = dtRemine.Rows[i]["MaDuAn"].ToString();//["MaDuAn"].ToString();
                        model.SoLuong = dtRemine.Rows[i]["SoLuong"].ToString();
                        model.NgayYeuCau = (dtRemine.Rows[i]["NgayYeuCau"].ToString());//["NgayYeuCau"].ToString();
                        model.NgayVeDuKien = (dtRemine.Rows[i]["NgayVeDuKien"].ToString());//["NgayVeDuKien"].ToString();
                        model.NgayThucTe = (dtRemine.Rows[i]["NgayThucTe"].ToString());//["NgayThucTe"].ToString();
                        model.ThoiGianDatHangTHucTe = dtRemine.Rows[i]["ThoiGianDatHangTHucTe"].ToString();//["ThoiGianDatHangTHucTe"].ToString();
                        model.NguyenNhanCham = dtRemine.Rows[i]["NguyenNhanCham"].ToString();//["NguyenNhanCham"].ToString();
                        model.GhiChu = dtRemine.Rows[i]["GhiChu"].ToString();//["GhiChu"].ToString();
                        model.NgayVeDuKien2 = dtRemine.Rows[i]["NgayVeDuKien2"].ToString();
                        model.NgayVeDuKien3 = dtRemine.Rows[i]["NgayVeDuKien3"].ToString();
                        if (dtRemine.Rows[i][colID.FieldName] == DBNull.Value) //add new
                        {

                            YeuCauVatTuBO.Instance.Insert(model);
                        }
                        else
                        {
                            if (dtRemine.Rows[i]["UserID"].ToString() == Global.UserID.ToString())
                            {
                                model.ID = Convert.ToInt32(dtRemine.Rows[i]["ID"].ToString());
                                YeuCauVatTuBO.Instance.Update(model);
                            }
                        }
                        Luu = true;
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        public void SelectAll(ref DataTable dt, GridControl grd)
        {
            try
            {
                TheoDoiVatTu_BLL.YeuCauVatTu_BLL obj = new TheoDoiVatTu_BLL.YeuCauVatTu_BLL();
                TheoDoiVatTu_Entities.YeuCauVatTu_Entities p = new TheoDoiVatTu_Entities.YeuCauVatTu_Entities();
                p.UserID = Global.UserID;
                try
                {
                    dt = TextUtils.Select("select * from vCheckPermission where Code ='frmMainVatTu_ViewAll' and UserID=" + Global.UserID);
                    if (dt.Rows.Count > 0)
                    {
                        dt = obj.SelectAll();
                        //bar1.Visible = false;
                    }
                    else
                    {
                        dt = obj.SelectByID(p);
                    }
                }
                catch (Exception)
                {
                    dt = obj.SelectByID(p);
                }                       
                    
                if (dt == null)
                {
                    dt = new DataTable();
                    dt.Columns.Add("ID", typeof(int));
                    dt.Columns.Add("TenVatTu", typeof(string));
                    dt.Columns.Add("MaVatTu", typeof(string));
                    dt.Columns.Add("Hang", typeof(string));
                    dt.Columns.Add("MaSP", typeof(string));
                    dt.Columns.Add("TenDuAn", typeof(string));
                    dt.Columns.Add("MaDuAn", typeof(string));
                    dt.Columns.Add("SoLuong", typeof(int));
                    dt.Columns.Add("NgayYeuCau", typeof(DateTime));
                    dt.Columns.Add("NgayVeDuKien", typeof(DateTime));
                    dt.Columns.Add("NgayVeDuKien2", typeof(DateTime));
                    dt.Columns.Add("NgayVeDuKien3", typeof(DateTime));
                    dt.Columns.Add("NgayThucTe", typeof(DateTime));
                    dt.Columns.Add("ThoiGianDatHangTHucTe", typeof(string));
                    dt.Columns.Add("NguyenNhanCham", typeof(string));
                    dt.Columns.Add("GhiChu", typeof(string));
                    dt.Columns.Add("UserID", typeof(string));
                }
                dt.Columns.Add("ThoiGianDatHangThucTe", typeof(string));
                dt.Columns.Add("STT", typeof(string));
                dt.Columns.Add("Status", typeof(int));
                TheoDoiVatTu_BLL.Users_BLL pl = new TheoDoiVatTu_BLL.Users_BLL();
                colNguoiYeuCau.DataSource = pl.SelectAll();
                colNguoiYeuCau.DisplayMember = "FullName";
                colNguoiYeuCau.ValueMember = "ID";
                colNguoiYeuCau.NullText = "Tên nhân viên";
                ChuaXong = 0; Xong = 0; GanXong = 0;

                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DataRow row = dt.Rows[i];
                        if (row["NgayYeuCau"].ToString().Trim()!="")
                        {
                            if (row["NgayThucTe"].ToString().Trim()!="")
                            {
                                DateTime ngaymuon = Convert.ToDateTime(row["NgayYeuCau"]);
                                DateTime ngaytra = Convert.ToDateTime(row["NgayThucTe"]);
                                TimeSpan tim = ngaytra - ngaymuon;
                                row["ThoiGianDatHangThucTe"] = tim.Days.ToString();  
                            }

                        }
                        if (row["NgayThucTe"].ToString().Trim()=="")
                        {
                            row["Status"] =0;
                            ChuaXong++;
                        }
                        if (row["NgayThucTe"].ToString().Trim() != "")
                        {
                            TimeSpan tim = new TimeSpan();
                            int k = 0;
                            if (row["NgayVeDuKien3"].ToString().Trim() != "")
                            {
                                DateTime ngaymuon = Convert.ToDateTime(row["NgayVeDuKien3"]);
                                DateTime ngaytra = Convert.ToDateTime(row["NgayThucTe"]);
                                tim = ngaytra - ngaymuon;
                                k = TextUtils.DateDiff("d", ngaytra, ngaymuon);
                            }else
                            if (row["NgayVeDuKien2"].ToString().Trim() != "")
                            {
                                DateTime ngaymuon = Convert.ToDateTime(row["NgayVeDuKien2"]);
                                DateTime ngaytra = Convert.ToDateTime(row["NgayThucTe"]);
                                tim = ngaytra - (ngaymuon); k = TextUtils.DateDiff("d", ngaytra, ngaymuon);
                            }
                            else
                            if (row["NgayVeDuKien"].ToString().Trim() != "")
                            {
                                DateTime ngaymuon = Convert.ToDateTime(row["NgayVeDuKien"]);
                                DateTime ngaytra = Convert.ToDateTime(row["NgayThucTe"]);
                                tim = ngaytra - ngaymuon; k = TextUtils.DateDiff("d", ngaytra, ngaymuon);
                            }
                            {
                                if (tim.Days > 0)
                                {
                                    if (row["NguyenNhanCham"].ToString() != "")
                                    {
                                        row["Status"] = 2;
                                        Xong++;
                                    }
                                    else
                                    {
                                        row["Status"] = 1;
                                        ChuaXong++;
                                        GanXong++;
                                    }
                                }
                                if (tim.Days <= 0)
                                {
                                    row["Status"] = 3;
                                    Xong++;
                                }
                            }
                        }
                        
                    }

                }
                DataView dv = dt.DefaultView;

                dv.Sort = "Status ASC";

                dt = dv.ToTable();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow row = dt.Rows[i];
                    row["STT"] = i + 1;
                }
                grd.DataSource = dt;
                grvData.BestFitColumns();
                grvData.Columns["Status"].SortOrder = ColumnSortOrder.Ascending;
                toolStripLabel1.Text = "Số vật tư chưa hoàn thành " + ChuaXong;
                View_popup();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void View_NhatKy()
        {
            string thb = "Bạn đã ghi nhật ký công việc chưa! Nếu chưa thì ghi vào nhật ký đi nhé";

            if (thb.Trim() != "")
            {
                PopUp_No(thb);
            }
        }
        private int ChuaXong = 0, Xong = 0, GanXong = 0;
        #endregion

        #region Events
     

        private void btnAddNew_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            grvData.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            PageBase.StateButton(true, btnNew, btnSua, btnGhi, btnHuy, btnXoa);
            PageBase.VisibleColumnInGrid(grvData, true);
            Global_Add.sFormStatus = Global_Add.FormStatus.Addnew;
        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            PageBase.StateButton(true, btnNew, btnSua, btnGhi, btnHuy, btnXoa);
            PageBase.VisibleColumnInGrid(grvData, true);
            Global_Add.sFormStatus = Global_Add.FormStatus.Edit;
        }

        bool Luu = false;
        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Save(ref m_DataSource);
            {
                grvData.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
                PageBase.StateButton(false, btnNew, btnSua, btnGhi, btnHuy, btnXoa);
                PageBase.VisibleColumnInGrid(grvData, false);
                Global_Add.sFormStatus = Global_Add.FormStatus.View;
                SelectAll(ref m_DataSource, grdData);
            }
        }

        private void btnCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SelectAll(ref m_DataSource, grdData);
            PageBase.StateButton(false, btnNew, btnSua, btnGhi, btnHuy, btnXoa);
            PageBase.VisibleColumnInGrid(grvData, false);
            grvData.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (grvData.FocusedRowHandle < 0)
                {
                    XtraMessageBox.Show("Không có mẫu tin nào để xóa", "Thông báo", MessageBoxButtons.OK);
                }
                else
                {
                    if (grvData.GetRowCellValue(grvData.FocusedRowHandle, colStatus).ToString() == "3" || grvData.GetRowCellValue(grvData.FocusedRowHandle, colStatus).ToString() == "2")
                    {
                        XtraMessageBox.Show("Bạn không thể xóa mẫu tin này vì nó đã hoàn thành", "Thông báo", MessageBoxButtons.OK);
                        return;
                    }
                    if (XtraMessageBox.Show("Bạn có chắc xóa mẫu tin này không?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        if (grvData.GetRowCellValue(grvData.FocusedRowHandle, colUserID).ToString()==Global.UserID.ToString())
                        {
                            TheoDoiVatTu_Entities.YeuCauVatTu_Entities p = new TheoDoiVatTu_Entities.YeuCauVatTu_Entities();
                            p.ID = Convert.ToInt32(grvData.GetRowCellValue(grvData.FocusedRowHandle, colID).ToString());
                            TheoDoiVatTu_BLL.YeuCauVatTu_BLL obj = new TheoDoiVatTu_BLL.YeuCauVatTu_BLL();
                            obj.Delete(p);
                            grvData.DeleteSelectedRows();
                            SelectAll(ref m_DataSource, grdData); 
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private void grvData_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
        }

        private void grdData_Click(object sender, EventArgs e)
        {
        }

        private void grvData_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            grvData.PostEditor();
        }

        private void grvData_Click(object sender, EventArgs e)
        {           
        }

        private void grvData_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            if (e.Value==null)
            {
                return;
            }
            try
            {
                if (grvData.FocusedColumn==colSoLuong)
                {
                    if (Convert.ToInt32(e.Value)<0)
                    {
                        e.ErrorText = "Số lượng phải lớn hơn hoặc bằng 0";
                        e.Valid = false;
                    }
                }
            }
            catch (Exception ex)
            {
                e.ErrorText = "Số lượng phải lớn hơn hoặc bằng 0";
                e.Valid = false;
            }
        }

        private void grvData_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            try
            {
                GridView View = sender as GridView;
                if (e.RowHandle >= 0)
                {
                    if (View.GetRowCellValue(e.RowHandle, colNgayVeDuKien).ToString().Trim() != "")
                    {
                        if (View.GetRowCellValue(e.RowHandle, colNgayThucTe).ToString().Trim() != "")
                        {

                            int ngaymuon = Convert.ToInt32(View.GetRowCellValue(e.RowHandle, colStatus));
                            //DateTime ngaytra = Convert.ToDateTime(View.GetRowCellValue(e.RowHandle, colNgayThucTe));
                            //TimeSpan tim = ngaytra - ngaymuon;
                            //if (ngaymuon <=3 && e.Column == colNguyenNhanCham)
                            //{
                            //    if (View.GetRowCellValue(e.RowHandle, colNguyenNhanCham).ToString().Trim() == "")
                            //    {
                            //        e.Appearance.BackColor = Color.Red;
                            //    }
                            //    else
                            //        e.Appearance.BackColor = Color.Yellow;
                            //}
                            if (ngaymuon ==3 && e.Column == colNguyenNhanCham)
                            {
                                e.Appearance.BackColor = Color.White;

                            }else
                            if (ngaymuon == 2 && e.Column == colNguyenNhanCham)
                            {
                                e.Appearance.BackColor = Color.Green;
                            }
                            else
                            if (ngaymuon == 1 && e.Column == colNguyenNhanCham)
                            {
                                e.Appearance.BackColor = Color.Yellow;
                            }
                            else
                            if (ngaymuon == 0 && e.Column == colNguyenNhanCham)
                            {
                                e.Appearance.BackColor = Color.Red;
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

        private void frmMain_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == WindowState)
                Hide();
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            // Hiển thị lại Form nếu doubleclick vào icon dưới System tray
            Show();
            WindowState = FormWindowState.Maximized;
        }

        private void mởGiaoDiệnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Maximized;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                ConfigSystemModel model = (ConfigSystemModel)ConfigSystemBO.Instance.FindByAttribute("KeyName", "SetTimeTheoDoi")[0];

                TimeSet = model.KeyValue.Split(',');
                for (int i = 0; i < TimeSet.Count(); i++)
                {
                    string time = Convert.ToDateTime(TimeSet[i]).ToString("t");
                    if (DateTime.Now.ToString("t") == time)
                    {
                        View_popup();
                    }
                }
                if (DateTime.Now.ToString("t") == Convert.ToDateTime("16:40").ToString("t"))
                {
                    //View_NhatKy();
                }
            }
            catch (Exception)
            {
               
            }
            
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmTheoDoiImportExcel frm = new frmTheoDoiImportExcel();
            if (frm.ShowDialog()==DialogResult.OK)
            {
                SelectAll(ref m_DataSource,grdData);
            }
        }

        private void btnSetTime_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //frmSetTime frm = new frmSetTime();
            //if (frm.ShowDialog() == DialogResult.OK)
            //{
            //    frmMain_Load(null, null);
            //}
        }

        private void btnDSChuaHT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataTable dt1 = new DataTable();
            foreach (GridColumn colum in grvData.Columns)
            {
                dt1.Columns.Add(colum.FieldName, colum.ColumnType);
            }
            for (int i = 0; i < grvData.DataRowCount; i++)
            {
                if (grvData.GetRowCellValue(i, colStatus).ToString() == "0" || grvData.GetRowCellValue(i, colStatus).ToString() == "1")
                {
                    DataRow row = dt1.NewRow();
                    foreach (GridColumn colum in grvData.Columns)
                    {
                        row[colum.FieldName] = grvData.GetRowCellValue(i, colum);

                    }
                    dt1.Rows.Add(row);
                }
            }
            grdData.DataSource = dt1;
            grvData.BestFitColumns();
        }

        private void btnAll_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            btnCancel_ItemClick(null, null);
        }

        private void grdData_DataSourceChanged(object sender, EventArgs e)
        {
            //ChuaXong = 0;
            ////txtChuaHoanThanh.AllowHtmlText//
            //DataTable dt = grdData.DataSource as DataTable;
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    if (dt.Rows[i]["Status"].ToString() == "0" || dt.Rows[i]["Status"].ToString() == "1")
            //    {
            //        ChuaXong++;
            //    }
            //}
            //txtChuaHoanThanh.Caption = "Số vật tư chưa hoàn thành " + ChuaXong;
        }

        private void btnLamMoi_ItemDoubleClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnLamMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmMain_Load(null, null);
        }

        private void popupNotifier1_Click(object sender, EventArgs e)
        {
            frmMainVatTu frm = new frmMainVatTu();
            frm.WindowState = FormWindowState.Maximized;
            TextUtils.OpenForm(frm);
            if(popupNotifier1.ContentText=="Bạn đã ghi nhật ký công việc chưa! Nếu chưa thì ghi vào nhật ký đi nhé")
            {
                System.Diagnostics.Process.Start(@"\\server\data2\Thietke\ISO\ISO.Thietke\Nhat ky CV\Nam 2014\");
            }
        }
        #endregion

        private void btnNew_Click(object sender, EventArgs e)
        {
            grvData.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            PageBase.StateButton(true, btnNew, btnSua, btnGhi, btnHuy, btnXoa);
            PageBase.VisibleColumnInGrid(grvData, true);
            Global_Add.sFormStatus = Global_Add.FormStatus.Addnew;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            PageBase.StateButton(true, btnNew, btnSua, btnGhi, btnHuy, btnXoa);
            PageBase.VisibleColumnInGrid(grvData, true);
            Global_Add.sFormStatus = Global_Add.FormStatus.Edit;
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            Save(ref m_DataSource);
            {
                grvData.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
                PageBase.StateButton(false, btnNew, btnSua, btnGhi, btnHuy, btnXoa);
                PageBase.VisibleColumnInGrid(grvData, false);
                Global_Add.sFormStatus = Global_Add.FormStatus.View;
                SelectAll(ref m_DataSource, grdData);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            SelectAll(ref m_DataSource, grdData);
            PageBase.StateButton(false, btnNew, btnSua, btnGhi, btnHuy, btnXoa);
            PageBase.VisibleColumnInGrid(grvData, false);
            grvData.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (grvData.FocusedRowHandle < 0)
                {
                    XtraMessageBox.Show("Không có mẫu tin nào để xóa", "Thông báo", MessageBoxButtons.OK);
                }
                else
                {
                    if (grvData.GetRowCellValue(grvData.FocusedRowHandle, colStatus).ToString() == "3" || grvData.GetRowCellValue(grvData.FocusedRowHandle, colStatus).ToString() == "2")
                    {
                        XtraMessageBox.Show("Bạn không thể xóa mẫu tin này vì nó đã hoàn thành", "Thông báo", MessageBoxButtons.OK);
                        return;
                    }
                    if (XtraMessageBox.Show("Bạn có chắc xóa mẫu tin này không?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        if (grvData.GetRowCellValue(grvData.FocusedRowHandle, colUserID).ToString() == Global.UserID.ToString())
                        {
                            TheoDoiVatTu_Entities.YeuCauVatTu_Entities p = new TheoDoiVatTu_Entities.YeuCauVatTu_Entities();
                            p.ID = Convert.ToInt32(grvData.GetRowCellValue(grvData.FocusedRowHandle, colID).ToString());
                            TheoDoiVatTu_BLL.YeuCauVatTu_BLL obj = new TheoDoiVatTu_BLL.YeuCauVatTu_BLL();
                            obj.Delete(p);
                            grvData.DeleteSelectedRows();
                            SelectAll(ref m_DataSource, grdData);
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Maximized;
        }

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            DataTable dt1 = new DataTable();
            foreach (GridColumn colum in grvData.Columns)
            {
                dt1.Columns.Add(colum.FieldName, colum.ColumnType);
            }
            for (int i = 0; i < grvData.DataRowCount; i++)
            {
                if (grvData.GetRowCellValue(i, colStatus).ToString() == "0" || grvData.GetRowCellValue(i, colStatus).ToString() == "1")
                {
                    DataRow row = dt1.NewRow();
                    foreach (GridColumn colum in grvData.Columns)
                    {
                        row[colum.FieldName] = grvData.GetRowCellValue(i, colum);
                    }
                    dt1.Rows.Add(row);
                }
            }
            grdData.DataSource = dt1;
            grvData.BestFitColumns();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            frmTheoDoiImportExcel frm = new frmTheoDoiImportExcel();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                SelectAll(ref m_DataSource, grdData);
            }
        }

        private void btnMoi_Click(object sender, EventArgs e)
        {
            frmMain_Load(null, null);
        }
    }
}
