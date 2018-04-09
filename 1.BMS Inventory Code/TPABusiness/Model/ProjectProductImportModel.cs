
using System;
namespace TPA.Model
{
	public class ProjectProductImportModel : BaseModel
	{
		private string projectProductImportId;
		private string pProductId;
		private int total;
		private string note;
		private string importId;
		private string manageId;
		private int totalOK;
		private int totalNG;
		private string userId;
        private int totalKCS;

		public string ProjectProductImportId
		{
			get { return projectProductImportId; }
			set { projectProductImportId = value; }
		}
	
		public string PProductId
		{
			get { return pProductId; }
			set { pProductId = value; }
		}
	
		public int Total
		{
			get { return total; }
			set { total = value; }
		}
	
		public string Note
		{
			get { return note; }
			set { note = value; }
		}
	
		public string ImportId
		{
			get { return importId; }
			set { importId = value; }
		}
	
		public string ManageId
		{
			get { return manageId; }
			set { manageId = value; }
		}
	
		public int TotalOK
		{
			get { return totalOK; }
			set { totalOK = value; }
		}
	
		public int TotalNG
		{
			get { return totalNG; }
			set { totalNG = value; }
		}
	
		public string UserId
		{
			get { return userId; }
			set { userId = value; }
		}

        public int TotalKCS
        {
            get { return totalKCS; }
            set { totalKCS = value; }
        }
	
	}
}
	