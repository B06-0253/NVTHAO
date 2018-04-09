
using System;
namespace TEST.Model
{
	public class PartsNotDMVTModel : BaseModel
	{
		private int iD;
		private string partsId;
		private string moduleCode;
		private decimal qty;
		public int ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public string PartsId
		{
			get { return partsId; }
			set { partsId = value; }
		}
	
		public string ModuleCode
		{
			get { return moduleCode; }
			set { moduleCode = value; }
		}
	
		public decimal Qty
		{
			get { return qty; }
			set { qty = value; }
		}
	
	}
}
	