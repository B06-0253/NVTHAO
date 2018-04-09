
using System;
namespace BMS.Model
{
	public class MaterialNSModel : BaseModel
	{
		private int iD;
		private int parentID;
		private string code;
		private string name;
		private int customerID;
		private string description;
		private int type;
		private int numberTS;
		private string filePath;
		public int ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public int ParentID
		{
			get { return parentID; }
			set { parentID = value; }
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
	
		public int CustomerID
		{
			get { return customerID; }
			set { customerID = value; }
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
	
		public int NumberTS
		{
			get { return numberTS; }
			set { numberTS = value; }
		}
	
		public string FilePath
		{
			get { return filePath; }
			set { filePath = value; }
		}
	
	}
}
	