
using System;
namespace BMS.Model
{
	public class ModuleVersionModel : BaseModel
	{
		private int iD;
		private string projectCode;
		private string moduleCode;
		private string moduleErrorCode;
		private string misMatchCode;
		private string reason;
		private string description;
		private int version;
		private string path;
		private string createdBy;
		private DateTime? createdDate;
		private string updatedBy;
		private DateTime? updatedDate;
		public int ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public string ProjectCode
		{
			get { return projectCode; }
			set { projectCode = value; }
		}
	
		public string ModuleCode
		{
			get { return moduleCode; }
			set { moduleCode = value; }
		}
	
		public string ModuleErrorCode
		{
			get { return moduleErrorCode; }
			set { moduleErrorCode = value; }
		}
	
		public string MisMatchCode
		{
			get { return misMatchCode; }
			set { misMatchCode = value; }
		}
	
		public string Reason
		{
			get { return reason; }
			set { reason = value; }
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
	
		public string Path
		{
			get { return path; }
			set { path = value; }
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
	