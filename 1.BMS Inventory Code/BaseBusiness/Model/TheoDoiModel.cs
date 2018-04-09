
using System;
namespace BMS.Model
{
	public class TheoDoiModel : BaseModel
	{
		private int iD;
		private string name;
		private string projectCode;
		private string moduleCode;
		private int userID;
		private DateTime? startDate;
		private DateTime? endDate;
		private int thoiGianDuKien;
		private DateTime? startedDateDK;
		private DateTime? endDateDK;
		private string ghiChu;
		private int status;
		public int ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public string Name
		{
			get { return name; }
			set { name = value; }
		}
	
		public string ProjectCode
		{
			get { return projectCode; }
			set { projectCode = value; }
		}
	
		public string ModuleCode
		{
			get { return moduleCode; }
			set { moduleCode = value; }
		}
	
		public int UserID
		{
			get { return userID; }
			set { userID = value; }
		}
	
		public DateTime? StartDate
		{
			get { return startDate; }
			set { startDate = value; }
		}
	
		public DateTime? EndDate
		{
			get { return endDate; }
			set { endDate = value; }
		}
	
		public int ThoiGianDuKien
		{
			get { return thoiGianDuKien; }
			set { thoiGianDuKien = value; }
		}
	
		public DateTime? StartedDateDK
		{
			get { return startedDateDK; }
			set { startedDateDK = value; }
		}
	
		public DateTime? EndDateDK
		{
			get { return endDateDK; }
			set { endDateDK = value; }
		}
	
		public string GhiChu
		{
			get { return ghiChu; }
			set { ghiChu = value; }
		}
	
		public int Status
		{
			get { return status; }
			set { status = value; }
		}
	
	}
}
	