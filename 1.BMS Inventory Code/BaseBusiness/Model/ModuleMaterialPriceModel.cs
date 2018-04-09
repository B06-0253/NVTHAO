
using System;
namespace BMS.Model
{
	public class ModuleMaterialPriceModel : BaseModel
	{
		private int iD;
		private string moduleCode;
		private string materialCode;
		private string materialName;
		private int qty;
		private decimal price;
		private decimal totalPrice;
		private string hang;
		private string typeName;
		private int type;
		public int ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public string ModuleCode
		{
			get { return moduleCode; }
			set { moduleCode = value; }
		}
	
		public string MaterialCode
		{
			get { return materialCode; }
			set { materialCode = value; }
		}
	
		public string MaterialName
		{
			get { return materialName; }
			set { materialName = value; }
		}
	
		public int Qty
		{
			get { return qty; }
			set { qty = value; }
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
	
		public string Hang
		{
			get { return hang; }
			set { hang = value; }
		}
	
		public string TypeName
		{
			get { return typeName; }
			set { typeName = value; }
		}
	
		public int Type
		{
			get { return type; }
			set { type = value; }
		}
	
	}
}
	