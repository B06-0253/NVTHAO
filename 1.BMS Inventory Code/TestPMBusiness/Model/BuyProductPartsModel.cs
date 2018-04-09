
using System;
namespace TEST.Model
{
	public class BuyProductPartsModel : BaseModel
	{
		private string buyProductMaterialsId;
		private string proposalId;
		private string productPartId;
		private int status;
		private int orderStatus;
		public string BuyProductMaterialsId
		{
			get { return buyProductMaterialsId; }
			set { buyProductMaterialsId = value; }
		}
	
		public string ProposalId
		{
			get { return proposalId; }
			set { proposalId = value; }
		}
	
		public string ProductPartId
		{
			get { return productPartId; }
			set { productPartId = value; }
		}
	
		public int Status
		{
			get { return status; }
			set { status = value; }
		}
	
		public int OrderStatus
		{
			get { return orderStatus; }
			set { orderStatus = value; }
		}
	
	}
}
	