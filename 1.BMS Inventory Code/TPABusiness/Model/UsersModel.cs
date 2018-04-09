
using System;
namespace TPA.Model
{
	public class UsersModel : BaseModel
	{
		private string userId;
		private string account;
		private string userName;
		private string password;
		private string departmentId;
		private int role;
		private string salt;
		private int statusDisable;
		private int statusLogin;
		private string userGroupId;
		private string computerName;
		private string code;
        private string departmentId1;
		public string UserId
		{
			get { return userId; }
			set { userId = value; }
		}
	
		public string Account
		{
			get { return account; }
			set { account = value; }
		}
	
		public string UserName
		{
			get { return userName; }
			set { userName = value; }
		}
	
		public string Password
		{
			get { return password; }
			set { password = value; }
		}
	
		public string DepartmentId
		{
			get { return departmentId; }
			set { departmentId = value; }
		}
	
		public int Role
		{
			get { return role; }
			set { role = value; }
		}
	
		public string Salt
		{
			get { return salt; }
			set { salt = value; }
		}
	
		public int StatusDisable
		{
			get { return statusDisable; }
			set { statusDisable = value; }
		}
	
		public int StatusLogin
		{
			get { return statusLogin; }
			set { statusLogin = value; }
		}
	
		public string UserGroupId
		{
			get { return userGroupId; }
			set { userGroupId = value; }
		}
	
		public string ComputerName
		{
			get { return computerName; }
			set { computerName = value; }
		}
	
		public string Code
		{
			get { return code; }
			set { code = value; }
		}

        public string DepartmentId1
        {
            get { return departmentId1; }
            set { departmentId1 = value; }
        }
    }
}
	