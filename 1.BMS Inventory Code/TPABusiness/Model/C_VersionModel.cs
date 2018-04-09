
using System;
namespace TPA.Model
{
	public class C_VersionModel : BaseModel
	{
		private int iD;
		private DateTime? startDate;
		private DateTime? endDate;
		private string note;
		public int ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public DateTime? StartDate
		{
			get { return startDate; }
			set { startDate = value; }
		}
	
		public DateTime? EndDate
		{
			get { return endDate; }
			set { endDate = value; }
		}
	
		public string Note
		{
			get { return note; }
			set { note = value; }
		}
	
	}
}
	