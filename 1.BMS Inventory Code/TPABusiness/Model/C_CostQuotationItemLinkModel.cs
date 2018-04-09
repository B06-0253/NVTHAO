
using System;
namespace TPA.Model
{
	public class C_CostQuotationItemLinkModel : BaseModel
	{
		private int iD;
		private int c_CostID;
		private int c_QuotationDetailID;
		private decimal price;
		private decimal personNumber;
		private decimal numberDay;
		private decimal totalR;
		private int isDirect;
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
	
		public int C_QuotationDetailID
		{
			get { return c_QuotationDetailID; }
			set { c_QuotationDetailID = value; }
		}
	
		public decimal Price
		{
			get { return price; }
			set { price = value; }
		}
	
		public decimal PersonNumber
		{
			get { return personNumber; }
			set { personNumber = value; }
		}
	
		public decimal NumberDay
		{
			get { return numberDay; }
			set { numberDay = value; }
		}
	
		public decimal TotalR
		{
			get { return totalR; }
			set { totalR = value; }
		}
	
		public int IsDirect
		{
			get { return isDirect; }
			set { isDirect = value; }
		}
	
	}
}
	