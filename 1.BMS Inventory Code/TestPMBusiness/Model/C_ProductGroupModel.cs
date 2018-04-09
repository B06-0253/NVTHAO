
using System;
namespace TEST.Model
{
	public class C_ProductGroupModel : BaseModel
	{
		private int iD;
		private string code;
		private string name;
		private decimal profitPercent;
		private decimal vAT;
		private decimal customerPercent;
		private bool isAfterTax;
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
	
		public decimal ProfitPercent
		{
			get { return profitPercent; }
			set { profitPercent = value; }
		}
	
		public decimal VAT
		{
			get { return vAT; }
			set { vAT = value; }
		}
	
		public decimal CustomerPercent
		{
			get { return customerPercent; }
			set { customerPercent = value; }
		}
	
		public bool IsAfterTax
		{
			get { return isAfterTax; }
			set { isAfterTax = value; }
		}
	
	}
}
	