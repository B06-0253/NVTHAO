
using System;
namespace TEST.Model
{
	public class PartsNormModel : BaseModel
	{
		private long iD;
		private string projectCode;
		private string partsCode;
		private decimal price;
		public long ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public string ProjectCode
		{
			get { return projectCode; }
			set { projectCode = value; }
		}
	
		public string PartsCode
		{
			get { return partsCode; }
			set { partsCode = value; }
		}
	
		public decimal Price
		{
			get { return price; }
			set { price = value; }
		}
	
	}
}
	