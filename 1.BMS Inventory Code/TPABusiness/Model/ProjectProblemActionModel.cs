
using System;
namespace TPA.Model
{
	public class ProjectProblemActionModel : BaseModel
	{
		private long iD;
		private long projectProblemID;
		private string action;
		private string monitor;
		private DateTime? completedDate;
		private string result;
		private bool isCompleted;
		public long ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public long ProjectProblemID
		{
			get { return projectProblemID; }
			set { projectProblemID = value; }
		}
	
		public string Action
		{
			get { return action; }
			set { action = value; }
		}
	
		public string Monitor
		{
			get { return monitor; }
			set { monitor = value; }
		}
	
		public DateTime? CompletedDate
		{
			get { return completedDate; }
			set { completedDate = value; }
		}
	
		public string Result
		{
			get { return result; }
			set { result = value; }
		}
	
		public bool IsCompleted
		{
			get { return isCompleted; }
			set { isCompleted = value; }
		}
	
	}
}
	