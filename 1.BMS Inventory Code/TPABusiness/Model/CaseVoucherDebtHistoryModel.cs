
using System;
namespace TPA.Model
{
	public class CaseVoucherDebtHistoryModel : BaseModel
	{
		private int iD;
		private int caseVoucherDebtID;
		private DateTime? dateOut;
		private string reason;
		public int ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public int CaseVoucherDebtID
		{
			get { return caseVoucherDebtID; }
			set { caseVoucherDebtID = value; }
		}
	
		public DateTime? DateOut
		{
			get { return dateOut; }
			set { dateOut = value; }
		}
	
		public string Reason
		{
			get { return reason; }
			set { reason = value; }
		}
	
	}
}
	