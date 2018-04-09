
using System;
namespace BMS.Model
{
	public class MaterialParamValueNSModel : BaseModel
	{
		private int iD;
		private int materialParamNSID;
		private string valueTS;
		private string description;
		public int ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public int MaterialParamNSID
		{
			get { return materialParamNSID; }
			set { materialParamNSID = value; }
		}
	
		public string ValueTS
		{
            get { return valueTS; }
            set { valueTS = value; }
		}
	
		public string Description
		{
			get { return description; }
			set { description = value; }
		}
	
	}
}
	