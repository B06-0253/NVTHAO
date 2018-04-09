
using System;
namespace TPA.Model
{
	public class ProposalProblemModel : BaseModel
	{
		private long iD;
		private string proposalId;
		private string reason;
		private string solution;
		private string createdBy;
		private DateTime? createdDate;
		private string updatedBy;
		private DateTime? updatedDate;
		private int isCompleted;
		public long ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public string ProposalId
		{
			get { return proposalId; }
			set { proposalId = value; }
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
	
		public int IsCompleted
		{
			get { return isCompleted; }
			set { isCompleted = value; }
		}
	
	}
}
	