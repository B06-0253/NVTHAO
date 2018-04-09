
using System;
namespace TPA.Model
{
	public class C_CostModel : BaseModel
	{
		private int iD;
		private string code;
		private string name;
		private int c_CostGroupID;
		private string note;
		private string unit;
		private decimal price;
		private int isWithProject;
		private int costType;
		private decimal percentProfit;
		private int isProfit;
		private int isDirectCost;
		private int isUse;
		private int isDeliveryTime;
		private bool isDeleted;
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
	
		public int C_CostGroupID
		{
			get { return c_CostGroupID; }
			set { c_CostGroupID = value; }
		}
	
		public string Note
		{
			get { return note; }
			set { note = value; }
		}
	
		public string Unit
		{
			get { return unit; }
			set { unit = value; }
		}
	
		public decimal Price
		{
			get { return price; }
			set { price = value; }
		}
	
		public int IsWithProject
		{
			get { return isWithProject; }
			set { isWithProject = value; }
		}
	
		public int CostType
		{
			get { return costType; }
			set { costType = value; }
		}
	
		public decimal PercentProfit
		{
			get { return percentProfit; }
			set { percentProfit = value; }
		}
	
		public int IsProfit
		{
			get { return isProfit; }
			set { isProfit = value; }
		}
	
		public int IsDirectCost
		{
			get { return isDirectCost; }
			set { isDirectCost = value; }
		}
	
		public int IsUse
		{
			get { return isUse; }
			set { isUse = value; }
		}
	
		public int IsDeliveryTime
		{
			get { return isDeliveryTime; }
			set { isDeliveryTime = value; }
		}
	
		public bool IsDeleted
		{
			get { return isDeleted; }
			set { isDeleted = value; }
		}
	
	}
}
	