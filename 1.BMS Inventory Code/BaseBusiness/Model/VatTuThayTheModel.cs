//---------------------------------------------------------------------------
// Author : CanhHungIT
// Created Date : Thursday, July 17, 2014
//---------------------------------------------------------------------------


// Khai bao lop
using System;

namespace BMS.Model
{
	public class VatTuThayTheModel : BaseModel
	{

		// Cac bien so
		#region Vars
		private int _ID = 0;
		private int _STT = 0;
		private DateTime _Ngay = DateTime.Now;
		private string _NameTK = "";
		private string _CodeTK = "";
		private string _HangTK = "";
		private string _NameTT = "";
		private string _CodeTT = "";
		private string _HangTT = "";
		private string _ThuocThietBi = "";
		private string _ChiTietLienQuan = "";
		private string _Status = "";
		private string _CodeAfter = "";
		private string _Note = "";
		private string _CreatedBy = "";
		private DateTime _CreatedDate = DateTime.Now;
		private string _UpdatedBy = "";
		private DateTime _UpdatedDate = DateTime.Now;
		private int _Type = 0;
		#endregion

		#region Property
		// Cac thuoc tinh
		public int ID
		{
			get{ return _ID; }
			set{ _ID = value; }
		}
		public int STT
		{
			get{ return _STT; }
			set{ _STT = value; }
		}
		public DateTime Ngay
		{
			get{ return _Ngay; }
			set{ _Ngay = value; }
		}
		public string NameTK
		{
			get{ return _NameTK; }
			set{ _NameTK = value; }
		}
		public string CodeTK
		{
			get{ return _CodeTK; }
			set{ _CodeTK = value; }
		}
		public string HangTK
		{
			get{ return _HangTK; }
			set{ _HangTK = value; }
		}
		public string NameTT
		{
			get{ return _NameTT; }
			set{ _NameTT = value; }
		}
		public string CodeTT
		{
			get{ return _CodeTT; }
			set{ _CodeTT = value; }
		}
		public string HangTT
		{
			get{ return _HangTT; }
			set{ _HangTT = value; }
		}
		public string ThuocThietBi
		{
			get{ return _ThuocThietBi; }
			set{ _ThuocThietBi = value; }
		}
		public string ChiTietLienQuan
		{
			get{ return _ChiTietLienQuan; }
			set{ _ChiTietLienQuan = value; }
		}
		public string Status
		{
			get{ return _Status; }
			set{ _Status = value; }
		}
		public string CodeAfter
		{
			get{ return _CodeAfter; }
			set{ _CodeAfter = value; }
		}
		public string Note
		{
			get{ return _Note; }
			set{ _Note = value; }
		}
		public string CreatedBy
		{
			get{ return _CreatedBy; }
			set{ _CreatedBy = value; }
		}
		public DateTime CreatedDate
		{
			get{ return _CreatedDate; }
			set{ _CreatedDate = value; }
		}
		public string UpdatedBy
		{
			get{ return _UpdatedBy; }
			set{ _UpdatedBy = value; }
		}
		public DateTime UpdatedDate
		{
			get{ return _UpdatedDate; }
			set{ _UpdatedDate = value; }
		}
		public int Type
		{
			get{ return _Type; }
			set{ _Type = value; }
		}
		#endregion

	}
}


