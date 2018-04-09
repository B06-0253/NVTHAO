
using System;

namespace BMS.Model
{
	public class CustomerModel : BaseModel
	{
		private int iD;
		private string code;
		private string name;
		private int userID;
		private int status;
		private string email;
		private string address;
		private string phone;
        private int type;

        public int Type
        {
            get { return type; }
            set { type = value; }
        }
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
	
		public int UserID
		{
			get { return userID; }
			set { userID = value; }
		}
	
		public int Status
		{
			get { return status; }
			set { status = value; }
		}
	
		public string Email
		{
			get { return email; }
			set { email = value; }
		}
	
		public string Address
		{
			get { return address; }
			set { address = value; }
		}
	
		public string Phone
		{
			get { return phone; }
			set { phone = value; }
		}
	
	}
}
	