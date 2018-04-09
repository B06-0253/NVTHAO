
using System;
namespace TEST.Model
{
	public class PartsGeneralProjectLinkModel : BaseModel
	{
		private long iD;
		private string partsId;
		private string projectId;
		private decimal qty;
		private string requireMaterialIdP;
		private string requireMaterialIdK;
		private decimal qtyBuyDA;
		private decimal qtyBuyKho;
		private decimal qtyXuat;
		public long ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public string PartsId
		{
			get { return partsId; }
			set { partsId = value; }
		}
	
		public string ProjectId
		{
			get { return projectId; }
			set { projectId = value; }
		}
	
		public decimal Qty
		{
			get { return qty; }
			set { qty = value; }
		}
	
		public string RequireMaterialIdP
		{
			get { return requireMaterialIdP; }
			set { requireMaterialIdP = value; }
		}
	
		public string RequireMaterialIdK
		{
			get { return requireMaterialIdK; }
			set { requireMaterialIdK = value; }
		}
	
		public decimal QtyBuyDA
		{
			get { return qtyBuyDA; }
			set { qtyBuyDA = value; }
		}
	
		public decimal QtyBuyKho
		{
			get { return qtyBuyKho; }
			set { qtyBuyKho = value; }
		}
	
		public decimal QtyXuat
		{
			get { return qtyXuat; }
			set { qtyXuat = value; }
		}
	
	}
}
	