
using System;
namespace BMS.Model
{
	public class ModuleErrorModel : BaseModel
	{
		private int iD;
		private int moduleID;
		private string code;
		private string name;
		private int userID;
		private int pLLTQ;
		private int pLLNN;
		private int pLLCP;
		private string huongKhacPhuc;
		private string huongKhacPhucTamThoi;
		private string description;
		private int status;
		private int statusTK;
		private string author;
		private string projectCode;
		private int departmentID;
		private string reason;
		private DateTime? completeTimeTK;
		private DateTime? completeTimeKCS;
		private int departmentKPID;
		private int userFindID;
		private string folderPathError;
		private int isTK;
		private string createMailContent;
		private string receiveMailContent;
		private DateTime? startTimeDK;
		private DateTime? endTimeDK;
		private DateTime? startTimeTT;
		private DateTime? endTimeTT;
		private int confirmTemp;
		private int confirmManager;
		private string createdBy;
		private DateTime? createdDate;
		private string updatedBy;
		private DateTime? updatedDate;
		private string note;
        private string supplierId;
        private string supplierName;

       
        private string supplierCode;

        
        private int isDownloaded;       
		public int ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public int ModuleID
		{
			get { return moduleID; }
			set { moduleID = value; }
		}
	
		public string Code
		{
			get { return code; }
			set { code = value; }
		}
	
		public string Name
		{
			get { return name; }
			set { name = value; }
		}
	
		public int UserID
		{
			get { return userID; }
			set { userID = value; }
		}
	
		public int PLLTQ
		{
			get { return pLLTQ; }
			set { pLLTQ = value; }
		}
	
		public int PLLNN
		{
			get { return pLLNN; }
			set { pLLNN = value; }
		}
	
		public int PLLCP
		{
			get { return pLLCP; }
			set { pLLCP = value; }
		}
	
		public string HuongKhacPhuc
		{
			get { return huongKhacPhuc; }
			set { huongKhacPhuc = value; }
		}
	
		public string HuongKhacPhucTamThoi
		{
			get { return huongKhacPhucTamThoi; }
			set { huongKhacPhucTamThoi = value; }
		}
	
		public string Description
		{
			get { return description; }
			set { description = value; }
		}
	
		public int Status
		{
			get { return status; }
			set { status = value; }
		}
	
		public int StatusTK
		{
			get { return statusTK; }
			set { statusTK = value; }
		}
	
		public string Author
		{
			get { return author; }
			set { author = value; }
		}
	
		public string ProjectCode
		{
			get { return projectCode; }
			set { projectCode = value; }
		}
	
		public int DepartmentID
		{
			get { return departmentID; }
			set { departmentID = value; }
		}
	
		public string Reason
		{
			get { return reason; }
			set { reason = value; }
		}
	
		public DateTime? CompleteTimeTK
		{
			get { return completeTimeTK; }
			set { completeTimeTK = value; }
		}
	
		public DateTime? CompleteTimeKCS
		{
			get { return completeTimeKCS; }
			set { completeTimeKCS = value; }
		}
	
		public int DepartmentKPID
		{
			get { return departmentKPID; }
			set { departmentKPID = value; }
		}
	
		public int UserFindID
		{
			get { return userFindID; }
			set { userFindID = value; }
		}
	
		public string FolderPathError
		{
			get { return folderPathError; }
			set { folderPathError = value; }
		}
	
		public int IsTK
		{
			get { return isTK; }
			set { isTK = value; }
		}
	
		public string CreateMailContent
		{
			get { return createMailContent; }
			set { createMailContent = value; }
		}
	
		public string ReceiveMailContent
		{
			get { return receiveMailContent; }
			set { receiveMailContent = value; }
		}
	
		public DateTime? StartTimeDK
		{
			get { return startTimeDK; }
			set { startTimeDK = value; }
		}
	
		public DateTime? EndTimeDK
		{
			get { return endTimeDK; }
			set { endTimeDK = value; }
		}
	
		public DateTime? StartTimeTT
		{
			get { return startTimeTT; }
			set { startTimeTT = value; }
		}
	
		public DateTime? EndTimeTT
		{
			get { return endTimeTT; }
			set { endTimeTT = value; }
		}
	
		public int ConfirmTemp
		{
			get { return confirmTemp; }
			set { confirmTemp = value; }
		}
	
		public int ConfirmManager
		{
			get { return confirmManager; }
			set { confirmManager = value; }
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
	
		public string UpdatedBy
		{
			get { return updatedBy; }
			set { updatedBy = value; }
		}
	
		public DateTime? UpdatedDate
		{
			get { return updatedDate; }
			set { updatedDate = value; }
		}
	
		public string Note
		{
			get { return note; }
			set { note = value; }
		}
        public int IsDownloaded
        {
            get { return isDownloaded; }
            set { isDownloaded = value; }
        }

        public string SupplierId
        {
            get { return supplierId; }
            set { supplierId = value; }
        }
        public string SupplierCode
        {
            get { return supplierCode; }
            set { supplierCode = value; }
        }
        public string SupplierName
        {
            get { return supplierName; }
            set { supplierName = value; }
        }
	}
}
	