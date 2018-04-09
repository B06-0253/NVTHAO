
using System;
namespace BMS.Model
{
	public class SolutionItemModel : BaseModel
	{
		private long iD;
		private long solutionID;
		private string code;
		private string name;
		private string hang;
		private string unit;
		private decimal qty;
		private int qtyError;
		private int qtyKPH;
		private decimal qtyTon;
		private decimal price;
		private decimal totalPrice;
		private int status;
		private int type;
		public long ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public long SolutionID
		{
			get { return solutionID; }
			set { solutionID = value; }
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
	
		public string Hang
		{
			get { return hang; }
			set { hang = value; }
		}
	
		public string Unit
		{
			get { return unit; }
			set { unit = value; }
		}
	
		public decimal Qty
		{
			get { return qty; }
			set { qty = value; }
		}
	
		public int QtyError
		{
			get { return qtyError; }
			set { qtyError = value; }
		}
	
		public int QtyKPH
		{
			get { return qtyKPH; }
			set { qtyKPH = value; }
		}
	
		public decimal QtyTon
		{
			get { return qtyTon; }
			set { qtyTon = value; }
		}
	
		public decimal Price
		{
			get { return price; }
			set { price = value; }
		}
	
		public decimal TotalPrice
		{
			get { return totalPrice; }
			set { totalPrice = value; }
		}
	
		public int Status
		{
			get { return status; }
			set { status = value; }
		}
	
		public int Type
		{
			get { return type; }
			set { type = value; }
		}
	
	}
}
	