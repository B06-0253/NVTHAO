
using System;
namespace TEST.Model
{
	public class SuppliersManufacturerLinkModel : BaseModel
	{
		private long iD;
		private string supplierId;
		private string manufacturerId;
		public long ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public string SupplierId
		{
			get { return supplierId; }
			set { supplierId = value; }
		}
	
		public string ManufacturerId
		{
			get { return manufacturerId; }
			set { manufacturerId = value; }
		}
	
	}
}
	