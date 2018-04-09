//---------------------------------------------------------------------------
// Author : CanhHungIT
// Created Date : Monday, July 28, 2014
//---------------------------------------------------------------------------


// Khai bao lop
using System;

namespace BMS.Model
{
	public class ConfigSystemModel : BaseModel
	{
		// Cac bien so
		#region Vars
		private int _ID = 0;
		private string _KeyName = "";
		private string _KeyValue = "";
		private string _KeyValue1 = "";
		private string _KeyValue2 = "";
		private string _KeyValue3 = "";
		private string _KeyValue4 = "";
		private string _KeyValue5 = "";
		private string _KeyValue6 = "";
		private string _KeyValue7 = "";
		private string _KeyValue8 = "";
		private string _KeyValue9 = "";
		private string _KeyValue10 = "";
		private string _Description = "";
		private string _CreatedBy = "";
		private DateTime _CreatedDate = DateTime.Now;
		private string _UpdatedBy = "";
		private DateTime _UpdatedDate = DateTime.Now;
		#endregion

		#region Property
		// Cac thuoc tinh
		public int ID
		{
			get{ return _ID; }
			set{ _ID = value; }
		}
		public string KeyName
		{
			get{ return _KeyName; }
			set{ _KeyName = value; }
		}
		public string KeyValue
		{
			get{ return _KeyValue; }
			set{ _KeyValue = value; }
		}
		public string KeyValue1
		{
			get{ return _KeyValue1; }
			set{ _KeyValue1 = value; }
		}
		public string KeyValue2
		{
			get{ return _KeyValue2; }
			set{ _KeyValue2 = value; }
		}
		public string KeyValue3
		{
			get{ return _KeyValue3; }
			set{ _KeyValue3 = value; }
		}
		public string KeyValue4
		{
			get{ return _KeyValue4; }
			set{ _KeyValue4 = value; }
		}
		public string KeyValue5
		{
			get{ return _KeyValue5; }
			set{ _KeyValue5 = value; }
		}
		public string KeyValue6
		{
			get{ return _KeyValue6; }
			set{ _KeyValue6 = value; }
		}
		public string KeyValue7
		{
			get{ return _KeyValue7; }
			set{ _KeyValue7 = value; }
		}
		public string KeyValue8
		{
			get{ return _KeyValue8; }
			set{ _KeyValue8 = value; }
		}
		public string KeyValue9
		{
			get{ return _KeyValue9; }
			set{ _KeyValue9 = value; }
		}
		public string KeyValue10
		{
			get{ return _KeyValue10; }
			set{ _KeyValue10 = value; }
		}
		public string Description
		{
			get{ return _Description; }
			set{ _Description = value; }
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
		#endregion

	}
}


