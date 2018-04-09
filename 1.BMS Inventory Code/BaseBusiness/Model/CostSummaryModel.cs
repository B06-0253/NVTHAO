
using System;
namespace BMS.Model
{
	public class CostSummaryModel : BaseModel
	{
		private int iD;
		private long baoGiaID;
		private int costDetailID;
		private int departmentID;
		private decimal totalDK;
		private decimal totalTT;
		public int ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public long BaoGiaID
		{
			get { return baoGiaID; }
			set { baoGiaID = value; }
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
	
		public decimal TotalDK
		{
			get { return totalDK; }
			set { totalDK = value; }
		}
	
		public decimal TotalTT
		{
			get { return totalTT; }
			set { totalTT = value; }
		}
	
	}
}
	