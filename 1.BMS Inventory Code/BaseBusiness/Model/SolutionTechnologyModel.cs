
using System;
namespace BMS.Model
{
	public class SolutionTechnologyModel : BaseModel
	{
		private int iD;
		private string name;
		private string description;
		private int type;
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
	
		public string Description
		{
			get { return description; }
			set { description = value; }
		}
	
		public int Type
		{
			get { return type; }
			set { type = value; }
		}
	
	}
}
	