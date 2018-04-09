
using System;
namespace TPA.Model
{
	public class DepartmentsModel : BaseModel
	{
		private string departmentId;
		private string dName;
		private string dCode;
		private string iCode;
		private string iName;
		private int isUse;
		private string userId;
		public string DepartmentId
		{
			get { return departmentId; }
			set { departmentId = value; }
		}
	
		public string DName
		{
			get { return dName; }
			set { dName = value; }
		}
	
		public string DCode
		{
			get { return dCode; }
			set { dCode = value; }
		}
	
		public string ICode
		{
			get { return iCode; }
			set { iCode = value; }
		}
	
		public string IName
		{
			get { return iName; }
			set { iName = value; }
		}
	
		public int IsUse
		{
			get { return isUse; }
			set { isUse = value; }
		}
	
		public string UserId
		{
			get { return userId; }
			set { userId = value; }
		}
	
	}
}
	