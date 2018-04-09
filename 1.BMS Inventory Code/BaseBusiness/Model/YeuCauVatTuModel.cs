
using System;
namespace BMS.Model
{
	public class YeuCauVatTuModel : BaseModel
	{
		private int iD;
		private int userID;
		private string tenVatTu;
		private string maVatTu;
		private string hang;
		private string maSP;
		private string tenDuAn;
		private string maDuAn;
		private string soLuong;
		private string ngayYeuCau;
		private string ngayVeDuKien;
		private string ngayThucTe;
		private string thoiGianDatHangTHucTe;
		private string nguyenNhanCham;
		private string ghiChu;

        private string ngayVeDuKien2;
        private string ngayVeDuKien3;
		public int ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public int UserID
		{
			get { return userID; }
			set { userID = value; }
		}
	
		public string TenVatTu
		{
			get { return tenVatTu; }
			set { tenVatTu = value; }
		}
	
		public string MaVatTu
		{
			get { return maVatTu; }
			set { maVatTu = value; }
		}
	
		public string Hang
		{
			get { return hang; }
			set { hang = value; }
		}
	
		public string MaSP
		{
			get { return maSP; }
			set { maSP = value; }
		}
	
		public string TenDuAn
		{
			get { return tenDuAn; }
			set { tenDuAn = value; }
		}
	
		public string MaDuAn
		{
			get { return maDuAn; }
			set { maDuAn = value; }
		}
	
		public string SoLuong
		{
			get { return soLuong; }
			set { soLuong = value; }
		}
	
		public string NgayYeuCau
		{
			get { return ngayYeuCau; }
			set { ngayYeuCau = value; }
		}
	
		public string NgayVeDuKien
		{
			get { return ngayVeDuKien; }
			set { ngayVeDuKien = value; }
		}
	
		public string NgayThucTe
		{
			get { return ngayThucTe; }
			set { ngayThucTe = value; }
		}
	
		public string ThoiGianDatHangTHucTe
		{
			get { return thoiGianDatHangTHucTe; }
			set { thoiGianDatHangTHucTe = value; }
		}
	
		public string NguyenNhanCham
		{
			get { return nguyenNhanCham; }
			set { nguyenNhanCham = value; }
		}

		public string GhiChu
		{
			get { return ghiChu; }
			set { ghiChu = value; }
		}
        public string NgayVeDuKien2
        {
            get { return ngayVeDuKien2; }
            set { ngayVeDuKien2 = value; }
        }

        public string NgayVeDuKien3
        {
            get { return ngayVeDuKien3; }
            set { ngayVeDuKien3 = value; }
        }
	}
}
	