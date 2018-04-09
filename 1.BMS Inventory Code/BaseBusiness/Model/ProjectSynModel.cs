
using System;
namespace BMS.Model
{
	public class ProjectSynModel : BaseModel
	{
		private string projectId;
		private string customerId;
		private string projectName;
		private string projectCode;
		private int timeMake;
		private DateTime dateFinishE;
		private DateTime dateFinishF;
		private string note;
		private int status;
		private int projectType;
		private DateTime dateCreate;
		private int statusDisable;
		private string userId;
		private DateTime dateSingingContract;
		private int iD;
		private string tenKhachHangDau;
		private string tenKhachHangCuoi;
		public string ProjectId
		{
			get { return projectId; }
			set { projectId = value; }
		}
	
		public string CustomerId
		{
			get { return customerId; }
			set { customerId = value; }
		}
	
		public string ProjectName
		{
			get { return projectName; }
			set { projectName = value; }
		}
	
		public string ProjectCode
		{
			get { return projectCode; }
			set { projectCode = value; }
		}
	
		public int TimeMake
		{
			get { return timeMake; }
			set { timeMake = value; }
		}
	
		public DateTime DateFinishE
		{
			get { return dateFinishE; }
			set { dateFinishE = value; }
		}
	
		public DateTime DateFinishF
		{
			get { return dateFinishF; }
			set { dateFinishF = value; }
		}
	
		public string Note
		{
			get { return note; }
			set { note = value; }
		}
	
		public int Status
		{
			get { return status; }
			set { status = value; }
		}
	
		public int ProjectType
		{
			get { return projectType; }
			set { projectType = value; }
		}
	
		public DateTime DateCreate
		{
			get { return dateCreate; }
			set { dateCreate = value; }
		}
	
		public int StatusDisable
		{
			get { return statusDisable; }
			set { statusDisable = value; }
		}
	
		public string UserId
		{
			get { return userId; }
			set { userId = value; }
		}
	
		public DateTime DateSingingContract
		{
			get { return dateSingingContract; }
			set { dateSingingContract = value; }
		}
	
		public int ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public string TenKhachHangDau
		{
			get { return tenKhachHangDau; }
			set { tenKhachHangDau = value; }
		}
	
		public string TenKhachHangCuoi
		{
			get { return tenKhachHangCuoi; }
			set { tenKhachHangCuoi = value; }
		}
	
	}
}
	