
using System;
namespace TEST.Model
{
	public class PartAccessoriesModel : BaseModel
	{
		private int iD;
		private string code;
		private string name;
		private int type;
		private string unit;
		private string hang;
		private decimal price;
		private decimal qtyMin;
		private decimal qtyDM;
		private decimal qty;
		private decimal total;
		private decimal projectPercent;
		private int isProject;
		public int ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public string Code
		{
			get { return code; }
			set { code = value; }
		}
	
		public string Name
		{
			get { return name; }
			set { name = value; }
		}
	
		public int Type
		{
			get { return type; }
			set { type = value; }
		}
	
		public string Unit
		{
			get { return unit; }
			set { unit = value; }
		}
	
		public string Hang
		{
			get { return hang; }
			set { hang = value; }
		}
	
		public decimal Price
		{
			get { return price; }
			set { price = value; }
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
	
	}
}
	