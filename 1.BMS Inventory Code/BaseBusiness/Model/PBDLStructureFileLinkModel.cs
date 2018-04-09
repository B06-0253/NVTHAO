
using System;
namespace BMS.Model
{
	public class PBDLStructureFileLinkModel : BaseModel
	{
		private int iD;
		private int pBDLStructureID;
		private int pBDLFileID;
		public int ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public int PBDLStructureID
		{
			get { return pBDLStructureID; }
			set { pBDLStructureID = value; }
		}
	
		public int PBDLFileID
		{
			get { return pBDLFileID; }
			set { pBDLFileID = value; }
		}
	
	}
}
	