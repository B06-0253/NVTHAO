
using System;
namespace BMS.Model
{
	public class HangMucCongViecModel : BaseModel
	{
		private int iD;
		private string tenHangMuc;
		private int thoiGianTK;
		private DateTime thoiGianBDDuKien;
		private DateTime thoiGianKTDuKien;
		private string thoiGianBDThucTe;
		private string thoiGianKTThucTe;
		private string nguoiThietKe;
		private string mucDoUuTien;
		private string tinhTrang;
		private string kieuCongViec;
		private string loi;
		private int sanPhamDAID;
		public int ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public string TenHangMuc
		{
			get { return tenHangMuc; }
			set { tenHangMuc = value; }
		}
	
		public int ThoiGianTK
		{
			get { return thoiGianTK; }
			set { thoiGianTK = value; }
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
	
		public string NguoiThietKe
		{
			get { return nguoiThietKe; }
			set { nguoiThietKe = value; }
		}
	
		public string MucDoUuTien
		{
			get { return mucDoUuTien; }
			set { mucDoUuTien = value; }
		}
	
		public string TinhTrang
		{
			get { return tinhTrang; }
			set { tinhTrang = value; }
		}
	
		public string KieuCongViec
		{
			get { return kieuCongViec; }
			set { kieuCongViec = value; }
		}
	
		public string Loi
		{
			get { return loi; }
			set { loi = value; }
		}
	
		public int SanPhamDAID
		{
			get { return sanPhamDAID; }
			set { sanPhamDAID = value; }
		}
	
	}
}
	