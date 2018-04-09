
using System;
namespace BMS.Model
{
	public class MaterialGroupCustomerLinkModel : BaseModel
	{
		private int iD;
		private int materialGroupID;
		private int customerID;
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
	
		public int CustomerID
		{
			get { return customerID; }
			set { customerID = value; }
		}
	
	}
}
	