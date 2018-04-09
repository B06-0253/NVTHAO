//---------------------------------------------------------------------------
// Author : CanhHungIT
// Created Date : Thursday, July 24, 2014
//---------------------------------------------------------------------------


// Khai bao lop
using System;

namespace BMS.Model
{
	public class DesignStructureModel : BaseModel
	{
		// Cac bien so
        private Int64 _ID = 0;
		private int _Type = 0;
		private string _Name = "";
		private int _ParentID = 0;
		private string _Path = "";
		private string _CreatedBy = "";
		private DateTime _CreatedDate = DateTime.Now;
		private string _UpdatedBy = "";
		private DateTime _UpdatedDate = DateTime.Now;
		private string _ParentPath = "";

        private string _Extension;

        public string Extension
        {
            get { return _Extension; }
            set { _Extension = value; }
        }
        private string _Contain;

        public string Contain
        {
            get { return _Contain; }
            set { _Contain = value; }
        }

        private bool isCheckContent;

        public bool IsCheckContent
        {
            get { return isCheckContent; }
            set { isCheckContent = value; }
        }
        private string description;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

		#region Property
		// Cac thuoc tinh
		public Int64 ID
		{
			get{ return _ID; }
			set{ _ID = value; }
		}
		public int Type
		{
			get{ return _Type; }
			set{ _Type = value; }
		}
		public string Name
		{
			get{ return _Name; }
			set{ _Name = value; }
		}
		public int ParentID
		{
			get{ return _ParentID; }
			set{ _ParentID = value; }
		}
		public string Path
		{
			get{ return _Path; }
			set{ _Path = value; }
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
		public string ParentPath
		{
			get{ return _ParentPath; }
			set{ _ParentPath = value; }
		}
		#endregion

	}
}


