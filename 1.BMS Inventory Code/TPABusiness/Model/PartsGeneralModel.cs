
using System;
namespace TPA.Model
{
	public class PartsGeneralModel : BaseModel
	{
		private string partsId;
		private decimal qtyMin;
		private decimal qtyDM;
		private decimal qty;
		private decimal total;
		private decimal projectPercent;
		private int isProject;
		private int type;
		public string PartsId
		{
			get { return partsId; }
			set { partsId = value; }
		}
	
		public decimal QtyMin
		{
			get { return qtyMin; }
			set { qtyMin = value; }
		}
	
		public decimal QtyDM
		{
			get { return qtyDM; }
			set { qtyDM = value; }
		}
	
		public decimal Qty
		{
			get { return qty; }
			set { qty = value; }
		}
	
		public decimal Total
		{
			get { return total; }
			set { total = value; }
		}
	
		public decimal ProjectPercent
		{
			get { return projectPercent; }
			set { projectPercent = value; }
		}
	
		public int IsProject
		{
			get { return isProject; }
			set { isProject = value; }
		}
	
		public int Type
		{
			get { return type; }
			set { type = value; }
		}
	
	}
}
	