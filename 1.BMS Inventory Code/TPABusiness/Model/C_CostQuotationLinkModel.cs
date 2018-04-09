
using System;
namespace TPA.Model
{
	public class C_CostQuotationLinkModel : BaseModel
	{
		private int iD;
		private int c_CostID;
		private int c_QuotationID;
		private decimal price;
		private decimal qty;
		private decimal total;
		public int ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public int C_CostID
		{
			get { return c_CostID; }
			set { c_CostID = value; }
		}
	
		public int C_QuotationID
		{
			get { return c_QuotationID; }
			set { c_QuotationID = value; }
		}
	
		public decimal Price
		{
			get { return price; }
			set { price = value; }
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
	
	}
}
	