
using System;
namespace TPA.Model
{
	public class CaseVoucherDebtModel : BaseModel
	{
		private int iD;
		private int payVoucherID;
		private long caseID;
		private DateTime? completedDateDK;
		private DateTime? completedDate;
		private string reason;
        private decimal totalDiff;
        
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
	
		public long CaseID
		{
			get { return caseID; }
			set { caseID = value; }
		}
	
		public DateTime? CompletedDateDK
		{
			get { return completedDateDK; }
			set { completedDateDK = value; }
		}
	
		public DateTime? CompletedDate
		{
			get { return completedDate; }
			set { completedDate = value; }
		}
	
		public string Reason
		{
			get { return reason; }
			set { reason = value; }
		}

        public decimal TotalDiff
        {
            get { return totalDiff; }
            set { totalDiff = value; }
        }
	}
}
	