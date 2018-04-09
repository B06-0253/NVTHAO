
using System;
namespace BMS.Model
{
	public class BaoGiaItemModel : BaseModel
	{
		private long iD;
		private long baoGiaID;
		private string moduleCode;
		private string moduleName;
		private string moduleCodeHD;
		private string moduleNameHD;
		private string priceType;
		private decimal vAT;
		private decimal qty;
		private decimal priceDT;
		private decimal priceVT;
		private decimal totalVT;
		private decimal priceTPA;
		private decimal totalTPA;
		private decimal priceReal;
		private decimal totalReal;
		private decimal priceHDnoVAT;
		private decimal totalHDnoVAT;
		private decimal priceHD;
		private decimal totalHD;
		private int costGroupID;
		private string productCode;
		private string productName;
		public long ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public long BaoGiaID
		{
			get { return baoGiaID; }
			set { baoGiaID = value; }
		}
	
		public string ModuleCode
		{
			get { return moduleCode; }
			set { moduleCode = value; }
		}
	
		public string ModuleName
		{
			get { return moduleName; }
			set { moduleName = value; }
		}
	
		public string ModuleCodeHD
		{
			get { return moduleCodeHD; }
			set { moduleCodeHD = value; }
		}
	
		public string ModuleNameHD
		{
			get { return moduleNameHD; }
			set { moduleNameHD = value; }
		}
	
		public string PriceType
		{
			get { return priceType; }
			set { priceType = value; }
		}
	
		public decimal VAT
		{
			get { return vAT; }
			set { vAT = value; }
		}
	
		public decimal Qty
		{
			get { return qty; }
			set { qty = value; }
		}
	
		public decimal PriceDT
		{
			get { return priceDT; }
			set { priceDT = value; }
		}
	
		public decimal PriceVT
		{
			get { return priceVT; }
			set { priceVT = value; }
		}
	
		public decimal TotalVT
		{
			get { return totalVT; }
			set { totalVT = value; }
		}
	
		public decimal PriceTPA
		{
			get { return priceTPA; }
			set { priceTPA = value; }
		}
	
		public decimal TotalTPA
		{
			get { return totalTPA; }
			set { totalTPA = value; }
		}
	
		public decimal PriceReal
		{
			get { return priceReal; }
			set { priceReal = value; }
		}
	
		public decimal TotalReal
		{
			get { return totalReal; }
			set { totalReal = value; }
		}
	
		public decimal PriceHDnoVAT
		{
			get { return priceHDnoVAT; }
			set { priceHDnoVAT = value; }
		}
	
		public decimal TotalHDnoVAT
		{
			get { return totalHDnoVAT; }
			set { totalHDnoVAT = value; }
		}
	
		public decimal PriceHD
		{
			get { return priceHD; }
			set { priceHD = value; }
		}
	
		public decimal TotalHD
		{
			get { return totalHD; }
			set { totalHD = value; }
		}
	
		public int CostGroupID
		{
			get { return costGroupID; }
			set { costGroupID = value; }
		}
	
		public string ProductCode
		{
			get { return productCode; }
			set { productCode = value; }
		}
	
		public string ProductName
		{
			get { return productName; }
			set { productName = value; }
		}
	
	}
}
	