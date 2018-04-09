
using System;
namespace TPA.Model
{
	public class RequireMaterialModel : BaseModel
	{
		private string requireMaterialId;
		private string requestId;
		private string materialIdE;
		private string materialName;
		private string manufactureIdE;
		private DateTime? dateAboutE;
		private DateTime? dateAboutF;
		private decimal price;
		private string note;
		private int status;
		private string materialIdF;
		private string manufactureIdF;
		private string supplierId;
		private decimal total;
		private decimal totalBuy;
		private decimal totalReceived;
		private int materitalType;
		private int deliveryTime;
		public string RequireMaterialId
		{
			get { return requireMaterialId; }
			set { requireMaterialId = value; }
		}
	
		public string RequestId
		{
			get { return requestId; }
			set { requestId = value; }
		}
	
		public string MaterialIdE
		{
			get { return materialIdE; }
			set { materialIdE = value; }
		}
	
		public string MaterialName
		{
			get { return materialName; }
			set { materialName = value; }
		}
	
		public string ManufactureIdE
		{
			get { return manufactureIdE; }
			set { manufactureIdE = value; }
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
	
		public string MaterialIdF
		{
			get { return materialIdF; }
			set { materialIdF = value; }
		}
	
		public string ManufactureIdF
		{
			get { return manufactureIdF; }
			set { manufactureIdF = value; }
		}
	
		public string SupplierId
		{
			get { return supplierId; }
			set { supplierId = value; }
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
	
		public int MateritalType
		{
			get { return materitalType; }
			set { materitalType = value; }
		}
	
		public int DeliveryTime
		{
			get { return deliveryTime; }
			set { deliveryTime = value; }
		}
	
	}
}
	