
using System;
namespace TEST.Model
{
	public class ProposalProblemActionModel : BaseModel
	{
		private long iD;
		private long proposalProblemID;
		private string action;
		private string userId;
		private DateTime? deadline;
		private bool isCompleted;
		public long ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public long ProposalProblemID
		{
			get { return proposalProblemID; }
			set { proposalProblemID = value; }
		}
	
		public string Action
		{
			get { return action; }
			set { action = value; }
		}
	
		public string UserId
		{
			get { return userId; }
			set { userId = value; }
		}
	
		public DateTime? Deadline
		{
			get { return deadline; }
			set { deadline = value; }
		}
	
		public bool IsCompleted
		{
			get { return isCompleted; }
			set { isCompleted = value; }
		}
	
	}
}
	