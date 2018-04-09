
using System;
namespace TPA.Model
{
	public class OrderRequirePaidModel : BaseModel
	{
		private int iD;
		private string orderId;
		private decimal payPercent;
		private DateTime? requirePaymentDate;
		private int status;
		private decimal totalPay;
		private int paymentType;
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
	
		public decimal PayPercent
		{
			get { return payPercent; }
			set { payPercent = value; }
		}
	
		public DateTime? RequirePaymentDate
		{
			get { return requirePaymentDate; }
			set { requirePaymentDate = value; }
		}
	
		public int Status
		{
			get { return status; }
			set { status = value; }
		}
	
		public decimal TotalPay
		{
			get { return totalPay; }
			set { totalPay = value; }
		}
	
		public int PaymentType
		{
			get { return paymentType; }
			set { paymentType = value; }
		}
	
	}
}
	