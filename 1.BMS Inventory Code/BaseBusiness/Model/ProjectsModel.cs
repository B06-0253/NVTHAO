
using System;
namespace BMS.Model
{
	public class ProjectsModel : BaseModel
	{
		private int iD;
		private string name;
		private string code;
		private decimal totalTime;
        private decimal estimatedTime;
        private decimal timeTotalDesign;
		private DateTime startDate;
		private DateTime endDate;
		private string createdBy;
		private DateTime createdDate;
		private string updatedBy;
		private DateTime updatedDate;
		private int status;
		public int ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public string Name
		{
			get { return name; }
			set { name = value; }
		}
	
		public string Code
		{
			get { return code; }
			set { code = value; }
		}
	
		public decimal TotalTime
		{
			get { return totalTime; }
			set { totalTime = value; }
		}

        public decimal EstimatedTime
		{
			get { return estimatedTime; }
			set { estimatedTime = value; }
		}

        public decimal TimeTotalDesign
		{
			get { return timeTotalDesign; }
			set { timeTotalDesign = value; }
		}
	
		public DateTime StartDate
		{
			get { return startDate; }
			set { startDate = value; }
		}
	
		public DateTime EndDate
		{
			get { return endDate; }
			set { endDate = value; }
		}
	
		public string CreatedBy
		{
			get { return createdBy; }
			set { createdBy = value; }
		}
	
		public DateTime CreatedDate
		{
			get { return createdDate; }
			set { createdDate = value; }
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
	
		public int Status
		{
			get { return status; }
			set { status = value; }
		}
	
	}
}
	