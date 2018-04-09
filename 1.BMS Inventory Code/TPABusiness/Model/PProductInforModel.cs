
using System;
namespace TPA.Model
{
	public class PProductInforModel : BaseModel
	{
		private string pProductInforId;
		private string pPName;
		private string pPCode;
		private decimal price;
		public string PProductInforId
		{
			get { return pProductInforId; }
			set { pProductInforId = value; }
		}
	
		public string PPName
		{
			get { return pPName; }
			set { pPName = value; }
		}
	
		public string PPCode
		{
			get { return pPCode; }
			set { pPCode = value; }
		}
	
		public decimal Price
		{
			get { return price; }
			set { price = value; }
		}
	
	}
}
	