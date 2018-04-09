
using System;
namespace BMS.Model
{
	public class CostSummaryModuleModel : BaseModel
	{
		private int iD;
		private long baoGiaID;
		private int costDetailID;
		private int departmentID;
		private string moduleCode;
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
	
		public string ModuleCode
		{
			get { return moduleCode; }
			set { moduleCode = value; }
		}
	
	}
}
	