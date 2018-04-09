
using System;
namespace TEST.Model
{
	public class C_Quotation_KDModel : BaseModel
	{
		private int iD;
		private string code;
		private string pOnumber;
		private string projectCode;
		private string projectName;
		private string departmentName;
		private string customerCode;
		private string customerName;
		private string customerCodeF;
		private string customerNameF;
		private string departmentId;
		private decimal totalDP_KD;
		private decimal totalDP_SX;
		private decimal totalVC_KD;
		private decimal totalBX_KD;
		private decimal totalVCBX;
		private decimal totalCPVCHB_C13;
		private decimal totalBXHB_C52;
		private decimal deliveryTime;
		private int status;
		private bool isCustomerVAT;
		private decimal customerCash;
		private decimal customerPercent;
		private bool isApproved;
		private int isVAT;
		private string createdBy;
		private DateTime? createdDate;
		private string updatedBy;
		private DateTime? updatedDate;
        private int statusNC;
		public int ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public string Code
		{
			get { return code; }
			set { code = value; }
		}
	
		public string POnumber
		{
			get { return pOnumber; }
			set { pOnumber = value; }
		}
	
		public string ProjectCode
		{
			get { return projectCode; }
			set { projectCode = value; }
		}
	
		public string ProjectName
		{
			get { return projectName; }
			set { projectName = value; }
		}
	
		public string DepartmentName
		{
			get { return departmentName; }
			set { departmentName = value; }
		}
	
		public string CustomerCode
		{
			get { return customerCode; }
			set { customerCode = value; }
		}
	
		public string CustomerName
		{
			get { return customerName; }
			set { customerName = value; }
		}
	
		public string CustomerCodeF
		{
			get { return customerCodeF; }
			set { customerCodeF = value; }
		}
	
		public string CustomerNameF
		{
			get { return customerNameF; }
			set { customerNameF = value; }
		}
	
		public string DepartmentId
		{
			get { return departmentId; }
			set { departmentId = value; }
		}
	
		public decimal TotalDP_KD
		{
			get { return totalDP_KD; }
			set { totalDP_KD = value; }
		}
	
		public decimal TotalDP_SX
		{
			get { return totalDP_SX; }
			set { totalDP_SX = value; }
		}
	
		public decimal TotalVC_KD
		{
			get { return totalVC_KD; }
			set { totalVC_KD = value; }
		}
	
		public decimal TotalBX_KD
		{
			get { return totalBX_KD; }
			set { totalBX_KD = value; }
		}
	
		public decimal TotalVCBX
		{
			get { return totalVCBX; }
			set { totalVCBX = value; }
		}
	
		public decimal TotalCPVCHB_C13
		{
			get { return totalCPVCHB_C13; }
			set { totalCPVCHB_C13 = value; }
		}
	
		public decimal TotalBXHB_C52
		{
			get { return totalBXHB_C52; }
			set { totalBXHB_C52 = value; }
		}
	
		public decimal DeliveryTime
		{
			get { return deliveryTime; }
			set { deliveryTime = value; }
		}
	
		public int Status
		{
			get { return status; }
			set { status = value; }
		}
	
		public bool IsCustomerVAT
		{
			get { return isCustomerVAT; }
			set { isCustomerVAT = value; }
		}
	
		public decimal CustomerCash
		{
			get { return customerCash; }
			set { customerCash = value; }
		}
	
		public decimal CustomerPercent
		{
			get { return customerPercent; }
			set { customerPercent = value; }
		}
	
		public bool IsApproved
		{
			get { return isApproved; }
			set { isApproved = value; }
		}
	
		public int IsVAT
		{
			get { return isVAT; }
			set { isVAT = value; }
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
        public int StatusNC
        {
            get { return statusNC; }
            set { statusNC = value; }
        }
	}
}
	