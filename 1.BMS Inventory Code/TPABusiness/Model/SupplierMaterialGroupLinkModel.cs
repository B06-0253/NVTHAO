
using System;
namespace TPA.Model
{
	public class SupplierMaterialGroupLinkModel : BaseModel
	{
		private int iD;
		private int materialGroupID;
		private string supplierId;
		public int ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public int MaterialGroupID
		{
			get { return materialGroupID; }
			set { materialGroupID = value; }
		}
	
		public string SupplierId
		{
			get { return supplierId; }
			set { supplierId = value; }
		}
	
	}
}
	