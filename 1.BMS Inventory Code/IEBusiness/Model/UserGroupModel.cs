
using System;
namespace IE.Model
{
	public class UserGroupModel : BaseModel
	{
		private int iD;
		private string name;
		private string code;
		private int truongNhom;
		private int departmentID;
		public int ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public string Name
		{
			get { return name; }
			set { name = value; }
		}
	
		public string Code
		{
			get { return code; }
			set { code = value; }
		}
	
		public int TruongNhom
		{
			get { return truongNhom; }
			set { truongNhom = value; }
		}
	
		public int DepartmentID
		{
			get { return departmentID; }
			set { departmentID = value; }
		}
	
	}
}
	