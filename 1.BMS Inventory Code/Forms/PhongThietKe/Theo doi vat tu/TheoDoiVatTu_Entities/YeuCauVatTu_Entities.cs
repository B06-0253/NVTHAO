//---------------------------------------------------------------------------
// Author : CanhHungIT
// Created Date : Monday, September 22, 2014
//---------------------------------------------------------------------------


// Khai bao lop
using System;

namespace TheoDoiVatTu_Entities
{
	public class YeuCauVatTu_Entities
	{
		// Ham khoi tao khong tham so
		#region Constructor
		public YeuCauVatTu_Entities()
		{

		}

		#endregion

		// Cac bien so
		#region Vars
		private int _ID = 0;
		private int _UserID = 0;
		private string _TenVatTu = "";
		private string _MaVatTu = "";
		private string _Hang = "";
		private string _MaSP = "";
		private string _TenDuAn = "";
		private string _MaDuAn = "";
		private string _SoLuong = "";
		private string _NgayYeuCau = "";
		private string _NgayVeDuKien = "";
		private string _NgayThucTe = "";
		private string _ThoiGianDatHangTHucTe = "";
		private string _NguyenNhanCham = "";
		private string _GhiChu = "";
		#endregion

		#region Property
		// Cac thuoc tinh
		public int ID
		{
			get{ return _ID; }
			set{ _ID = value; }
		}
		public int UserID
		{
			get{ return _UserID; }
			set{ _UserID = value; }
		}
		public string TenVatTu
		{
			get{ return _TenVatTu; }
			set{ _TenVatTu = value; }
		}
		public string MaVatTu
		{
			get{ return _MaVatTu; }
			set{ _MaVatTu = value; }
		}
		public string Hang
		{
			get{ return _Hang; }
			set{ _Hang = value; }
		}
		public string MaSP
		{
			get{ return _MaSP; }
			set{ _MaSP = value; }
		}
		public string TenDuAn
		{
			get{ return _TenDuAn; }
			set{ _TenDuAn = value; }
		}
		public string MaDuAn
		{
			get{ return _MaDuAn; }
			set{ _MaDuAn = value; }
		}
		public string SoLuong
		{
			get{ return _SoLuong; }
			set{ _SoLuong = value; }
		}
		public string NgayYeuCau
		{
			get{ return _NgayYeuCau; }
			set{ _NgayYeuCau = value; }
		}
		public string NgayVeDuKien
		{
			get{ return _NgayVeDuKien; }
			set{ _NgayVeDuKien = value; }
		}
		public string NgayThucTe
		{
			get{ return _NgayThucTe; }
			set{ _NgayThucTe = value; }
		}
		public string ThoiGianDatHangTHucTe
		{
			get{ return _ThoiGianDatHangTHucTe; }
			set{ _ThoiGianDatHangTHucTe = value; }
		}
		public string NguyenNhanCham
		{
			get{ return _NguyenNhanCham; }
			set{ _NguyenNhanCham = value; }
		}
		public string GhiChu
		{
			get{ return _GhiChu; }
			set{ _GhiChu = value; }
		}
		#endregion

	}
}


