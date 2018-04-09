
using System;
namespace BMS.Model
{
	public class MaterialFileLinkModel : BaseModel
	{
		private int iD;
		private int materialID;
		private int materialFileID;
		public int ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public int MaterialID
		{
			get { return materialID; }
			set { materialID = value; }
		}
	
		public int MaterialFileID
		{
			get { return materialFileID; }
			set { materialFileID = value; }
		}
	
	}
}
	