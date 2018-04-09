
using System;
namespace TEST.Model
{
	public class ProjectProblemModel : BaseModel
	{
		private long iD;
		private string code;
		private string projectId;
		private string projectCode;
		private string sourceCodeId;
		private string moduleCode;
		private string monitor;
		private string content;
		private DateTime? datePhatSinh;
		private string reason;
		private string solution;
		private int status;
		private bool isTonDong;
		private string createdBy;
		private DateTime? createdDate;
		private string updatedBy;
		private DateTime? updatedDate;
		private int isDeleted;
        private bool isTinhTrang;
        
		public long ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public string Code
		{
			get { return code; }
			set { code = value; }
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
	
		public string SourceCodeId
		{
			get { return sourceCodeId; }
			set { sourceCodeId = value; }
		}
	
		public string ModuleCode
		{
			get { return moduleCode; }
			set { moduleCode = value; }
		}
	
		public string Monitor
		{
			get { return monitor; }
			set { monitor = value; }
		}
	
		public string Content
		{
			get { return content; }
			set { content = value; }
		}
	
		public DateTime? DatePhatSinh
		{
			get { return datePhatSinh; }
			set { datePhatSinh = value; }
		}
	
		public string Reason
		{
			get { return reason; }
			set { reason = value; }
		}
	
		public string Solution
		{
			get { return solution; }
			set { solution = value; }
		}
	
		public int Status
		{
			get { return status; }
			set { status = value; }
		}
	
		public bool IsTonDong
		{
			get { return isTonDong; }
			set { isTonDong = value; }
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
	
		public int IsDeleted
		{
			get { return isDeleted; }
			set { isDeleted = value; }
		}

        public bool IsTinhTrang
        {
            get { return isTinhTrang; }
            set { isTinhTrang = value; }
        }

	}
}
	