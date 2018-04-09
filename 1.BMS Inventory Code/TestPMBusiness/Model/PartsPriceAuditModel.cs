
using System;
namespace TEST.Model
{
	public class PartsPriceAuditModel : BaseModel
	{
		private int iD;
		private string partsID;
		private string partsCode;
		private string partsName;
		private string projectID;
		private string projectCode;
		private string moduleID;
		private string moduleCode;
		private decimal price;
		private string rID;
		private int pType;
		private DateTime? updatedDate;
		private DateTime? createdDate;
		private decimal deliveryTime;
		public int ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public string PartsID
		{
			get { return partsID; }
			set { partsID = value; }
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
	
		public string ProjectID
		{
			get { return projectID; }
			set { projectID = value; }
		}
	
		public string ProjectCode
		{
			get { return projectCode; }
			set { projectCode = value; }
		}
	
		public string ModuleID
		{
			get { return moduleID; }
			set { moduleID = value; }
		}
	
		public string ModuleCode
		{
			get { return moduleCode; }
			set { moduleCode = value; }
		}
	
		public decimal Price
		{
			get { return price; }
			set { price = value; }
		}
	
		public string RID
		{
			get { return rID; }
			set { rID = value; }
		}
	
		public int PType
		{
			get { return pType; }
			set { pType = value; }
		}
	
		public DateTime? UpdatedDate
		{
			get { return updatedDate; }
			set { updatedDate = value; }
		}
	
		public DateTime? CreatedDate
		{
			get { return createdDate; }
			set { createdDate = value; }
		}
	
		public decimal DeliveryTime
		{
			get { return deliveryTime; }
			set { deliveryTime = value; }
		}
	
	}
}
	