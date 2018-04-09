
using System;
namespace TEST.Model
{
	public class C_CostProductGroupLinkNewModel : BaseModel
	{
		private int iD;
		private int c_CostID;
		private int c_ProductGroupID;
		private decimal valuePercentKD2;
		private decimal valuePercentKD1;
		private decimal valuePercentSX;
		private decimal salaryPerDay;
		private decimal personNumber;
		private decimal vtuPercent;
		private int isFix;
		private decimal numberDay;
		public int ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public int C_CostID
		{
			get { return c_CostID; }
			set { c_CostID = value; }
		}
	
		public int C_ProductGroupID
		{
			get { return c_ProductGroupID; }
			set { c_ProductGroupID = value; }
		}
	
		public decimal ValuePercentKD2
		{
			get { return valuePercentKD2; }
			set { valuePercentKD2 = value; }
		}
	
		public decimal ValuePercentKD1
		{
			get { return valuePercentKD1; }
			set { valuePercentKD1 = value; }
		}
	
		public decimal ValuePercentSX
		{
			get { return valuePercentSX; }
			set { valuePercentSX = value; }
		}
	
		public decimal SalaryPerDay
		{
			get { return salaryPerDay; }
			set { salaryPerDay = value; }
		}
	
		public decimal PersonNumber
		{
			get { return personNumber; }
			set { personNumber = value; }
		}
	
		public decimal VtuPercent
		{
			get { return vtuPercent; }
			set { vtuPercent = value; }
		}
	
		public int IsFix
		{
			get { return isFix; }
			set { isFix = value; }
		}
	
		public decimal NumberDay
		{
			get { return numberDay; }
			set { numberDay = value; }
		}
	
	}
}
	