//---------------------------------------------------------------------------
// Author : CanhHungIT
// Created Date : Tuesday, September 23, 2014
//---------------------------------------------------------------------------


// Khai bao lop
using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using TheoDoiVatTu_Entities ;//Add reference vao
namespace TheoDoiVatTu_DAL
{
	public class Users_DAL
	{
		// Ham khoi tao khong tham so
		#region Constructor
		public Users_DAL(){}
		#endregion

		private TheoDoiVatTu_DAL.KetNoi obj= new TheoDoiVatTu_DAL.KetNoi();
		#region Function
		
		// SelectALL
		public DataTable SelectAll()
		{
			DataTable result = null;
			try
			{
				result = obj.LoadData("Users_SelectAll");
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


