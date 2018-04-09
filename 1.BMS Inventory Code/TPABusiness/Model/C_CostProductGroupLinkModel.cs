
using System;
namespace TPA.Model
{
	public class C_CostProductGroupLinkModel : BaseModel
	{
		private int iD;
		private int c_CostID;
		private int c_ProductGroupID;
		private decimal valuePercentKD;
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
	
		public decimal ValuePercentKD
		{
			get { return valuePercentKD; }
			set { valuePercentKD = value; }
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
	