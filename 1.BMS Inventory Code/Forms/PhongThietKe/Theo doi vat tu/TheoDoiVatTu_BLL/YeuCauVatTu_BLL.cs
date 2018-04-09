//---------------------------------------------------------------------------
// Author : CanhHungIT
// Created Date : Monday, September 22, 2014
//---------------------------------------------------------------------------


// Khai bao lop
using System;
using System.Collections;
using System.Data;
using TheoDoiVatTu_Entities;//Add reference vao
using TheoDoiVatTu_DAL;//Add reference vao
namespace TheoDoiVatTu_BLL
{
	public class YeuCauVatTu_BLL
	{
		// Ham khoi tao khong tham so
		#region Constructor
		public YeuCauVatTu_BLL(){}
		#endregion

		private TheoDoiVatTu_DAL.YeuCauVatTu_DAL obj= new TheoDoiVatTu_DAL.YeuCauVatTu_DAL();
		#region Function
		// Insert
		public int Insert(TheoDoiVatTu_Entities.YeuCauVatTu_Entities p)
		{
			return obj.Insert(p);
		}

		// Update
		public int Update(TheoDoiVatTu_Entities.YeuCauVatTu_Entities p)
		{
			return obj.Update(p);
		}

		// Del
		public int Delete(TheoDoiVatTu_Entities.YeuCauVatTu_Entities p)
		{
			 return obj.Delete(p);
		}

		// SelectByID
		public DataTable SelectByID(TheoDoiVatTu_Entities.YeuCauVatTu_Entities p)
		{
			 return obj.SelectByID(p);
		}

		// SelectALL
		public DataTable SelectAll()
		{
			 return obj.SelectAll();
		}

		#endregion

		// Dong Class
	}
}


