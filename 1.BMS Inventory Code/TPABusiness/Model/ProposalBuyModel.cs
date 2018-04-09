
using System;
namespace TPA.Model
{
	public class ProposalBuyModel : BaseModel
	{
		private string proposalId;
		private string proposalCode;
		private DateTime? dateCreate;
		private int productType;
		private string userId;
		private int status;
		private int statusConfirm;
		public string ProposalId
		{
			get { return proposalId; }
			set { proposalId = value; }
		}
	
		public string ProposalCode
		{
			get { return proposalCode; }
			set { proposalCode = value; }
		}
	
		public DateTime? DateCreate
		{
			get { return dateCreate; }
			set { dateCreate = value; }
		}
	
		public int ProductType
		{
			get { return productType; }
			set { productType = value; }
		}
	
		public string UserId
		{
			get { return userId; }
			set { userId = value; }
		}
	
		public int Status
		{
			get { return status; }
			set { status = value; }
		}
	
		public int StatusConfirm
		{
			get { return statusConfirm; }
			set { statusConfirm = value; }
		}
	
	}
}
	