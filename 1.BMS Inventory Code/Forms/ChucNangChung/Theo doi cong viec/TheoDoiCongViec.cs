using BMS.Business;
using BMS.Model;
using DevExpress.Data;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using BMS.Utils;
namespace BMS
{
    public partial class frmTheoDoiCongViec : _Forms
    {
        #region Constructor
        public frmTheoDoiCongViec()
        {
            InitializeComponent();
            try
            {
                SqlClientPermission sq = new SqlClientPermission(System.Security.Permissions.PermissionState.Unrestricted);
                sq.Demand();
            }
            catch (Exception)
            {

            }

            //SqlDependency.Stop(Global.ConnectionString);
            //SqlDependency.Start(Global.ConnectionString);
        }

        private void TheoDoiCongViec_Load(object sender, EventArgs e)
        {
            try
            {
                OnNewMess += new NewMess(TheoDoiCongViec_OnNewMess);

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

        #region Variables
        DataTable m_DataSource = new DataTable();
        List<string> kkkkkk = new List<string>();
        string[] TimeSet;//////=new string[]();
        public delegate void NewMess();
        public event NewMess OnNewMess;
        #endregion

        #region Method

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
            int o = 0;
            for (int i = 0; i < ttt.Length; i++)
            {
                if (ttt[i] == '\n')
                {
                    o += 14;
                }
            }
            popupNotifier1.Scroll = true; 
            popupNotifier1.Size = new Size(400, 50 + o);
            popupNotifier1.TitleColor = Color.Red;
            popupNotifier1.Popup();
        }

        public void Save(ref DataTable dt)
        {
            //Luu = false;
            grvData.PostEditor();
            //if (!Check_Valid(dt))
            //{

            //    return;
            //}
            try
            {
                SaveToTable(m_DataSource);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        public static void SaveToTable(DataTable dt)
        {
            DataTable dtRemine;
            dtRemine = dt.GetChanges();
            if (dtRemine != null)
            {
                foreach (DataRow item in dtRemine.Rows)
                {
                    TheoDoiModel model = new TheoDoiModel();

                    //model.ID =TextUtils.ToInt(item["ID"]);
                    //model.TenCV = Convert.ToString(item["TenCV"]);
                    //model.MaDA = Convert.ToString(item["MaDA"]);
                    //model.MaTB = Convert.ToString(item["MaTB"]);
                    //model.NguoiPhuTrach = TextUtils.ToInt(item["NguoiPhuTrach"]);
                    //model.ThoiGianBD = TextUtils.ToDate(item["ThoiGianBD"].ToString());
                    //model.ThoiGianKT = TextUtils.ToDate(item["ThoiGianKT"].ToString());
                    //model.TinhTrang = Convert.ToString(item["TinhTrang"]);
                    //model.GhiChu = Convert.ToString(item["GhiChu"]);
                    //model.GioBD = TextUtils.ToInt(item["GioBD"]);
                    //model.ThoiGianDuKien = TextUtils.ToInt(item["ThoiGianDuKien"]);
                    //model.GioKT = TextUtils.ToInt(item["GioKT"]);
                    //if (item["ID"] == DBNull.Value) //add new
                    //{
                    //    TheoDoiBO.Instance.Insert(model);
                    //}
                    //else //Update
                    //{
                    //    model.ID = TextUtils.ToInt(item["ID"].ToString());
                    //    TheoDoiBO.Instance.Update(model);
                    //}
                }
            }
        }

        public void SelectAll(ref DataTable dt, GridControl grd)
        {

            //SqlConnection cnn = new SqlConnection(DBUtils.GetDBConnectionString());
            //SqlCommand cmd = new SqlCommand("SELECT ID, TenCV, MaDA, MaTB, NguoiPhuTrach, ThoiGianBD, ThoiGianKT, TinhTrang, GhiChu, GioBD, ThoiGianDuKien, GioKT FROM dbo.TheoDoi",cnn);

            try
            {
                try
                {
                    //if (cnn.State==ConnectionState.Closed)
                    //{
                    //    cnn.Open();
                    //}
                    dt = TextUtils.Select("select * from vCheckPermission where Code ='frmTheoDoiCongViec_ViewAll' and UserID=" + Global.UserID);
                    if (dt == null || dt.Rows.Count == 0)
                    {
                        dt = new DataTable();
                        dt = TextUtils.Select("SELECT ID, TenCV, MaDA, MaTB, NguoiPhuTrach, ThoiGianBD, ThoiGianKT, TinhTrang, GhiChu, GioBD, ThoiGianDuKien, GioKT FROM dbo.TheoDoi WHERE (NguoiPhuTrach = " + Global.UserID + ")");
                        //cmd.Connection = cnn;
                        //dt.Load(cmd.ExecuteReader(CommandBehavior.CloseConnection));
                        //cmd.Dispose();

                    }
                    else
                    {
                        if (dt.Rows.Count > 0)
                        {
                            dt = TextUtils.Select("SELECT ID, TenCV, MaDA, MaTB, NguoiPhuTrach, ThoiGianBD, ThoiGianKT, TinhTrang, GhiChu, GioBD, ThoiGianDuKien, GioKT FROM dbo.TheoDoi");
                            //cmd.Connection = cnn;
                            //dt.Load(cmd.ExecuteReader(CommandBehavior.CloseConnection));
                        }
                    }


                }
                catch (Exception)
                {
                    dt = TextUtils.Select("SELECT ID, TenCV, MaDA, MaTB, NguoiPhuTrach, ThoiGianBD, ThoiGianKT, TinhTrang, GhiChu, GioBD, ThoiGianDuKien, GioKT FROM TheoDoi WHERE (NguoiPhuTrach = " + Global.UserID + ")");
                    //cmd.CommandText = "SELECT ID, TenCV, MaDA, MaTB, NguoiPhuTrach, ThoiGianBD, ThoiGianKT, TinhTrang, GhiChu, GioBD, ThoiGianDuKien, GioKT FROM dbo.TheoDoi WHERE (NguoiPhuTrach = " + Global.UserID + ")";
                    //cmd.Connection = cnn;
                    //dt.Load(cmd.ExecuteReader(CommandBehavior.CloseConnection));
                }

                //SqlDependency de = new SqlDependency(cmd);
                //de.OnChange += new OnChangeEventHandler(de_OnChange);
                if (dt == null)
                {
                    //TheoDoiBO.KhoiTaoGrid();
                }
                dt.Columns.Add("STT", typeof(string));
                colNguoiYeuCau.DataSource = TextUtils.Select("SELECT ID,FullName FROM Users");
                colNguoiYeuCau.DisplayMember = "FullName";
                colNguoiYeuCau.ValueMember = "ID";
                colNguoiYeuCau.NullText = "Tên nhân viên";
                ChuaXong = 0; Xong = 0; GanXong = 0;


                DataView dv = dt.DefaultView;

                dv.Sort = "TinhTrang ASC";

                dt = dv.ToTable();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow row = dt.Rows[i];
                    row["STT"] = i + 1;
                    if (row["TinhTrang"].ToString()=="0")
                    {
                        ChuaXong++;
                    }
                }
                grd.DataSource = dt;
                grvData.BestFitColumns();
                toolStripLabel1.Text = "Số công việc chưa hoàn thành " + ChuaXong;
                View_popup();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        void de_OnChange(object sender, SqlNotificationEventArgs e)
        {
            SqlDependency de = sender as SqlDependency;

            de.OnChange -= de_OnChange;
            if (OnNewMess != null)
            {
                OnNewMess();
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
        int ThoiGianConLai(int k)
        {
            for (int i = 0; i < 10; i++)
            {
                if (k > 12)
                {
                    k--;
                }
                if (k == 8 + i)
                {
                    return 8 - i;
                }
            }
            return 0;
        }
        public void View_popup()
        {
            string ngaythucte = "", Tb = "";
            for (int i = 0; i < grvData.RowCount; i++)
            {
                if (grvData.GetRowCellValue(i, colTinhTrang).ToString() == "0")
                {
                    DataTable dt = TextUtils.Select("select * from vCheckPermission where Code ='frmTheoDoiCongViec_ViewAll' and UserID=" + Global.UserID);
                    if (dt.Rows.Count > 0 || grvData.GetRowCellValue(i, colNguoiPhuTrach).ToString() == Global.UserID.ToString())
                    {
                        string ma = grvData.GetRowCellValue(i, colMaDA).ToString();
                        string ten = grvData.GetRowCellValue(i, colTenCV).ToString();
                        string tenNV = grvData.GetRowCellDisplayText(i, colNguoiPhuTrach).ToString();

                        if (DateTime.Now >= Convert.ToDateTime(grvData.GetRowCellValue(i, colThoiGianKT)))
                        {
                            ngaythucte += "Công việc :" + ten + " - " + ma + " do " + tenNV + " chưa hoàn thành\n";
                            continue;
                        }
                    }
                }
            }
            if (ngaythucte.Trim() != "")
            {
                Tb += ngaythucte;
            }
            if (Tb.Trim() != "")
            {
                PopUp_No(Tb);
            }
        }
        private int ChuaXong = 0, Xong = 0, GanXong = 0;
        #endregion

        #region Events
        private void btnNew_Click(object sender, EventArgs e)
        {
            grvData.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            PageBase.StateButton(true, btnNew, btnSua, btnGhi, btnHuy, btnXoa);
            PageBase.VisibleColumnInGrid(grvData, true);
            Global_Add.sFormStatus = Global_Add.FormStatus.Addnew;
            grvData.FocusedRowHandle = GridControl.NewItemRowHandle;
            grvData.FocusedColumn = colTenCV;
            grvData.ShowEditor();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            PageBase.StateButton(true, btnNew, btnSua, btnGhi, btnHuy, btnXoa);
            PageBase.VisibleColumnInGrid(grvData, true);
            Global_Add.sFormStatus = Global_Add.FormStatus.Edit;
        }

        private void btnGhi_Click(object sender, EventArgs e)
        {
            grvData.FocusedRowHandle = -1;
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
                    if (grvData.GetRowCellValue(grvData.FocusedRowHandle, colTinhTrang).ToString() == "3" || grvData.GetRowCellValue(grvData.FocusedRowHandle, colTinhTrang).ToString() == "2")
                    {
                        XtraMessageBox.Show("Bạn không thể xóa mẫu tin này vì nó đã hoàn thành", "Thông báo", MessageBoxButtons.OK);
                        return;
                    }
                    if (XtraMessageBox.Show("Bạn có chắc xóa mẫu tin này không?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        if (grvData.GetRowCellValue(grvData.FocusedRowHandle, colNguoiPhuTrach).ToString() == Global.UserID.ToString())
                        {
                            //TheoDoiModel p = new TheoDoiModel();
                            int o = Convert.ToInt32(grvData.GetRowCellValue(grvData.FocusedRowHandle, colID).ToString());
                            TheoDoiBO.Instance.Delete(o);
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
        #endregion

        private void TheoDoiCongViec_OnNewMess()
        {
            ISynchronizeInvoke i = (ISynchronizeInvoke)this;
            if (i.InvokeRequired)
            {
                NewMess te = new NewMess(TheoDoiCongViec_OnNewMess);
                i.BeginInvoke(te, null);
                return;
            }
            SelectAll(ref m_DataSource, grdData);
        }

        #region event
        private void grvData_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            try
            {
                GridView view = sender as GridView;
                int l = TextUtils.ToInt(view.GetRowCellValue(e.RowHandle, colThoiGianDuKien));
                int k = l / 8;
                int lp = l % 8;
                if (lp == 0 && k != 0)
                {
                    k--;
                }
                //set tinh trang mac dinh
                if (view.GetRowCellValue(e.RowHandle, colTinhTrang).ToString() == string.Empty || view.GetRowCellValue(e.RowHandle, colTinhTrang) == null)
                {
                    view.SetRowCellValue(e.RowHandle, colTinhTrang, 0);
                }
                //set thoi gian bat dau neu bo trong
                if (view.GetRowCellValue(e.RowHandle, colThoiGianBD).ToString() == string.Empty)
                {
                    view.SetRowCellValue(e.RowHandle, colThoiGianBD, Convert.ToDateTime(DateTime.Now));
                }
                DateTime op = DateTime.Now;
                if (l <= 8)
                {
                    op = (Convert.ToDateTime(view.GetRowCellValue(e.RowHandle, colThoiGianBD)).AddHours(TextUtils.ToInt(view.GetRowCellValue(e.RowHandle, colThoiGianDuKien))));
                }
                else
                {
                    op = (Convert.ToDateTime(view.GetRowCellValue(e.RowHandle, colThoiGianBD)).AddDays(k));
                }

                DateTime df = TextUtils.ToDate(TextUtils.ToDate(view.GetRowCellValue(e.RowHandle, colThoiGianBD).ToString()).ToString("dd/MM/yyyy") + " 12:00:00");
                if (op.ToString("dd/MM/yyyy") == df.ToString("dd/MM/yyyy"))
                {
                    if (op.Hour >= 17 && op.Minute > 0)
                    {
                        int du = op.Hour;
                        int mi = op.Minute;
                        op = op.AddDays(1);

                        op = TextUtils.ToDate(op.ToString("dd/MM/yyyy") + " 8:00:00");
                        op = op.AddHours(du - 17).AddMinutes(mi);
                        view.SetRowCellValue(e.RowHandle, colThoiGianKT, op);
                    }
                    else
                        if (TextUtils.ToDate(view.GetRowCellValue(e.RowHandle, colThoiGianBD).ToString()) <= df && op > df)
                        {
                            view.SetRowCellValue(e.RowHandle, colThoiGianKT, op.AddHours(1));
                        }
                        else
                            view.SetRowCellValue(e.RowHandle, colThoiGianKT, op);
                }
                else
                {
                    l = TextUtils.ToInt(view.GetRowCellValue(e.RowHandle, colThoiGianDuKien));

                    int kl = TextUtils.ToDate(view.GetRowCellValue(e.RowHandle, colThoiGianBD).ToString()).Hour;
                    l = l - ThoiGianConLai(kl);
                    k = l / 8;
                    lp = l % 8;
                    op = TextUtils.ToDate(view.GetRowCellValue(e.RowHandle, colThoiGianBD).ToString());
                    op = TextUtils.ToDate(op.ToString("dd/MM/yyyy") + " 8:00:00");


                    DateTime kh = op.AddDays(k + 1).AddHours(lp);
                    if (kh.Hour > 12)
                    {
                        kh.AddHours(1);
                    }
                    view.SetRowCellValue(e.RowHandle, colThoiGianKT, kh);
                }

                #region Add and update
                {
                    TheoDoiModel model = new TheoDoiModel();

                    //model.ID =TextUtils.ToInt(item["ID"]);
                    //model.TenCV = view.GetRowCellValue(e.RowHandle, colTenCV).ToString();//
                    //model.MaDA = view.GetRowCellValue(e.RowHandle, colMaDA).ToString();//Convert.ToString(item["MaDA"]);
                    //model.MaTB = view.GetRowCellValue(e.RowHandle, colMaTB).ToString();//Convert.ToString(item["MaTB"]);
                    //model.NguoiPhuTrach = TextUtils.ToInt(Global.UserID);//item["NguoiPhuTrach"]);
                    //model.ThoiGianBD = TextUtils.ToDate(view.GetRowCellValue(e.RowHandle, colThoiGianBD).ToString());//item["ThoiGianBD"].ToString());
                    //model.ThoiGianKT = TextUtils.ToDate(view.GetRowCellValue(e.RowHandle, colThoiGianKT).ToString());//item["ThoiGianKT"].ToString());
                    //model.TinhTrang = view.GetRowCellValue(e.RowHandle, colTinhTrang).ToString();// Convert.ToString(item["TinhTrang"]);
                    //model.GhiChu = view.GetRowCellValue(e.RowHandle, colGhiChu).ToString();// Convert.ToString(item["GhiChu"]);
                    //model.GioBD = TextUtils.ToInt(view.GetRowCellValue(e.RowHandle, colGioBD).ToString());//item["GioBD"]);
                    model.ThoiGianDuKien = TextUtils.ToInt(view.GetRowCellValue(e.RowHandle, colThoiGianDuKien).ToString());//item["ThoiGianDuKien"]);
                    //model.GioKT = TextUtils.ToInt(view.GetRowCellValue(e.RowHandle, colGioKT).ToString());//item["GioKT"]);
                    if (view.GetRowCellValue(e.RowHandle, colID) == DBNull.Value) //add new
                    {
                        TheoDoiBO.Instance.Insert(model);
                    }
                    else //Update
                    {
                        if (view.GetRowCellValue(e.RowHandle, colNguoiPhuTrach).ToString() == Global.UserID.ToString())
                        {
                            model.ID = TextUtils.ToInt(view.GetRowCellValue(e.RowHandle, colID).ToString());
                            TheoDoiBO.Instance.Update(model);
                        }
                        else
                        {
                            e.Valid = true;
                            XtraMessageBox.Show("Bạn không thể sửa dữ liệu của người khác");
                        }
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            SelectAll(ref m_DataSource, grdData);
        }
        private void btnMoi_Click(object sender, EventArgs e)
        {
            TheoDoiCongViec_Load(null, null);
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
                if (grvData.GetRowCellValue(i, colTinhTrang).ToString() == "0")
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
        }

        private void popupNotifier1_Click(object sender, EventArgs e)
        {
            frmTheoDoiCongViec frm = new frmTheoDoiCongViec();
            frm.WindowState = FormWindowState.Maximized;
            TextUtils.OpenForm(frm);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            SelectAll(ref m_DataSource, grdData);
            View_popup();
        }

        #endregion

        private void TheoDoiCongViec_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Maximized;
        }      
    }
}
