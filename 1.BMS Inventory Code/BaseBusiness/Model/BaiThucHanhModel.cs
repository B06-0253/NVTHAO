
using System;
namespace BMS.Model
{
	public class BaiThucHanhModel : BaseModel
	{
		private int iD;
		private string code;
		private string name;
		private int groupID;
		private int version;
		private decimal time;
		private decimal realPrice;
		private decimal tradePrice;
		private decimal userPrice;
		private string description;
		private string createdBy;
		private DateTime? createdDate;
		private string updatedBy;
		private DateTime? updatedDate;
		public int ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public string Code
		{
			get { return code; }
			set { code = value; }
		}
	
		public string Name
		{
			get { return name; }
			set { name = value; }
		}
	
		public int GroupID
		{
			get { return groupID; }
			set { groupID = value; }
		}
	
		public int Version
		{
			get { return version; }
			set { version = value; }
		}
	
		public decimal Time
		{
			get { return time; }
			set { time = value; }
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
	
		public string Description
		{
			get { return description; }
			set { description = value; }
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
	