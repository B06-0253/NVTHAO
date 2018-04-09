
using System;
namespace BMS.Model
{
	public class MaterialParamNSModel : BaseModel
	{
		private int iD;
		private int materialNSID;
		private string code;
		private string name;
		private string description;
		private string note;
		private string unit;
		public int ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public int MaterialNSID
		{
			get { return materialNSID; }
			set { materialNSID = value; }
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
	
		public string Description
		{
			get { return description; }
			set { description = value; }
		}
	
		public string Note
		{
			get { return note; }
			set { note = value; }
		}
	
		public string Unit
		{
			get { return unit; }
			set { unit = value; }
		}
	
	}
}
	