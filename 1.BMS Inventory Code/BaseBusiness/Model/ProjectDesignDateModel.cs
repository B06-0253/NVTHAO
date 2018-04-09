
using System;
namespace BMS.Model
{
	public class ProjectDesignDateModel : BaseModel
	{
		private long iD;
		private string projectCode;
		private DateTime? dateYC;
		private DateTime? dateHT;
		public long ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public string ProjectCode
		{
			get { return projectCode; }
			set { projectCode = value; }
		}
	
		public DateTime? DateYC
		{
			get { return dateYC; }
			set { dateYC = value; }
		}
	
		public DateTime? DateHT
		{
			get { return dateHT; }
			set { dateHT = value; }
		}
	
	}
}
	