
using System;
namespace TEST.Model
{
	public class PayVoucherDebtModel : BaseModel
	{
		private int iD;
		private int payVoucherID;
		private long paymentTableItemID;
		private string createdBy;
		private DateTime? createdDate;
		private string updatedBy;
		private DateTime? updatedDate;
		private DateTime? completedDate;
		private DateTime? completedDateDK;
		public int ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public int PayVoucherID
		{
			get { return payVoucherID; }
			set { payVoucherID = value; }
		}
	
		public long PaymentTableItemID
		{
			get { return paymentTableItemID; }
			set { paymentTableItemID = value; }
		}
	
		public string CreatedBy
		{
			get { return createdBy; }
			set { createdBy = value; }
		}
	
		public DateTime? CreatedDate
		{
			get { return createdDate; }
			set { createdDate = value; }
		}
	
		public string UpdatedBy
		{
			get { return updatedBy; }
			set { updatedBy = value; }
		}
	
		public DateTime? UpdatedDate
		{
			get { return updatedDate; }
			set { updatedDate = value; }
		}
	
		public DateTime? CompletedDate
		{
			get { return completedDate; }
			set { completedDate = value; }
		}
	
		public DateTime? CompletedDateDK
		{
			get { return completedDateDK; }
			set { completedDateDK = value; }
		}
	
	}
}
	