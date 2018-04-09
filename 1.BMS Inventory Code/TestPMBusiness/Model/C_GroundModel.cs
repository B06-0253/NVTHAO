
using System;
namespace TEST.Model
{
	public class C_GroundModel : BaseModel
	{
		private int iD;
		private string code;
		private string name;
		private decimal acreage;
		private decimal priceM;
		private decimal priceY;
		private decimal priceD;
		private decimal totalM;
		private decimal totalY;
		private decimal totalD;
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
	
		public decimal Acreage
		{
			get { return acreage; }
			set { acreage = value; }
		}
	
		public decimal PriceM
		{
			get { return priceM; }
			set { priceM = value; }
		}
	
		public decimal PriceY
		{
			get { return priceY; }
			set { priceY = value; }
		}
	
		public decimal PriceD
		{
			get { return priceD; }
			set { priceD = value; }
		}
	
		public decimal TotalM
		{
			get { return totalM; }
			set { totalM = value; }
		}
	
		public decimal TotalY
		{
			get { return totalY; }
			set { totalY = value; }
		}
	
		public decimal TotalD
		{
			get { return totalD; }
			set { totalD = value; }
		}
	
	}
}
	