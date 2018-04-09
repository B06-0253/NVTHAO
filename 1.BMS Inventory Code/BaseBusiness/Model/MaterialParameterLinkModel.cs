
using System;
namespace BMS.Model
{
	public class MaterialParameterLinkModel : BaseModel
	{
		private int iD;
		private int materialID;
		private int materialParameterID;
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
	
		public int MaterialParameterID
		{
			get { return materialParameterID; }
			set { materialParameterID = value; }
		}
	
	}
}
	