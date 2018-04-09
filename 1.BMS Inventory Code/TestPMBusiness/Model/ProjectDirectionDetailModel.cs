
using System;
namespace TEST.Model
{
	public class ProjectDirectionDetailModel : BaseModel
	{
		private long iD;
		private int projectDirectionTypeID;
		private int projectDirectionID;
		private string projectModuleId;
		private string sTT;
		private string partsCode;
		private string partsName;
		private string moduleCode;
		private string projectCode;
		private decimal qty;
		private string unit;
		private string material;
		private string maVatLieu;
		private string thongSo;
		private DateTime? startDateDK;
		private DateTime? endDateDK;
		private DateTime? startDate;
		private DateTime? endDate;
		private decimal makeTime;
		private string userId;
		private string filePath;
		private string fileName;
		private int isNew;
		private int isDeleted;
		private string createdBy;
		private DateTime? createdDate;
		private string note;
		public long ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public int ProjectDirectionTypeID
		{
			get { return projectDirectionTypeID; }
			set { projectDirectionTypeID = value; }
		}
	
		public int ProjectDirectionID
		{
			get { return projectDirectionID; }
			set { projectDirectionID = value; }
		}
	
		public string ProjectModuleId
		{
			get { return projectModuleId; }
			set { projectModuleId = value; }
		}
	
		public string STT
		{
			get { return sTT; }
			set { sTT = value; }
		}
	
		public string PartsCode
		{
			get { return partsCode; }
			set { partsCode = value; }
		}
	
		public string PartsName
		{
			get { return partsName; }
			set { partsName = value; }
		}
	
		public string ModuleCode
		{
			get { return moduleCode; }
			set { moduleCode = value; }
		}
	
		public string ProjectCode
		{
			get { return projectCode; }
			set { projectCode = value; }
		}
	
		public decimal Qty
		{
			get { return qty; }
			set { qty = value; }
		}
	
		public string Unit
		{
			get { return unit; }
			set { unit = value; }
		}
	
		public string Material
		{
			get { return material; }
			set { material = value; }
		}
	
		public string MaVatLieu
		{
			get { return maVatLieu; }
			set { maVatLieu = value; }
		}
	
		public string ThongSo
		{
			get { return thongSo; }
			set { thongSo = value; }
		}
	
		public DateTime? StartDateDK
		{
			get { return startDateDK; }
			set { startDateDK = value; }
		}
	
		public DateTime? EndDateDK
		{
			get { return endDateDK; }
			set { endDateDK = value; }
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
	
		public decimal MakeTime
		{
			get { return makeTime; }
			set { makeTime = value; }
		}
	
		public string UserId
		{
			get { return userId; }
			set { userId = value; }
		}
	
		public string FilePath
		{
			get { return filePath; }
			set { filePath = value; }
		}
	
		public string FileName
		{
			get { return fileName; }
			set { fileName = value; }
		}
	
		public int IsNew
		{
			get { return isNew; }
			set { isNew = value; }
		}
	
		public int IsDeleted
		{
			get { return isDeleted; }
			set { isDeleted = value; }
		}
	
		public string CreatedBy
		{
			get { return createdBy; }
			set { createdBy = value; }
		}
	
		public DateTime? CreatedDate
		{
			get { return createdDate; }
			set { createdDate = value; }
		}
	
		public string Note
		{
			get { return note; }
			set { note = value; }
		}
	
	}
}
	