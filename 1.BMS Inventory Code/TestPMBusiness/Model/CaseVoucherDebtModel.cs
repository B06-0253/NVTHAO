
using System;
namespace TEST.Model
{
	public class CaseVoucherDebtModel : BaseModel
	{
		private int iD;
		private int payVoucherID;
		private long caseID;
		private DateTime? completedDateDK;
		private DateTime? completedDate;
		private string reason;
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
	
	}
}
	