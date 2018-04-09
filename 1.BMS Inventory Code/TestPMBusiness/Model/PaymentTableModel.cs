
using System;
namespace TEST.Model
{
	public class PaymentTableModel : BaseModel
	{
		private long iD;
		private string number;
		private decimal totalTM;
		private decimal totalCK;
		private string note;
		private string createdBy;
		private DateTime? createdDate;
		private string updatedBy;
		private DateTime? updatedDate;
		private bool isDeleted;
		public long ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public string Number
		{
			get { return number; }
			set { number = value; }
		}
	
		public decimal TotalTM
		{
			get { return totalTM; }
			set { totalTM = value; }
		}
	
		public decimal TotalCK
		{
			get { return totalCK; }
			set { totalCK = value; }
		}
	
		public string Note
		{
			get { return note; }
			set { note = value; }
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
	
		public bool IsDeleted
		{
			get { return isDeleted; }
			set { isDeleted = value; }
		}
	
	}
}
	