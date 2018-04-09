
using System;
namespace BMS.Model
{
	public class CostGroupModel : BaseModel
	{
		private int iD;
		private string code;
		private string name;
		private string description;
		private decimal percentTrade;
		private decimal percentUser;
		private decimal vAT;
		private decimal profitSX;
		private decimal profitTM;
		private decimal dividedRate;
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
	
		public string Description
		{
			get { return description; }
			set { description = value; }
		}
	
		public decimal PercentTrade
		{
			get { return percentTrade; }
			set { percentTrade = value; }
		}
	
		public decimal PercentUser
		{
			get { return percentUser; }
			set { percentUser = value; }
		}
	
		public decimal VAT
		{
			get { return vAT; }
			set { vAT = value; }
		}
	
		public decimal ProfitSX
		{
			get { return profitSX; }
			set { profitSX = value; }
		}
	
		public decimal ProfitTM
		{
			get { return profitTM; }
			set { profitTM = value; }
		}
	
		public decimal DividedRate
		{
			get { return dividedRate; }
			set { dividedRate = value; }
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
	