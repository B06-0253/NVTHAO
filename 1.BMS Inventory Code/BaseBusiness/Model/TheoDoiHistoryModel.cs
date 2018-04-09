
using System;
namespace BMS.Model
{
	public class TheoDoiHistoryModel : BaseModel
	{
		private int iD;
		private long theoDoiID;
		private DateTime? startDateDK;
		private DateTime? endDateDK;
		private string reason;
		public int ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public long TheoDoiID
		{
			get { return theoDoiID; }
			set { theoDoiID = value; }
		}
	
		public DateTime? StartDateDK
		{
			get { return startDateDK; }
			set { startDateDK = value; }
		}
	
		public DateTime? EndDateDK
		{
			get { return endDateDK; }
			set { endDateDK = value; }
		}
	
		public string Reason
		{
			get { return reason; }
			set { reason = value; }
		}
	
	}
}
	