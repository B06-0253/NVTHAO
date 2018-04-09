
using System;
namespace TEST.Model
{
	public class CasePaidModel : BaseModel
	{
		private long iD;
		private string userId;
		private string code;
		private string name;
		private string content;
		private string target;
		private string note;
		private string createdBy;
		private DateTime? createdDate;
		private string updatedBy;
		private DateTime? updatedDate;
		private bool isLocked;
		private bool isCompleted;
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
	
		public string Content
		{
			get { return content; }
			set { content = value; }
		}
	
		public string Target
		{
			get { return target; }
			set { target = value; }
		}
	
		public string Note
		{
			get { return note; }
			set { note = value; }
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
	
		public bool IsLocked
		{
			get { return isLocked; }
			set { isLocked = value; }
		}
	
		public bool IsCompleted
		{
			get { return isCompleted; }
			set { isCompleted = value; }
		}
	
	}
}
	