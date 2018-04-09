//---------------------------------------------------------------------------
// Author : CanhHungIT
// Created Date : Tuesday, July 15, 2014
//---------------------------------------------------------------------------


// Khai bao lop
using System;

namespace BMS.Model
{
	public class MaterialGroupModel : BaseModel
	{
		// Cac bien so
		#region Vars
		private int _ID = 0;
		private string _Code = "";
		private string _Name = "";
		private string _CreatedBy = "";
		private DateTime _CreatedDate = DateTime.Now;
		private string _UpdatedBy = "";
		private DateTime _UpdatedDate = DateTime.Now;
		private int _ParentID = 0;
		private string _Description = "";
		#endregion

		#region Property
		// Cac thuoc tinh
		public int ID
		{
			get{ return _ID; }
			set{ _ID = value; }
		}
		public string Code
		{
			get{ return _Code; }
			set{ _Code = value; }
		}
		public string Name
		{
			get{ return _Name; }
			set{ _Name = value; }
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
		public int ParentID
		{
			get{ return _ParentID; }
			set{ _ParentID = value; }
		}
		public string Description
		{
			get{ return _Description; }
			set{ _Description = value; }
		}
		#endregion

	}
}


