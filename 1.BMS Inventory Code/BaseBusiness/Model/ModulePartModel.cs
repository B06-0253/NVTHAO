
using System;
namespace BMS.Model
{
	public class ModulePartModel : BaseModel
	{
		private int iD;
		private int moduleID;
		private string code;
		private string name;
		private int qty;
		public int ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public int ModuleID
		{
			get { return moduleID; }
			set { moduleID = value; }
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
	
		public int Qty
		{
			get { return qty; }
			set { qty = value; }
		}
	
	}
}
	