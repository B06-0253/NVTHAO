
using System;
namespace TPA.Model
{
	public class PartsModel : BaseModel
	{
		private string partsId;
		private string partsCode;
		private string partsName;
		private string unit;
		private string note;
		private string pathImage;
		private string materialsId;
		private DateTime? dateArising;
		private string typeId;
		private int partType;
		private string groupId;
		private int nhanTinStatus;
		private string storeId;
		private bool partsUse;
		private string accountCode;
		private decimal importTax;
		private int calculateTypes;
		private double criterialPercent;
		private decimal price;
		private string hsCode;
		private string description;
		private DateTime? updatedPriceDate;
		public string PartsId
		{
			get { return partsId; }
			set { partsId = value; }
		}
	
		public string PartsCode
		{
			get { return partsCode; }
			set { partsCode = value; }
		}
	
		public string PartsName
		{
			get { return partsName; }
			set { partsName = value; }
		}
	
		public string Unit
		{
			get { return unit; }
			set { unit = value; }
		}
	
		public string Note
		{
			get { return note; }
			set { note = value; }
		}
	
		public string PathImage
		{
			get { return pathImage; }
			set { pathImage = value; }
		}
	
		public string MaterialsId
		{
			get { return materialsId; }
			set { materialsId = value; }
		}
	
		public DateTime? DateArising
		{
			get { return dateArising; }
			set { dateArising = value; }
		}
	
		public string TypeId
		{
			get { return typeId; }
			set { typeId = value; }
		}
	
		public int PartType
		{
			get { return partType; }
			set { partType = value; }
		}
	
		public string GroupId
		{
			get { return groupId; }
			set { groupId = value; }
		}
	
		public int NhanTinStatus
		{
			get { return nhanTinStatus; }
			set { nhanTinStatus = value; }
		}
	
		public string StoreId
		{
			get { return storeId; }
			set { storeId = value; }
		}
	
		public bool PartsUse
		{
			get { return partsUse; }
			set { partsUse = value; }
		}
	
		public string AccountCode
		{
			get { return accountCode; }
			set { accountCode = value; }
		}
	
		public decimal ImportTax
		{
			get { return importTax; }
			set { importTax = value; }
		}
	
		public int CalculateTypes
		{
			get { return calculateTypes; }
			set { calculateTypes = value; }
		}
	
		public double CriterialPercent
		{
			get { return criterialPercent; }
			set { criterialPercent = value; }
		}
	
		public decimal Price
		{
			get { return price; }
			set { price = value; }
		}
	
		public string HsCode
		{
			get { return hsCode; }
			set { hsCode = value; }
		}
	
		public string Description
		{
			get { return description; }
			set { description = value; }
		}
	
		public DateTime? UpdatedPriceDate
		{
			get { return updatedPriceDate; }
			set { updatedPriceDate = value; }
		}
	
	}
}
	