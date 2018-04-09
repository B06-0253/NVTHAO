using BMS.Business;
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
    public partial class frmThongKeKeHoach : _Forms
    {
        public frmThongKeKeHoach()
        {
            InitializeComponent();
        }

        private void frmThongKeKeHoach_Load(object sender, EventArgs e)
        {
            // string dd= dateTimePicker1.Value.DayOfYear.ToString();
            ckNgay.Checked = true;
            ckDuAn.Checked = false;
            ckNhanVien.Checked = false;
            ckHangMuc.Checked = false;
            ckCongViecPhatSinh.Checked = false;
            LoadData();
            loadYear();
            leYear.EditValue = DateTime.Now.Year;
            leWeek.ItemIndex = WeeksInYear(DateTime.Now) - 1;
            ArrayList model = ConfigSystemBO.Instance.FindByAttribute("KeyName", "HangMuc");

            leHangMuc.Properties.DataSource = model;
            leHangMuc.Properties.DisplayMember = "KeyValue";
            leHangMuc.Properties.ValueMember = "KeyValue";
            leHangMuc.Properties.NullText = "Chọn hạng mục";
        }

        #region Event
        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }


        private void leYear_EditValueChanged(object sender, EventArgs e)
        {
            if (leYear.EditValue == null) return;

            loadWeek(TextUtils.ToInt(leYear.EditValue));
        }

        private void leWeek_EditValueChanged(object sender, EventArgs e)
        {
            if (leWeek.EditValue == null) return;
            getSEDate(leWeek.EditValue.ToString());
        }


        private void leNhom_EditValueChanged(object sender, EventArgs e)
        {
            DataTable dt = TextUtils.Select("SELECT Code,ID, FullName, UserGroupID FROM Users WHERE (UserGroupID = " + leNhom.EditValue + ")");
            leNhaVien.Properties.DataSource = dt;
            leNhaVien.Properties.ValueMember = "ID";
            leNhaVien.Properties.DisplayMember = "FullName";
        } 
        #endregion

        string[] _paraName = new string[7];
        object[] _paraValue = new object[7];
        private void btnThongKe_Click(object sender, EventArgs e)
        {
            try
            {
                if (ckNgay.Checked)
                {
                    NgayBD = (dateTimePicker1.Value);
                    NgayKT = (dateTimePicker2.Value);
                }
                else
                {
                    NgayBD = TextUtils.ToDate1("01/01/1990 12:00:00 AM");
                    NgayKT = DateTime.Now.AddYears(1);
                }
                if (ckDuAn.Checked)
                {
                    DuAn = leDuAn.EditValue.ToString();
                }
                else
                {
                    DuAn = "";
                }
                if (cknhom.Checked)
                {
                    Nhom = leNhom.Text;
                }
                else
                {
                    Nhom = "";
                }
                if (ckNhanVien.Checked)
                {
                    NhanVien = leNhaVien.EditValue.ToString();
                }
                else
                {
                    NhanVien = "";
                }
                if (ckCongViecPhatSinh.Checked)
                {
                    CongViecPhatSinh = "Phát sinh";
                }
                else
                {
                    CongViecPhatSinh = "";
                }
                if (ckHangMuc.Checked)
                {
                    HangMuc = leHangMuc.Text;
                }
                else
                {
                    HangMuc = "";
                }
            }
            catch (Exception ex)
            {
                TextUtils.ShowError(ex.Message);
            }
            grvData.BestFitColumns();
            _paraName[0] = "@NgayBD"; _paraValue[0] = NgayBD;
            _paraName[1] = "@NgayKT"; _paraValue[1] = NgayKT;
            _paraName[2] = "@DuAn"; _paraValue[2] = DuAn;
            _paraName[3] = "@Nhom"; _paraValue[3] =Nhom;
            _paraName[4] = "@NhanVien"; _paraValue[4] = NhanVien;
            _paraName[5] = "@HangMuc"; _paraValue[5] = HangMuc;
            _paraName[6] = "@CongViecPhatSinh"; _paraValue[6] = CongViecPhatSinh; 
            DataTable Source = ModulesBO.Instance.LoadDataFromSP("sp_ThongKe", "Source", _paraName, _paraValue);
            grdData.DataSource = Source;
        }
        public static int WeeksInYear(DateTime date)
        {
            GregorianCalendar cal = new GregorianCalendar(GregorianCalendarTypes.Localized);
            return cal.GetWeekOfYear(date, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
        }
        #region Method
        public void loadYear()
        {
            List<int> listYear = new List<int>();

            for (int i = 0; i < 30; i++)
            {
                listYear.Add(2010 + i);
            }

            leYear.Properties.DataSource = listYear;
        }
        public void loadWeek(int Year)
        {
            leWeek.Properties.DataSource = TextUtils.LoadAllWeekOfYear(Year);
        }
        public void LoadData()
        {
            DataTable dt = new DataTable();
            dt = TextUtils.Select("select ProjectName,ProjectCode,ProjectId from ProjectSyn");
            leDuAn.Properties.DataSource = dt;
            leDuAn.Properties.ValueMember = "ProjectCode";
            leDuAn.Properties.DisplayMember = "ProjectName";


            dt = TextUtils.Select("SELECT Name, Code, ID FROM UserGroup");
            leNhom.Properties.DataSource = dt;
            leNhom.Properties.DisplayMember = "Name";
            leNhom.Properties.ValueMember = "ID";

            DataTable dt2 = TextUtils.Select("SELECT DISTINCT ProjectSyn.ProjectName + '- ' + ProjectSyn.ProjectCode + N'- hạn hoàn thành '+ CONVERT(VARCHAR(10),ProjectSyn.DateFinishE,103) AS ProjectName, ProjectSyn.DateFinishE, ProjectSyn.ProjectCode,ProjectSyn.DateFinishE, SanPhamDA.TenTheoHopDong + '- ' + SanPhamDA.MaTheoHopDong AS TenTheoHopDong, SanPhamDA.MaTheoHopDong, UserGroup.Name, HangMucCongViec.ID, HangMucCongViec.TenHangMuc, HangMucCongViec.ThoiGianTK,CONVERT(VARCHAR(10),HangMucCongViec.ThoiGianBDDuKien,103) as ThoiGianBDDuKien, CONVERT(VARCHAR(10),HangMucCongViec.ThoiGianKTDuKien,103) as ThoiGianKTDuKien, HangMucCongViec.NguoiThietKe, HangMucCongViec.MucDoUuTien, HangMucCongViec.TinhTrang, HangMucCongViec.KieuCongViec, HangMucCongViec.Loi, HangMucCongViec.SanPhamDAID FROM SanPhamDA INNER JOIN UserGroup ON SanPhamDA.NhomPhuTrach = UserGroup.ID INNER JOIN ProjectSyn ON SanPhamDA.ProjectsID COLLATE Vietnamese_CI_AS = ProjectSyn.ProjectId LEFT OUTER JOIN HangMucCongViec ON SanPhamDA.ID = HangMucCongViec.SanPhamDAID");
            grdData.DataSource = dt2;
            //DataTable dtf = TextUtils.Select("SELECT DISTINCT ProjectSyn.ProjectName + '- ' + ProjectSyn.ProjectCode AS ProjectName, ProjectSyn.ProjectCode, ProjectSyn.DateFinishE,datediff(d,getdate(),ProjectSyn.DateFinishE) as NgayConLai FROM SanPhamDA INNER JOIN ProjectSyn ON SanPhamDA.ProjectsID COLLATE Vietnamese_CI_AS = ProjectSyn.ProjectId order by ProjectName asc");
            //grdTinhTrangDA.DataSource = dtf;
            repositoryItemLookUpEdit1.DataSource = TextUtils.Select("SELECT Code,ID, FullName FROM Users");
            repositoryItemLookUpEdit1.DisplayMember = "FullName";
            repositoryItemLookUpEdit1.ValueMember = "ID";

            grvData.BestFitColumns();
        }
        void getSEDate(string WeekInfo)
        {
            string[] str = WeekInfo.Split(':');
            //txtStartDate.Text = (str[1].Split('-')[0]).Trim();
            //txtEndDate.Text = (str[1].Split('-')[1]).Trim();
            dateTimePicker1.Text = (str[1].Split('-')[0]).Trim();
            dateTimePicker2.Text = (str[1].Split('-')[1]).Trim();
        } 
        #endregion

        private void ckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (ckBox.Checked)
            {
                grvData.OptionsBehavior.AutoExpandAllGroups = true;
            }
            else
            {
                grvData.OptionsBehavior.AutoExpandAllGroups = false;
                btnThongKe_Click(null, null);
            }
        }

        private void grdData_Click(object sender, EventArgs e)
        {

        }
        DateTime NgayBD = TextUtils.ToDate1("01/01/1990 12:00:00 AM"), NgayKT = DateTime.Now.AddYears(1);


        string Nhom = "", DuAn = "", NhanVien = "", CongViecPhatSinh = "", HangMuc = "";
        private void ckNgay_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void ckDuAn_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void ckNhanVien_CheckedChanged(object sender, EventArgs e)
        {
          
        }

        private void ckHangMuc_CheckedChanged(object sender, EventArgs e)
        {
        
        }

        private void ckCongViecPhatSinh_CheckedChanged(object sender, EventArgs e)
        {
         
        }
    }
}
