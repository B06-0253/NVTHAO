
using System;
namespace BMS.Model
{
	public class StuffsModel : BaseModel
	{
		private int iD;
		private string code;
		private string hang;
		private string description;
		private decimal price;
		private bool typeWeight;
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
	
		public string Hang
		{
			get { return hang; }
			set { hang = value; }
		}
	
		public string Description
		{
			get { return description; }
			set { description = value; }
		}
	
		public decimal Price
		{
			get { return price; }
			set { price = value; }
		}
	
		public bool TypeWeight
		{
			get { return typeWeight; }
			set { typeWeight = value; }
		}
	
	}
}
	