
using System;
namespace TPA.Model
{
	public class C_UserModel : BaseModel
	{
		private int iD;
		private string code;
		private string name;
		private int c_UserGroupID;
		private string note;
		private decimal salary;
		private decimal salaryBH;
		public int ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public string Code
		{
			get { return code; }
			set { code = value; }
		}
	
		public string Name
		{
			get { return name; }
			set { name = value; }
		}
	
		public int C_UserGroupID
		{
			get { return c_UserGroupID; }
			set { c_UserGroupID = value; }
		}
	
		public string Note
		{
			get { return note; }
			set { note = value; }
		}
	
		public decimal Salary
		{
			get { return salary; }
			set { salary = value; }
		}
	
		public decimal SalaryBH
		{
			get { return salaryBH; }
			set { salaryBH = value; }
		}
	
	}
}
	