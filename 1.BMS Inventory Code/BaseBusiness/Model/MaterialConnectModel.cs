
using System;
namespace BMS.Model
{
	public class MaterialConnectModel : BaseModel
	{
		private int iD;
		private int materialID;
		private int materialParameterID;
		private int materialParameterValueID;
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
	
		public int MaterialParameterValueID
		{
			get { return materialParameterValueID; }
			set { materialParameterValueID = value; }
		}
	
	}
}
	