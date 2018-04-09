
using System;
namespace BMS.Model
{
	public class ProductsModel : BaseModel
	{
		private int iD;
		private int productGroupID;
		private int costGroupID;
		private string name;
		private string code;
		private string description;
		private int status;
		private string specifications;
		private decimal time;
		private string priod;
		private decimal price;
		private decimal realPrice;
		private decimal tradePrice;
		private decimal userPrice;
		private decimal vAT;
		private int version;
		private string createdBy;
		private DateTime? createdDate;
		private string updatedBy;
		private DateTime? updatedDate;
		public int ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public int ProductGroupID
		{
			get { return productGroupID; }
			set { productGroupID = value; }
		}
	
		public int CostGroupID
		{
			get { return costGroupID; }
			set { costGroupID = value; }
		}
	
		public string Name
		{
			get { return name; }
			set { name = value; }
		}
	
		public string Code
		{
			get { return code; }
			set { code = value; }
		}
	
		public string Description
		{
			get { return description; }
			set { description = value; }
		}
	
		public int Status
		{
			get { return status; }
			set { status = value; }
		}
	
		public string Specifications
		{
			get { return specifications; }
			set { specifications = value; }
		}
	
		public decimal Time
		{
			get { return time; }
			set { time = value; }
		}
	
		public string Priod
		{
			get { return priod; }
			set { priod = value; }
		}
	
		public decimal Price
		{
			get { return price; }
			set { price = value; }
		}
	
		public decimal RealPrice
		{
			get { return realPrice; }
			set { realPrice = value; }
		}
	
		public decimal TradePrice
		{
			get { return tradePrice; }
			set { tradePrice = value; }
		}
	
		public decimal UserPrice
		{
			get { return userPrice; }
			set { userPrice = value; }
		}
	
		public decimal VAT
		{
			get { return vAT; }
			set { vAT = value; }
		}
	
		public int Version
		{
			get { return version; }
			set { version = value; }
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
	
	}
}
	