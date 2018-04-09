
using System;
namespace TEST.Model
{
	public class OrderInvoiceModel : BaseModel
	{
		private int iD;
		private string orderId;
		private string code;
		private decimal total;
		private DateTime? invoiceDate;
		public int ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public string OrderId
		{
			get { return orderId; }
			set { orderId = value; }
		}
	
		public string Code
		{
			get { return code; }
			set { code = value; }
		}
	
		public decimal Total
		{
			get { return total; }
			set { total = value; }
		}
	
		public DateTime? InvoiceDate
		{
			get { return invoiceDate; }
			set { invoiceDate = value; }
		}
	
	}
}
	