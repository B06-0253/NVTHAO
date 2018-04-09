
using System;
namespace TPA.Model
{
	public class C_UserGroupModel : BaseModel
	{
		private int iD;
		private string code;
		private string name;
		private int c_CostID;
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
	
		public int C_CostID
		{
			get { return c_CostID; }
			set { c_CostID = value; }
		}
	
	}
}
	