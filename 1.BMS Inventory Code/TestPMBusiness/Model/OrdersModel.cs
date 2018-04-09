
using System;
namespace TEST.Model
{
	public class OrdersModel : BaseModel
	{
		private string orderId;
		private string orderCode;
		private string content;
		private string note;
		private string supplierId;
		private string number;
		private int orderStatus;
		private string userId;
		private DateTime? dateCreate;
		private decimal currency;
		private DateTime? dateCurrency;
		private DateTime? dateArising;
		private int nhanTinStatus;
		private string orderERPId;
		private string termsPaid;
		private decimal deliveryCost;
		private decimal diffCost;
		private bool isSent;
		private DateTime? requirePaymentDate;
		private DateTime? paymentDate;
		private decimal totalInvoice;
		private decimal vAT;
		private int paymentType;
		private string description;
		private decimal payPercent;
		private decimal totalNCC;
		private int statusTT;
        private bool isTranferAfferVAT;
    
		public string OrderId
		{
			get { return orderId; }
			set { orderId = value; }
		}
	
		public string OrderCode
		{
			get { return orderCode; }
			set { orderCode = value; }
		}
	
		public string Content
		{
			get { return content; }
			set { content = value; }
		}
	
		public string Note
		{
			get { return note; }
			set { note = value; }
		}
	
		public string SupplierId
		{
			get { return supplierId; }
			set { supplierId = value; }
		}
	
		public string Number
		{
			get { return number; }
			set { number = value; }
		}
	
		public int OrderStatus
		{
			get { return orderStatus; }
			set { orderStatus = value; }
		}
	
		public string UserId
		{
			get { return userId; }
			set { userId = value; }
		}
	
		public DateTime? DateCreate
		{
			get { return dateCreate; }
			set { dateCreate = value; }
		}
	
		public decimal Currency
		{
			get { return currency; }
			set { currency = value; }
		}
	
		public DateTime? DateCurrency
		{
			get { return dateCurrency; }
			set { dateCurrency = value; }
		}
	
		public DateTime? DateArising
		{
			get { return dateArising; }
			set { dateArising = value; }
		}
	
		public int NhanTinStatus
		{
			get { return nhanTinStatus; }
			set { nhanTinStatus = value; }
		}
	
		public string OrderERPId
		{
			get { return orderERPId; }
			set { orderERPId = value; }
		}
	
		public string TermsPaid
		{
			get { return termsPaid; }
			set { termsPaid = value; }
		}
	
		public decimal DeliveryCost
		{
			get { return deliveryCost; }
			set { deliveryCost = value; }
		}
	
		public decimal DiffCost
		{
			get { return diffCost; }
			set { diffCost = value; }
		}
	
		public bool IsSent
		{
			get { return isSent; }
			set { isSent = value; }
		}
	
		public DateTime? RequirePaymentDate
		{
			get { return requirePaymentDate; }
			set { requirePaymentDate = value; }
		}
	
		public DateTime? PaymentDate
		{
			get { return paymentDate; }
			set { paymentDate = value; }
		}
	
		public decimal TotalInvoice
		{
			get { return totalInvoice; }
			set { totalInvoice = value; }
		}
	
		public decimal VAT
		{
			get { return vAT; }
			set { vAT = value; }
		}
	
		public int PaymentType
		{
			get { return paymentType; }
			set { paymentType = value; }
		}
	
		public string Description
		{
			get { return description; }
			set { description = value; }
		}
	
		public decimal PayPercent
		{
			get { return payPercent; }
			set { payPercent = value; }
		}
	
		public decimal TotalNCC
		{
			get { return totalNCC; }
			set { totalNCC = value; }
		}
	
		public int StatusTT
		{
			get { return statusTT; }
			set { statusTT = value; }
		}
        public bool IsTranferAfferVAT
        {
            get { return isTranferAfferVAT; }
            set { isTranferAfferVAT = value; }
        }
	}
}
	