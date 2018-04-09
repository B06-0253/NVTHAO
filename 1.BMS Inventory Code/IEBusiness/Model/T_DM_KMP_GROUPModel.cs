
using System;
namespace IE.Model
{
	public class T_DM_KMP_GROUPModel : BaseModel
	{
		private int iD;
		private string c_Code;
		private string c_Name;
		private int parentID;
		private string c_MOTA;
		public int ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public string C_Code
		{
			get { return c_Code; }
			set { c_Code = value; }
		}
	
		public string C_Name
		{
			get { return c_Name; }
			set { c_Name = value; }
		}
	
		public int ParentID
		{
			get { return parentID; }
			set { parentID = value; }
		}
	
		public string C_MOTA
		{
			get { return c_MOTA; }
			set { c_MOTA = value; }
		}
	
	}
}
	