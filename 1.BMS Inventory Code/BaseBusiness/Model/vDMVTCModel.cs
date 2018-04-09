
using System;
namespace BMS.Model
{
	public class vDMVTCModel : BaseModel
	{
		private int iD;
		private int moduleID;
		private int materialID;
		private decimal qty;
		private decimal price;
		private decimal delivery;
		private string valueYC;
		private string name;
		private string code;
		private string maHang;
		private DateTime thoiGianGHCuoi;
		private string valueTT;
		private string productCode;
		private string productName;
		private string nameTS;
		private string unit;
		private string hang;
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
	
		public string ValueYC
		{
			get { return valueYC; }
			set { valueYC = value; }
		}
	
		public string Name
		{
			get { return name; }
			set { name = value; }
		}
	
		public string Code
		{
			get { return code; }
			set { code = value; }
		}
	
		public string MaHang
		{
			get { return maHang; }
			set { maHang = value; }
		}
	
		public DateTime ThoiGianGHCuoi
		{
			get { return thoiGianGHCuoi; }
			set { thoiGianGHCuoi = value; }
		}
	
		public string ValueTT
		{
			get { return valueTT; }
			set { valueTT = value; }
		}
	
		public string ProductCode
		{
			get { return productCode; }
			set { productCode = value; }
		}
	
		public string ProductName
		{
			get { return productName; }
			set { productName = value; }
		}
	
		public string NameTS
		{
			get { return nameTS; }
			set { nameTS = value; }
		}
	
		public string Unit
		{
			get { return unit; }
			set { unit = value; }
		}
	
		public string Hang
		{
			get { return hang; }
			set { hang = value; }
		}
	
	}
}
	