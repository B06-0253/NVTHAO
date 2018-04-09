
using System;
namespace TPA.Model
{
	public class RequestImportWarehouseModel : BaseModel
	{
		private string importId;
		private string importCode;
		private string departmentId;
		private string userId;
		private DateTime? dateCreate;
		private int status;
		private int productImportType;
		private string importContent;
		private DateTime? dateImport;
		private string importCodeFact;
		private DateTime? dateKCS;
		private DateTime? dateRequestImport;
		private int statusNXT;
		public string ImportId
		{
			get { return importId; }
			set { importId = value; }
		}
	
		public string ImportCode
		{
			get { return importCode; }
			set { importCode = value; }
		}
	
		public string DepartmentId
		{
			get { return departmentId; }
			set { departmentId = value; }
		}
	
		public string UserId
		{
			get { return userId; }
			set { userId = value; }
		}
	
		public DateTime? DateCreate
		{
			get { return dateCreate; }
			set { dateCreate = value; }
		}
	
		public int Status
		{
			get { return status; }
			set { status = value; }
		}
	
		public int ProductImportType
		{
			get { return productImportType; }
			set { productImportType = value; }
		}
	
		public string ImportContent
		{
			get { return importContent; }
			set { importContent = value; }
		}
	
		public DateTime? DateImport
		{
			get { return dateImport; }
			set { dateImport = value; }
		}
	
		public string ImportCodeFact
		{
			get { return importCodeFact; }
			set { importCodeFact = value; }
		}
	
		public DateTime? DateKCS
		{
			get { return dateKCS; }
			set { dateKCS = value; }
		}
	
		public DateTime? DateRequestImport
		{
			get { return dateRequestImport; }
			set { dateRequestImport = value; }
		}
	
		public int StatusNXT
		{
			get { return statusNXT; }
			set { statusNXT = value; }
		}
	
	}
}
	