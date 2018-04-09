
using System;
namespace BMS.Model
{
	public class SolutionModel : BaseModel
	{
		private long iD;
		private long requireSolutionID;
		private string code;
		private string name;
		private string description;
		private int version;
		private string versionReason;
		private int nguoiPhuTrach;
		private int status;
		private int area;
		private int solutionTechnologyID;
		private string workDescription;
		private decimal totalCost;
		private int stopStatus;
		private string stopReason;
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
	
		public long RequireSolutionID
		{
			get { return requireSolutionID; }
			set { requireSolutionID = value; }
		}
	
		public string Code
		{
			get { return code; }
			set { code = value; }
		}
	
		public string Name
		{
			get { return name; }
			set { name = value; }
		}
	
		public string Description
		{
			get { return description; }
			set { description = value; }
		}
	
		public int Version
		{
			get { return version; }
			set { version = value; }
		}
	
		public string VersionReason
		{
			get { return versionReason; }
			set { versionReason = value; }
		}
	
		public int NguoiPhuTrach
		{
			get { return nguoiPhuTrach; }
			set { nguoiPhuTrach = value; }
		}
	
		public int Status
		{
			get { return status; }
			set { status = value; }
		}
	
		public int Area
		{
			get { return area; }
			set { area = value; }
		}
	
		public int SolutionTechnologyID
		{
			get { return solutionTechnologyID; }
			set { solutionTechnologyID = value; }
		}
	
		public string WorkDescription
		{
			get { return workDescription; }
			set { workDescription = value; }
		}
	
		public decimal TotalCost
		{
			get { return totalCost; }
			set { totalCost = value; }
		}
	
		public int StopStatus
		{
			get { return stopStatus; }
			set { stopStatus = value; }
		}
	
		public string StopReason
		{
			get { return stopReason; }
			set { stopReason = value; }
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
	