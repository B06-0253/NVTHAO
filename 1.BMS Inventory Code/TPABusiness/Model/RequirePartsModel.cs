
using System;
namespace TPA.Model
{
	public class RequirePartsModel : BaseModel
	{
		private string requirePartsId;
		private string projectModulePartsId;
		private string requestId;
		private DateTime? dateAboutE;
		private DateTime? dateAboutF;
		private decimal price;
		private string note;
		private int status;
		private string supplierId;
		private string manufactureId;
		private string origin;
		private decimal total;
		private decimal totalBuy;
		private decimal totalReceived;
		private int deliveryTime;
		private decimal totalInventory;
		private decimal totalAvailable;
		private DateTime? dateConfirm;
		private int keepStatus;
		public string RequirePartsId
		{
			get { return requirePartsId; }
			set { requirePartsId = value; }
		}
	
		public string ProjectModulePartsId
		{
			get { return projectModulePartsId; }
			set { projectModulePartsId = value; }
		}
	
		public string RequestId
		{
			get { return requestId; }
			set { requestId = value; }
		}
	
		public DateTime? DateAboutE
		{
			get { return dateAboutE; }
			set { dateAboutE = value; }
		}
	
		public DateTime? DateAboutF
		{
			get { return dateAboutF; }
			set { dateAboutF = value; }
		}
	
		public decimal Price
		{
			get { return price; }
			set { price = value; }
		}
	
		public string Note
		{
			get { return note; }
			set { note = value; }
		}
	
		public int Status
		{
			get { return status; }
			set { status = value; }
		}
	
		public string SupplierId
		{
			get { return supplierId; }
			set { supplierId = value; }
		}
	
		public string ManufactureId
		{
			get { return manufactureId; }
			set { manufactureId = value; }
		}
	
		public string Origin
		{
			get { return origin; }
			set { origin = value; }
		}
	
		public decimal Total
		{
			get { return total; }
			set { total = value; }
		}
	
		public decimal TotalBuy
		{
			get { return totalBuy; }
			set { totalBuy = value; }
		}
	
		public decimal TotalReceived
		{
			get { return totalReceived; }
			set { totalReceived = value; }
		}
	
		public int DeliveryTime
		{
			get { return deliveryTime; }
			set { deliveryTime = value; }
		}
	
		public decimal TotalInventory
		{
			get { return totalInventory; }
			set { totalInventory = value; }
		}
	
		public decimal TotalAvailable
		{
			get { return totalAvailable; }
			set { totalAvailable = value; }
		}
	
		public DateTime? DateConfirm
		{
			get { return dateConfirm; }
			set { dateConfirm = value; }
		}
	
		public int KeepStatus
		{
			get { return keepStatus; }
			set { keepStatus = value; }
		}
	
	}
}
	