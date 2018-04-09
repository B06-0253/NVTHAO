
using System;
namespace TPA.Model
{
	public class C_QuotationDetailModel : BaseModel
	{
		private int iD;
		private int c_QuotationID;
		private int c_ProductGroupID;
		private int parentID;
		private string moduleCode;
		private string moduleName;
		private string moduleCodeHD;
		private string moduleNameHD;
		private decimal vAT;
		private decimal qty;
		private decimal qtyT;
		private decimal priceVT;
		private decimal priceVTSX;
		private decimal priceVTTN;
		private decimal priceVTPS;
		private decimal priceVTLD;
		private decimal priceHD;
		private decimal priceTPA;
		private decimal priceSX;
		private decimal priceReal;
		private decimal priceVAT;
		private decimal totalPB;
		private decimal totalNC;
		private decimal totalProfit;
		private decimal totalCP;
		private string manufacture;
		private string origin;
		public int ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public int C_QuotationID
		{
			get { return c_QuotationID; }
			set { c_QuotationID = value; }
		}
	
		public int C_ProductGroupID
		{
			get { return c_ProductGroupID; }
			set { c_ProductGroupID = value; }
		}
	
		public int ParentID
		{
			get { return parentID; }
			set { parentID = value; }
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
	
		public decimal QtyT
		{
			get { return qtyT; }
			set { qtyT = value; }
		}
	
		public decimal PriceVT
		{
			get { return priceVT; }
			set { priceVT = value; }
		}
	
		public decimal PriceVTSX
		{
			get { return priceVTSX; }
			set { priceVTSX = value; }
		}
	
		public decimal PriceVTTN
		{
			get { return priceVTTN; }
			set { priceVTTN = value; }
		}
	
		public decimal PriceVTPS
		{
			get { return priceVTPS; }
			set { priceVTPS = value; }
		}
	
		public decimal PriceVTLD
		{
			get { return priceVTLD; }
			set { priceVTLD = value; }
		}
	
		public decimal PriceHD
		{
			get { return priceHD; }
			set { priceHD = value; }
		}
	
		public decimal PriceTPA
		{
			get { return priceTPA; }
			set { priceTPA = value; }
		}
	
		public decimal PriceSX
		{
			get { return priceSX; }
			set { priceSX = value; }
		}
	
		public decimal PriceReal
		{
			get { return priceReal; }
			set { priceReal = value; }
		}
	
		public decimal PriceVAT
		{
			get { return priceVAT; }
			set { priceVAT = value; }
		}
	
		public decimal TotalPB
		{
			get { return totalPB; }
			set { totalPB = value; }
		}
	
		public decimal TotalNC
		{
			get { return totalNC; }
			set { totalNC = value; }
		}
	
		public decimal TotalProfit
		{
			get { return totalProfit; }
			set { totalProfit = value; }
		}
	
		public decimal TotalCP
		{
			get { return totalCP; }
			set { totalCP = value; }
		}
	
		public string Manufacture
		{
			get { return manufacture; }
			set { manufacture = value; }
		}
	
		public string Origin
		{
			get { return origin; }
			set { origin = value; }
		}
	
	}
}
	