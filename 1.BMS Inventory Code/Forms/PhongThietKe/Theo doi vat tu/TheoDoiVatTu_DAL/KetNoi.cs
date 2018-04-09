//---------------------------------------------------------------------------
// Author : CanhHungIT
// Created Date : Monday, September 22, 2014
//---------------------------------------------------------------------------


// Khai bao lop
using System;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using BMS;
namespace TheoDoiVatTu_DAL
{
	public class KetNoi
	{
		#region Mo Ket Noi
		 private SqlConnection con;
         public void MoKetNoi()
         {
             string chuoikn = Global.ConnectionString;// "Data Source=192.168.20.115;Initial Catalog=QLKHCV;User Id=tpa;Password=123456";
             con = new SqlConnection(chuoikn);
             con.Open();//Mo Ket Noi
         }
		#endregion

		#region Dong Ket Noi
		 public void DongKetNoi()
		 {
			con.Close();//Dong Ket Noi
		 }
		#endregion

		#region Ham Xu Ly
		public DataTable LoadData(string sql)
		{
			MoKetNoi();
			SqlCommand command = new SqlCommand(sql, con);
			command.CommandType = CommandType.StoredProcedure;
			SqlDataAdapter adapter = new SqlDataAdapter(command);
			DataTable dt = new DataTable();
			adapter.Fill(dt);
			return dt;
			DongKetNoi();
		}
		public DataTable LoadData(string sql, string[] name, object[] value, int nparameter)
		{
			MoKetNoi();
			SqlCommand command = new SqlCommand(sql, con);
			command.CommandType = CommandType.StoredProcedure;
			for (int i = 0; i < nparameter; i++)
			{
				command.Parameters.AddWithValue(name[i], value[i]);
			}
			SqlDataAdapter adapter = new SqlDataAdapter(command);
			DataTable dt = new DataTable();
			adapter.Fill(dt);
			return dt;
			DongKetNoi();
		}
		public int UpdateData(string sql)
		{
			MoKetNoi();
			SqlCommand command = new SqlCommand(sql, con);
			command.CommandType = CommandType.StoredProcedure;
			return command.ExecuteNonQuery();
			DongKetNoi();
		}
		public int UpdateData(string sql, string[] name, object[] value, int nparameter)
		{
			MoKetNoi();
			SqlCommand command = new SqlCommand(sql, con);
			command.CommandType = CommandType.StoredProcedure;
			for (int i = 0; i < nparameter; i++)
			{
				command.Parameters.AddWithValue(name[i], value[i]);
			}
			return command.ExecuteNonQuery();
			DongKetNoi();
		}
		#endregion

	}
}


