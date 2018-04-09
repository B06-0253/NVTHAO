
using System;
namespace TPA.Model
{
	public class PartsConfigLinkModel : BaseModel
	{
		private int iD;
		private string partsGeneralId;
		private string partsId;
		private string moduleCode;
		private string groupCode;
		private int type;
		private decimal qty;
		public int ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public string PartsGeneralId
		{
			get { return partsGeneralId; }
			set { partsGeneralId = value; }
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
	
		public string GroupCode
		{
			get { return groupCode; }
			set { groupCode = value; }
		}
	
		public int Type
		{
			get { return type; }
			set { type = value; }
		}
	
		public decimal Qty
		{
			get { return qty; }
			set { qty = value; }
		}
	
	}
}
	