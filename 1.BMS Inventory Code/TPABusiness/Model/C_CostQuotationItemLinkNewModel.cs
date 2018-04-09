
using System;
namespace TPA.Model
{
	public class C_CostQuotationItemLinkNewModel : BaseModel
	{
		private int iD;
		private int c_CostID;
		private int c_QuotationDetail_SXID;
		private int c_QuotationDetail_KDID;
		private decimal price;
		private decimal personNumber;
		private decimal numberDay;
		private decimal totalR;
		private int isDirect;
		private string costNCType;
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
	
		public int C_QuotationDetail_SXID
		{
			get { return c_QuotationDetail_SXID; }
			set { c_QuotationDetail_SXID = value; }
		}
	
		public int C_QuotationDetail_KDID
		{
			get { return c_QuotationDetail_KDID; }
			set { c_QuotationDetail_KDID = value; }
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
	
		public string CostNCType
		{
			get { return costNCType; }
			set { costNCType = value; }
		}
	
	}
}
	