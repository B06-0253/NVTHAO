
using System;
namespace BMS.Model
{
	public class MaterialParameterValueModel : BaseModel
	{
		private int iD;
		private int materialParameterID;
        private string paraValue;
		public int ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public int MaterialParameterID
		{
			get { return materialParameterID; }
			set { materialParameterID = value; }
		}
	
		public string ParaValue
		{
            get { return paraValue; }
            set { paraValue = value; }
		}
	
	}
}
	