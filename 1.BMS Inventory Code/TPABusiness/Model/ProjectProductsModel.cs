
using System;
namespace TPA.Model
{
	public class ProjectProductsModel : BaseModel
	{
		private string pProductId;
		private string projectId;
		private string manageId;
		private string pProductInforId;
		private string projectModuleId;
		private DateTime? dateDeliveryE;
		private DateTime? dateDeliveryF;
		private DateTime? dateDesignE;
		private DateTime? dateDesignF;
		private DateTime? dateMaterialE;
		private DateTime? dateMaterialF;
		private DateTime? dateAssemblyE;
		private DateTime? dateAssemblyF;
		private DateTime? dateTestE;
		private DateTime? dateTestF;
		private string specifications;
		private string manufacturerId;
		private string origin;
		private string note;
		private int status;
		private int statusConfirm;
		private string typeId;
		private string departmentDesignId;
		private string departmentCreateId;
		private int total;
		private int statusCheckDesignInfor;
        private int isYCVT;
        
		public string PProductId
		{
			get { return pProductId; }
			set { pProductId = value; }
		}
	
		public string ProjectId
		{
			get { return projectId; }
			set { projectId = value; }
		}
	
		public string ManageId
		{
			get { return manageId; }
			set { manageId = value; }
		}
	
		public string PProductInforId
		{
			get { return pProductInforId; }
			set { pProductInforId = value; }
		}
	
		public string ProjectModuleId
		{
			get { return projectModuleId; }
			set { projectModuleId = value; }
		}
	
		public DateTime? DateDeliveryE
		{
			get { return dateDeliveryE; }
			set { dateDeliveryE = value; }
		}
	
		public DateTime? DateDeliveryF
		{
			get { return dateDeliveryF; }
			set { dateDeliveryF = value; }
		}
	
		public DateTime? DateDesignE
		{
			get { return dateDesignE; }
			set { dateDesignE = value; }
		}
	
		public DateTime? DateDesignF
		{
			get { return dateDesignF; }
			set { dateDesignF = value; }
		}
	
		public DateTime? DateMaterialE
		{
			get { return dateMaterialE; }
			set { dateMaterialE = value; }
		}
	
		public DateTime? DateMaterialF
		{
			get { return dateMaterialF; }
			set { dateMaterialF = value; }
		}
	
		public DateTime? DateAssemblyE
		{
			get { return dateAssemblyE; }
			set { dateAssemblyE = value; }
		}
	
		public DateTime? DateAssemblyF
		{
			get { return dateAssemblyF; }
			set { dateAssemblyF = value; }
		}
	
		public DateTime? DateTestE
		{
			get { return dateTestE; }
			set { dateTestE = value; }
		}
	
		public DateTime? DateTestF
		{
			get { return dateTestF; }
			set { dateTestF = value; }
		}
	
		public string Specifications
		{
			get { return specifications; }
			set { specifications = value; }
		}
	
		public string ManufacturerId
		{
			get { return manufacturerId; }
			set { manufacturerId = value; }
		}
	
		public string Origin
		{
			get { return origin; }
			set { origin = value; }
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
	
		public int StatusConfirm
		{
			get { return statusConfirm; }
			set { statusConfirm = value; }
		}
	
		public string TypeId
		{
			get { return typeId; }
			set { typeId = value; }
		}
	
		public string DepartmentDesignId
		{
			get { return departmentDesignId; }
			set { departmentDesignId = value; }
		}
	
		public string DepartmentCreateId
		{
			get { return departmentCreateId; }
			set { departmentCreateId = value; }
		}
	
		public int Total
		{
			get { return total; }
			set { total = value; }
		}
	
		public int StatusCheckDesignInfor
		{
			get { return statusCheckDesignInfor; }
			set { statusCheckDesignInfor = value; }
		}

        public int IsYCVT
        {
            get { return isYCVT; }
            set { isYCVT = value; }
        }
	}
}
	