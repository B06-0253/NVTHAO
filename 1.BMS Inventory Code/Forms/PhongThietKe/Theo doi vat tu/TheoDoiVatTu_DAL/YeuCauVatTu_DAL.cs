//---------------------------------------------------------------------------
// Author : CanhHungIT
// Created Date : Monday, September 22, 2014
//---------------------------------------------------------------------------


// Khai bao lop
using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using TheoDoiVatTu_Entities ;//Add reference vao
namespace TheoDoiVatTu_DAL
{
	public class YeuCauVatTu_DAL
	{
		// Ham khoi tao khong tham so
		#region Constructor
		public YeuCauVatTu_DAL(){}
		#endregion

		private TheoDoiVatTu_DAL.KetNoi obj= new TheoDoiVatTu_DAL.KetNoi();
		#region Function
		// Insert
		public int Insert(TheoDoiVatTu_Entities.YeuCauVatTu_Entities p)
		{
			int result = 14;
			try
			{
				string[] a = new string[result];
				object[] b = new object[result];
				
				a[1] = "@UserID";
				b[1] = p.UserID;
				a[2] = "@TenVatTu";
				b[2] = p.TenVatTu;
				a[3] = "@MaVatTu";
				b[3] = p.MaVatTu;
				a[4] = "@Hang";
				b[4] = p.Hang;
				a[5] = "@MaSP";
				b[5] = p.MaSP;
				a[6] = "@TenDuAn";
				b[6] = p.TenDuAn;
				a[7] = "@MaDuAn";
				b[7] = p.MaDuAn;
				a[8] = "@SoLuong";
				b[8] = p.SoLuong;
				a[9] = "@NgayYeuCau";
				b[9] = p.NgayYeuCau;
				a[10] = "@NgayVeDuKien";
				b[10] = p.NgayVeDuKien;
				a[11] = "@NgayThucTe";
				b[11] = p.NgayThucTe;
				a[12] = "@ThoiGianDatHangTHucTe";
				b[12] = p.ThoiGianDatHangTHucTe;
				a[13] = "@NguyenNhanCham";
				b[13] = p.NguyenNhanCham;
				a[0] = "@GhiChu";
				b[0] = p.GhiChu;
				result = obj.UpdateData("YeuCauVatTu_Insert",  a, b,result);
			}
			catch(Exception ex)
			{
				throw ex;
			}
			return result;
		}

		// Update
		public int Update(TheoDoiVatTu_Entities.YeuCauVatTu_Entities p)
		{
			int result = 15;
			try
			{
				string[] a = new string[result];
				object[] b = new object[result];
				a[1] = "@UserID";
				b[1] = p.UserID;
				a[2] = "@TenVatTu";
				b[2] = p.TenVatTu;
				a[3] = "@MaVatTu";
				b[3] = p.MaVatTu;
				a[4] = "@Hang";
				b[4] = p.Hang;
				a[5] = "@MaSP";
				b[5] = p.MaSP;
				a[6] = "@TenDuAn";
				b[6] = p.TenDuAn;
				a[7] = "@MaDuAn";
				b[7] = p.MaDuAn;
				a[8] = "@SoLuong";
				b[8] = p.SoLuong;
				a[9] = "@NgayYeuCau";
				b[9] = p.NgayYeuCau;
				a[10] = "@NgayVeDuKien";
				b[10] = p.NgayVeDuKien;
				a[11] = "@NgayThucTe";
				b[11] = p.NgayThucTe;
				a[12] = "@ThoiGianDatHangTHucTe";
				b[12] = p.ThoiGianDatHangTHucTe;
				a[13] = "@NguyenNhanCham";
				b[13] = p.NguyenNhanCham;
				a[14] = "@GhiChu";
				b[14] = p.GhiChu;
				a[0] = "@ID";
				b[0] = p.ID;
				result = obj.UpdateData("YeuCauVatTu_Update", a, b,result);
			}
			catch(Exception ex)
			{
				throw ex;
			}
			return result;
		}

		// Del
		public int Delete(TheoDoiVatTu_Entities.YeuCauVatTu_Entities p)
		{
			int result = 1;
			try
			{
				string[] a = new string[result];
				object[] b = new object[result];
				a[0] = "@ID";
				b[0] = p.ID;
				result = obj.UpdateData("YeuCauVatTu_Delete", a, b, result);
			}
			catch(Exception ex)
			{
				throw ex;
			}
			return result;
		}

		// SelectByID
		public DataTable SelectByID(TheoDoiVatTu_Entities.YeuCauVatTu_Entities p)
		{
			DataTable result = null;
			try
			{
				string[] a = new string[1];
				object[] b = new object[1];
				a[0] = "@ID";
				b[0] = p.UserID;
				result = obj.LoadData( "YeuCauVatTu_SelectByID", a, b, 1);
			}
			catch(Exception ex)
			{
				throw ex;
			}
			return result;
		}

		// SelectALL
		public DataTable SelectAll()
		{
			DataTable result = null;
			try
			{
				result = obj.LoadData("YeuCauVatTu_SelectAll");
			}
			catch(Exception ex)
			{
				throw ex;
			}
			return result;
		}

		#endregion

		// Dong Class
	}
}


