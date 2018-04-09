
using System;
namespace BMS.Model
{
	public class ModuleTemHistoryModel : BaseModel
	{
		private int iD;
		private int moduleTemID;
		private int lastTimeChange;
		private DateTime lastDateChange;
		private string updatedBy;
		private DateTime updatedDate;
		private string reason;
		private string code;
		public int ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public int ModuleTemID
		{
			get { return moduleTemID; }
			set { moduleTemID = value; }
		}
	
		public int LastTimeChange
		{
			get { return lastTimeChange; }
			set { lastTimeChange = value; }
		}
	
		public DateTime LastDateChange
		{
			get { return lastDateChange; }
			set { lastDateChange = value; }
		}
	
		public string UpdatedBy
		{
			get { return updatedBy; }
			set { updatedBy = value; }
		}
	
		public DateTime UpdatedDate
		{
			get { return updatedDate; }
			set { updatedDate = value; }
		}
	
		public string Reason
		{
			get { return reason; }
			set { reason = value; }
		}
	
		public string Code
		{
			get { return code; }
			set { code = value; }
		}
	
	}
}
	