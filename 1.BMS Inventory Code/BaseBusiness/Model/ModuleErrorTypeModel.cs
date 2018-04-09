
using System;
namespace BMS.Model
{
	public class ModuleErrorTypeModel : BaseModel
	{
		private int iD;
		private string name;
		private int type;
		private int groupID;
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
	
		public int Type
		{
			get { return type; }
			set { type = value; }
		}
	
		public int GroupID
		{
			get { return groupID; }
			set { groupID = value; }
		}
	
	}
}
	