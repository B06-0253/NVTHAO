
using System;
namespace BMS.Model
{
	public class SanPhamDAModel : BaseModel
	{
		private int iD;
		private string projectsID;
		private string tenTheoHopDong;
		private string maTheoHopDong;
		private string tenTheoThietKe;
		private string maTheoThietKe;
		private int thoiGianThietKe;
		private DateTime thoiGianBDDuKien;
		private DateTime thoiGianKTDuKien;
		private string thoiGianBDThucTe;
		private string thoiGianKTThucTe;
		private string tinhTrang;
		private string nhomPhuTrach;
		private string mucDoUuTien;
		private string loaiCongViec;
		public int ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public string ProjectsID
		{
			get { return projectsID; }
			set { projectsID = value; }
		}
	
		public string TenTheoHopDong
		{
			get { return tenTheoHopDong; }
			set { tenTheoHopDong = value; }
		}
	
		public string MaTheoHopDong
		{
			get { return maTheoHopDong; }
			set { maTheoHopDong = value; }
		}
	
		public string TenTheoThietKe
		{
			get { return tenTheoThietKe; }
			set { tenTheoThietKe = value; }
		}
	
		public string MaTheoThietKe
		{
			get { return maTheoThietKe; }
			set { maTheoThietKe = value; }
		}
	
		public int ThoiGianThietKe
		{
			get { return thoiGianThietKe; }
			set { thoiGianThietKe = value; }
		}
	
		public DateTime ThoiGianBDDuKien
		{
			get { return thoiGianBDDuKien; }
			set { thoiGianBDDuKien = value; }
		}
	
		public DateTime ThoiGianKTDuKien
		{
			get { return thoiGianKTDuKien; }
			set { thoiGianKTDuKien = value; }
		}
	
		public string ThoiGianBDThucTe
		{
			get { return thoiGianBDThucTe; }
			set { thoiGianBDThucTe = value; }
		}
	
		public string ThoiGianKTThucTe
		{
			get { return thoiGianKTThucTe; }
			set { thoiGianKTThucTe = value; }
		}
	
		public string TinhTrang
		{
			get { return tinhTrang; }
			set { tinhTrang = value; }
		}
	
		public string NhomPhuTrach
		{
			get { return nhomPhuTrach; }
			set { nhomPhuTrach = value; }
		}
	
		public string MucDoUuTien
		{
			get { return mucDoUuTien; }
			set { mucDoUuTien = value; }
		}
	
		public string LoaiCongViec
		{
			get { return loaiCongViec; }
			set { loaiCongViec = value; }
		}
	
	}
}
	