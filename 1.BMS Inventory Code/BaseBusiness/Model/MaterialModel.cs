
using System;
namespace BMS.Model
{
	public class MaterialModel : BaseModel
	{
		private int iD;
		private string name;
		private string code;
		private int customerID;
		private int materialGroupID;
		private string note;
		private decimal deliveryPeriod;
		private decimal price;
		private string deliveryPeriodTemp;
		private decimal priceTemp;
		private string vL;
		private decimal weight;
		private string properties;
		private string unit;
		private bool stopStatus;
		private int file3D;
		private int fileDatasheet;
		private int fileEplan;
		private string maVatLieu;
		private string thongSo;
		private bool isDeleted;
		private string thoiGianGHCuoi;
		private string imagePath;
		private string createdBy;
		private DateTime? createdDate;
		private string updatedBy;
		private DateTime? updatedDate;
		private string author;
		private bool isUse;
		public int ID
		{
			get { return iD; }
			set { iD = value; }
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
	
		public int CustomerID
		{
			get { return customerID; }
			set { customerID = value; }
		}
	
		public int MaterialGroupID
		{
			get { return materialGroupID; }
			set { materialGroupID = value; }
		}
	
		public string Note
		{
			get { return note; }
			set { note = value; }
		}
	
		public decimal DeliveryPeriod
		{
			get { return deliveryPeriod; }
			set { deliveryPeriod = value; }
		}
	
		public decimal Price
		{
			get { return price; }
			set { price = value; }
		}
	
		public string DeliveryPeriodTemp
		{
			get { return deliveryPeriodTemp; }
			set { deliveryPeriodTemp = value; }
		}
	
		public decimal PriceTemp
		{
			get { return priceTemp; }
			set { priceTemp = value; }
		}
	
		public string VL
		{
			get { return vL; }
			set { vL = value; }
		}
	
		public decimal Weight
		{
			get { return weight; }
			set { weight = value; }
		}
	
		public string Properties
		{
			get { return properties; }
			set { properties = value; }
		}
	
		public string Unit
		{
			get { return unit; }
			set { unit = value; }
		}
	
		public bool StopStatus
		{
			get { return stopStatus; }
			set { stopStatus = value; }
		}
	
		public int File3D
		{
			get { return file3D; }
			set { file3D = value; }
		}
	
		public int FileDatasheet
		{
			get { return fileDatasheet; }
			set { fileDatasheet = value; }
		}
	
		public int FileEplan
		{
			get { return fileEplan; }
			set { fileEplan = value; }
		}
	
		public string MaVatLieu
		{
			get { return maVatLieu; }
			set { maVatLieu = value; }
		}
	
		public string ThongSo
		{
			get { return thongSo; }
			set { thongSo = value; }
		}
	
		public bool IsDeleted
		{
			get { return isDeleted; }
			set { isDeleted = value; }
		}
	
		public string ThoiGianGHCuoi
		{
			get { return thoiGianGHCuoi; }
			set { thoiGianGHCuoi = value; }
		}
	
		public string ImagePath
		{
			get { return imagePath; }
			set { imagePath = value; }
		}
	
		public string CreatedBy
		{
			get { return createdBy; }
			set { createdBy = value; }
		}
	
		public DateTime? CreatedDate
		{
			get { return createdDate; }
			set { createdDate = value; }
		}
	
		public string UpdatedBy
		{
			get { return updatedBy; }
			set { updatedBy = value; }
		}
	
		public DateTime? UpdatedDate
		{
			get { return updatedDate; }
			set { updatedDate = value; }
		}
	
		public string Author
		{
			get { return author; }
			set { author = value; }
		}
	
		public bool IsUse
		{
			get { return isUse; }
			set { isUse = value; }
		}
	
	}
}
	