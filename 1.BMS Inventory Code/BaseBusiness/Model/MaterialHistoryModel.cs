
using System;
namespace BMS.Model
{
	public class MaterialHistoryModel : BaseModel
	{
		private int iD;
		private int moduleID;
		private int materialID;
		private decimal qty;
		private decimal price;
		private decimal delivery;
		private string valueTT;
		private string valueYC;
        private string nameTS;

        public string NameTS
        {
            get { return nameTS; }
            set { nameTS = value; }
        }
		public int ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public int ModuleID
		{
			get { return moduleID; }
			set { moduleID = value; }
		}
	
		public int MaterialID
		{
			get { return materialID; }
			set { materialID = value; }
		}
	
		public decimal Qty
		{
			get { return qty; }
			set { qty = value; }
		}
	
		public decimal Price
		{
			get { return price; }
			set { price = value; }
		}
	
		public decimal Delivery
		{
			get { return delivery; }
			set { delivery = value; }
		}
	
		public string ValueTT
		{
			get { return valueTT; }
			set { valueTT = value; }
		}
	
		public string ValueYC
		{
			get { return valueYC; }
			set { valueYC = value; }
		}
	
	}
}
	