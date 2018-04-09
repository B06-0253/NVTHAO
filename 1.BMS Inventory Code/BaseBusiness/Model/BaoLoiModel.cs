
using System;
namespace BMS.Model
{
	public class BaoLoiModel : BaseModel
	{
		private int iD;
		private string vanDe;
		private string hangMuc;
		private string yeuCau;
		private string nguoiPhatHien;
		private DateTime ngayYeuCau;
		private string tinhTrangLoi;
		private string fileDinhKem;
		private string tinhTrangKhacPhuc;
		private string nguoiKhacPhuc;
		private string ngayKhacPhucXong;
		private string mucDoUuTien;
		public int ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public string VanDe
		{
			get { return vanDe; }
			set { vanDe = value; }
		}
	
		public string HangMuc
		{
			get { return hangMuc; }
			set { hangMuc = value; }
		}
	
		public string YeuCau
		{
			get { return yeuCau; }
			set { yeuCau = value; }
		}
	
		public string NguoiPhatHien
		{
			get { return nguoiPhatHien; }
			set { nguoiPhatHien = value; }
		}
	
		public DateTime NgayYeuCau
		{
			get { return ngayYeuCau; }
			set { ngayYeuCau = value; }
		}
	
		public string TinhTrangLoi
		{
			get { return tinhTrangLoi; }
			set { tinhTrangLoi = value; }
		}
	
		public string FileDinhKem
		{
			get { return fileDinhKem; }
			set { fileDinhKem = value; }
		}
	
		public string TinhTrangKhacPhuc
		{
			get { return tinhTrangKhacPhuc; }
			set { tinhTrangKhacPhuc = value; }
		}
	
		public string NguoiKhacPhuc
		{
			get { return nguoiKhacPhuc; }
			set { nguoiKhacPhuc = value; }
		}
	
		public string NgayKhacPhucXong
		{
			get { return ngayKhacPhucXong; }
			set { ngayKhacPhucXong = value; }
		}
	
		public string MucDoUuTien
		{
			get { return mucDoUuTien; }
			set { mucDoUuTien = value; }
		}
	
	}
}
	