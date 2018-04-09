
using System;
namespace BMS.Model
{
	public class BaoGiaDiffModel : BaseModel
	{
		private int iD;
		private long baoGiaID;
		private int sTT;
		private string name;
		private decimal price;
		private string description;
		public int ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public long BaoGiaID
		{
			get { return baoGiaID; }
			set { baoGiaID = value; }
		}
	
		public int STT
		{
			get { return sTT; }
			set { sTT = value; }
		}
	
		public string Name
		{
			get { return name; }
			set { name = value; }
		}
	
		public decimal Price
		{
			get { return price; }
			set { price = value; }
		}
	
		public string Description
		{
			get { return description; }
			set { description = value; }
		}
	
	}
}
	