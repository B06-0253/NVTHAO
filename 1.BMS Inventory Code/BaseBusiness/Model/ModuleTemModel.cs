
using System;
namespace BMS.Model
{
	public class ModuleTemModel : BaseModel
	{
		private int iD;
		private string code;
		private string name;
		private int lastTimeChange;
		private DateTime lastDateChange;
		private int moduleID;
		private int type;
		private int size;
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
	
		public int LastTimeChange
		{
			get { return lastTimeChange; }
			set { lastTimeChange = value; }
		}
	
		public DateTime LastDateChange
		{
			get { return lastDateChange; }
			set { lastDateChange = value; }
		}
	
		public int ModuleID
		{
			get { return moduleID; }
			set { moduleID = value; }
		}
	
		public int Type
		{
			get { return type; }
			set { type = value; }
		}
	
		public int Size
		{
			get { return size; }
			set { size = value; }
		}
	
	}
}
	