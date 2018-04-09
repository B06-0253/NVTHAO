
using System;
namespace TPA.Model
{
	public class UserGroup1Model : BaseModel
	{
		private int iD;
		private string code;
		private string name;
		private string departmentId;
		private string userId;
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
	
		public string DepartmentId
		{
			get { return departmentId; }
			set { departmentId = value; }
		}
	
		public string UserId
		{
			get { return userId; }
			set { userId = value; }
		}
	
	}
}
	