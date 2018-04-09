
using System;
namespace BMS.Model
{
	public class ConfigNoConvertMaterialModel : BaseModel
	{
		private int iD;
		private string materialCode;
		private string materialName;
		private string unitTK;
		private string unitQLSX;
		public int ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public string MaterialCode
		{
			get { return materialCode; }
			set { materialCode = value; }
		}
	
		public string MaterialName
		{
			get { return materialName; }
			set { materialName = value; }
		}
	
		public string UnitTK
		{
			get { return unitTK; }
			set { unitTK = value; }
		}
	
		public string UnitQLSX
		{
			get { return unitQLSX; }
			set { unitQLSX = value; }
		}
	
	}
}
	