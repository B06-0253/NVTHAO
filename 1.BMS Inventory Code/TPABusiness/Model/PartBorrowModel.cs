
using System;
namespace TPA.Model
{
	public class PartBorrowModel : BaseModel
	{
		private long iD;
		private string userId;
		private string partsId;
		private string unit;
		private decimal price;
		private decimal qtyBorrow;
		private decimal qtyReturn;
		private decimal qty;
		private decimal total;
		private DateTime? dateBorrow;
		private DateTime? dateReturnExpected;
		private DateTime? dateReturn;
		private bool isReturned;
		private string description;
		public long ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public string UserId
		{
			get { return userId; }
			set { userId = value; }
		}
	
		public string PartsId
		{
			get { return partsId; }
			set { partsId = value; }
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
	
		public decimal QtyBorrow
		{
			get { return qtyBorrow; }
			set { qtyBorrow = value; }
		}
	
		public decimal QtyReturn
		{
			get { return qtyReturn; }
			set { qtyReturn = value; }
		}
	
		public decimal Qty
		{
			get { return qty; }
			set { qty = value; }
		}
	
		public decimal Total
		{
			get { return total; }
			set { total = value; }
		}
	
		public DateTime? DateBorrow
		{
			get { return dateBorrow; }
			set { dateBorrow = value; }
		}
	
		public DateTime? DateReturnExpected
		{
			get { return dateReturnExpected; }
			set { dateReturnExpected = value; }
		}
	
		public DateTime? DateReturn
		{
			get { return dateReturn; }
			set { dateReturn = value; }
		}
	
		public bool IsReturned
		{
			get { return isReturned; }
			set { isReturned = value; }
		}
	
		public string Description
		{
			get { return description; }
			set { description = value; }
		}
	
	}
}
	