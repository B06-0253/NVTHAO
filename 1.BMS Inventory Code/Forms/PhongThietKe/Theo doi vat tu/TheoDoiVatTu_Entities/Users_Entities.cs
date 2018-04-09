//---------------------------------------------------------------------------
// Author : CanhHungIT
// Created Date : Tuesday, September 23, 2014
//---------------------------------------------------------------------------


// Khai bao lop
using System;

namespace TheoDoiVatTu_Entities
{
	public class Users_Entities
	{
		// Ham khoi tao khong tham so
		#region Constructor
		public Users_Entities()
		{

		}

		#endregion

		// Cac bien so
		#region Vars
		private int _ID = 0;
		private string _Code = "";
		private string _LoginName = "";
		private string _PasswordHash = "";
		private string _FullName = "";
		private DateTime _BirthOfDate = DateTime.Now;
		private int _Sex = 0;
		private string _Qualifications = "";
		private string _BankAccount = "";
		private string _BHYT = "";
		private string _MST = "";
		private string _BHXH = "";
		private string _CMTND = "";
		private string _JobDescription = "";
		private string _Telephone = "";
		private string _HandPhone = "";
		private string _HomeAddress = "";
		private string _Resident = "";
		private string _PostalCode = "";
		private int _DepartmentID = 0;
		private int _Status = 0;
		private string _Communication = "";
		private DateTime _PassExpireDate = DateTime.Now;
		private bool _IsCashier = false;
		private int _CashierNo = 0;
		private string _EmailCom = "";
		private string _Email = "";
		private DateTime _StartWorking = DateTime.Now;
		private int _UserGroupID = 0;
		private int _MainViewID = 0;
		private string _Position = "";
		private bool _IsSetupFunction = false;
		//private text _ImagePath = "";
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
		public string Code
		{
			get{ return _Code; }
			set{ _Code = value; }
		}
		public string LoginName
		{
			get{ return _LoginName; }
			set{ _LoginName = value; }
		}
		public string PasswordHash
		{
			get{ return _PasswordHash; }
			set{ _PasswordHash = value; }
		}
		public string FullName
		{
			get{ return _FullName; }
			set{ _FullName = value; }
		}
		public DateTime BirthOfDate
		{
			get{ return _BirthOfDate; }
			set{ _BirthOfDate = value; }
		}
		public int Sex
		{
			get{ return _Sex; }
			set{ _Sex = value; }
		}
		public string Qualifications
		{
			get{ return _Qualifications; }
			set{ _Qualifications = value; }
		}
		public string BankAccount
		{
			get{ return _BankAccount; }
			set{ _BankAccount = value; }
		}
		public string BHYT
		{
			get{ return _BHYT; }
			set{ _BHYT = value; }
		}
		public string MST
		{
			get{ return _MST; }
			set{ _MST = value; }
		}
		public string BHXH
		{
			get{ return _BHXH; }
			set{ _BHXH = value; }
		}
		public string CMTND
		{
			get{ return _CMTND; }
			set{ _CMTND = value; }
		}
		public string JobDescription
		{
			get{ return _JobDescription; }
			set{ _JobDescription = value; }
		}
		public string Telephone
		{
			get{ return _Telephone; }
			set{ _Telephone = value; }
		}
		public string HandPhone
		{
			get{ return _HandPhone; }
			set{ _HandPhone = value; }
		}
		public string HomeAddress
		{
			get{ return _HomeAddress; }
			set{ _HomeAddress = value; }
		}
		public string Resident
		{
			get{ return _Resident; }
			set{ _Resident = value; }
		}
		public string PostalCode
		{
			get{ return _PostalCode; }
			set{ _PostalCode = value; }
		}
		public int DepartmentID
		{
			get{ return _DepartmentID; }
			set{ _DepartmentID = value; }
		}
		public int Status
		{
			get{ return _Status; }
			set{ _Status = value; }
		}
		public string Communication
		{
			get{ return _Communication; }
			set{ _Communication = value; }
		}
		public DateTime PassExpireDate
		{
			get{ return _PassExpireDate; }
			set{ _PassExpireDate = value; }
		}
		public bool IsCashier
		{
			get{ return _IsCashier; }
			set{ _IsCashier = value; }
		}
		public int CashierNo
		{
			get{ return _CashierNo; }
			set{ _CashierNo = value; }
		}
		public string EmailCom
		{
			get{ return _EmailCom; }
			set{ _EmailCom = value; }
		}
		public string Email
		{
			get{ return _Email; }
			set{ _Email = value; }
		}
		public DateTime StartWorking
		{
			get{ return _StartWorking; }
			set{ _StartWorking = value; }
		}
		public int UserGroupID
		{
			get{ return _UserGroupID; }
			set{ _UserGroupID = value; }
		}
		public int MainViewID
		{
			get{ return _MainViewID; }
			set{ _MainViewID = value; }
		}
		public string Position
		{
			get{ return _Position; }
			set{ _Position = value; }
		}
		public bool IsSetupFunction
		{
			get{ return _IsSetupFunction; }
			set{ _IsSetupFunction = value; }
		}
        //public text ImagePath
        //{
        //    get{ return _ImagePath; }
        //    set{ _ImagePath = value; }
        //}
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


