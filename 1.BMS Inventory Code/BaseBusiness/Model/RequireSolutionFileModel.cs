
using System;
namespace BMS.Model
{
	public class RequireSolutionFileModel : BaseModel
	{
		private long iD;
		private long requireSolutionID;
		private string name;
		private string extension;
		private decimal length;
		private string description;
		private string path;
		private bool isDeleted;
		private string causeDelete;
		private string createdBy;
		private DateTime? createdDate;
		private string updatedBy;
		private DateTime? updatedDate;
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
	
		public string Name
		{
			get { return name; }
			set { name = value; }
		}
	
		public string Extension
		{
			get { return extension; }
			set { extension = value; }
		}
	
		public decimal Length
		{
			get { return length; }
			set { length = value; }
		}
	
		public string Description
		{
			get { return description; }
			set { description = value; }
		}
	
		public string Path
		{
			get { return path; }
			set { path = value; }
		}
	
		public bool IsDeleted
		{
			get { return isDeleted; }
			set { isDeleted = value; }
		}
	
		public string CauseDelete
		{
			get { return causeDelete; }
			set { causeDelete = value; }
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
	