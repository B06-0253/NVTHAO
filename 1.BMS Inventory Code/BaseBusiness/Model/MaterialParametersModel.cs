//---------------------------------------------------------------------------
// Author : CanhHungIT
// Created Date : Thursday, July 17, 2014
//---------------------------------------------------------------------------


// Khai bao lop
using System;

namespace BMS.Model
{
	public class MaterialParametersModel : BaseModel
	{

		// Cac bien so
		#region Vars
		private int _ID = 0;
		private string _Name = "";
		private int _MaterialGroupID = 0;
		private string _CreatedBy = "";
		private DateTime _CreatedDate = DateTime.Now;
		private string _UpdatedBy = "";
		private DateTime _UpdatedDate = DateTime.Now;
        private int _sTT;

        public int STT
        {
            get { return _sTT; }
            set { _sTT = value; }
        }
		#endregion

		#region Property
		// Cac thuoc tinh
		public int ID
		{
			get{ return _ID; }
			set{ _ID = value; }
		}
		public string Name
		{
			get{ return _Name; }
			set{ _Name = value; }
		}
		public int MaterialGroupID
		{
			get{ return _MaterialGroupID; }
			set{ _MaterialGroupID = value; }
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


