
using System;
namespace TEST.Model
{
	public class C_CostGroupNewModel : BaseModel
	{
		private int iD;
		private string code;
		private string name;
		private int parentID;
		private string description;
		private int sttSX;
		private int sttKD;
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
	
		public int ParentID
		{
			get { return parentID; }
			set { parentID = value; }
		}
	
		public string Description
		{
			get { return description; }
			set { description = value; }
		}
	
		public int SttSX
		{
			get { return sttSX; }
			set { sttSX = value; }
		}
	
		public int SttKD
		{
			get { return sttKD; }
			set { sttKD = value; }
		}
	
	}
}
	