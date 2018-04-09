
using System;
namespace TEST.Model
{
	public class SuppliersUserLinkModel : BaseModel
	{
		private long iD;
		private string supplierId;
		private string userId;
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
	
		public string UserId
		{
			get { return userId; }
			set { userId = value; }
		}
	
	}
}
	