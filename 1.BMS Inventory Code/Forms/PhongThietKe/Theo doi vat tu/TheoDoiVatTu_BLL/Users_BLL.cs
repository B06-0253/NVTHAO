//---------------------------------------------------------------------------
// Author : CanhHungIT
// Created Date : Tuesday, September 23, 2014
//---------------------------------------------------------------------------


// Khai bao lop
using System;
using System.Collections;
using System.Data;
using TheoDoiVatTu_Entities;//Add reference vao
using TheoDoiVatTu_DAL;//Add reference vao
namespace TheoDoiVatTu_BLL
{
	public class Users_BLL
	{
		// Ham khoi tao khong tham so
		#region Constructor
		public Users_BLL(){}
		#endregion

		private TheoDoiVatTu_DAL.Users_DAL obj= new TheoDoiVatTu_DAL.Users_DAL();
		#region Function
		// Insert
	
		// SelectALL
		public DataTable SelectAll()
		{
			 return obj.SelectAll();
		}

		#endregion

		// Dong Class
	}
}


