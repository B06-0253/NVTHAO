
using System;
namespace TEST.Model
{
	public class ProposalSentStatusModel : BaseModel
	{
		private long iD;
		private string proposalCode;
		private DateTime? dateSent;
		private string userFrom;
		private string userTo;
		public long ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public string ProposalCode
		{
			get { return proposalCode; }
			set { proposalCode = value; }
		}
	
		public DateTime? DateSent
		{
			get { return dateSent; }
			set { dateSent = value; }
		}
	
		public string UserFrom
		{
			get { return userFrom; }
			set { userFrom = value; }
		}
	
		public string UserTo
		{
			get { return userTo; }
			set { userTo = value; }
		}
	
	}
}
	