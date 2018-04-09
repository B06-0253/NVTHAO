
using System;
namespace TPA.Model
{
	public class ProductPartsImportModel : BaseModel
	{
		private string productPartsImportId;
		private string importId;
		private string buyProductMaterialsId;
		private decimal total;
		private decimal totalOK;
		private decimal totalNG;
		private string note;
		private int status;
		private string userId;
		private string deliveryOrderCodeFact;
        private decimal totalKCS;
        private int countError;
        private int levelError;        
        
		public string ProductPartsImportId
		{
			get { return productPartsImportId; }
			set { productPartsImportId = value; }
		}
	
		public string ImportId
		{
			get { return importId; }
			set { importId = value; }
		}
	
		public string BuyProductMaterialsId
		{
			get { return buyProductMaterialsId; }
			set { buyProductMaterialsId = value; }
		}
	
		public decimal Total
		{
			get { return total; }
			set { total = value; }
		}
	
		public decimal TotalOK
		{
			get { return totalOK; }
			set { totalOK = value; }
		}
	
		public decimal TotalNG
		{
			get { return totalNG; }
			set { totalNG = value; }
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
	
		public string UserId
		{
			get { return userId; }
			set { userId = value; }
		}
	
		public string DeliveryOrderCodeFact
		{
			get { return deliveryOrderCodeFact; }
			set { deliveryOrderCodeFact = value; }
		}

        public decimal TotalKCS
        {
            get { return totalKCS; }
            set { totalKCS = value; }
        }

        public int LevelError
        {
            get { return levelError; }
            set { levelError = value; }
        }
        public int CountError
        {
            get { return countError; }
            set { countError = value; }
        }

    }
}
	