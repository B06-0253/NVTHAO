
using System;
namespace BMS.Model
{
	public class CostDetailDepartmentLinkModel : BaseModel
	{
		private int iD;
		private int costDetailID;
		private int departmentID;
		public int ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public int CostDetailID
		{
			get { return costDetailID; }
			set { costDetailID = value; }
		}
	
		public int DepartmentID
		{
			get { return departmentID; }
			set { departmentID = value; }
		}
	
	}
}
	