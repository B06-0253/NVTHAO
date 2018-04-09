
using System;
namespace TEST.Model
{
	public class WorkingDiariesModel : BaseModel
	{
		private long iD;
		private string userId;
		private string userName;
		private string userCode;
		private string departmentId;
		private string projectId;
		private string projectCode;
		private string projectName;
		private string moduleCode;
		private string moduleName;
		private string workingContent;
		private DateTime? workingDate;
		private DateTime? startTime;
		private DateTime? endTime;
		private decimal workTime;
		private int status;
		private string note;
		private bool isApproved;
		private bool isNghiTrua;
        private bool isAnToi;
		private decimal workPercent;
		private string createdBy;
		private DateTime? createdDate;
		private string updatedBy;
		private DateTime? updatedDate;
		public long ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public string UserId
		{
			get { return userId; }
			set { userId = value; }
		}
	
		public string UserName
		{
			get { return userName; }
			set { userName = value; }
		}
	
		public string UserCode
		{
			get { return userCode; }
			set { userCode = value; }
		}
	
		public string DepartmentId
		{
			get { return departmentId; }
			set { departmentId = value; }
		}
	
		public string ProjectId
		{
			get { return projectId; }
			set { projectId = value; }
		}
	
		public string ProjectCode
		{
			get { return projectCode; }
			set { projectCode = value; }
		}
	
		public string ProjectName
		{
			get { return projectName; }
			set { projectName = value; }
		}
	
		public string ModuleCode
		{
			get { return moduleCode; }
			set { moduleCode = value; }
		}
	
		public string ModuleName
		{
			get { return moduleName; }
			set { moduleName = value; }
		}
	
		public string WorkingContent
		{
			get { return workingContent; }
			set { workingContent = value; }
		}
	
		public DateTime? WorkingDate
		{
			get { return workingDate; }
			set { workingDate = value; }
		}
	
		public DateTime? StartTime
		{
			get { return startTime; }
			set { startTime = value; }
		}
	
		public DateTime? EndTime
		{
			get { return endTime; }
			set { endTime = value; }
		}
	
		public decimal WorkTime
		{
			get { return workTime; }
			set { workTime = value; }
		}
	
		public int Status
		{
			get { return status; }
			set { status = value; }
		}
	
		public string Note
		{
			get { return note; }
			set { note = value; }
		}
	
		public bool IsApproved
		{
			get { return isApproved; }
			set { isApproved = value; }
		}
	
		public bool IsNghiTrua
		{
			get { return isNghiTrua; }
			set { isNghiTrua = value; }
		}

        public bool IsAnToi
        {
            get { return isAnToi; }
            set { isAnToi = value; }
        }

		public decimal WorkPercent
		{
			get { return workPercent; }
			set { workPercent = value; }
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
	
	}
}
	