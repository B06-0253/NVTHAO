
using System;
namespace TEST.Model
{
	public class C_QuotationModel : BaseModel
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
		private int departmentId;
		private decimal totalTPA;
		private decimal totalHD;
		private decimal tax;
		private decimal totalReal;
		private decimal totalVAT;
		private decimal totalCustomer;
		private decimal totalNC;
		private decimal totalPB;
		private decimal totalBX;
		private decimal totalProfit;
		private decimal totalVT;
		private decimal deliveryTime;
		private int status;
		private bool isCustomerVAT;
		private decimal customerCash;
		private decimal customerPercent;
		private string createdBy;
		private DateTime? createdDate;
		private string updatedBy;
		private DateTime? updatedDate;
		private bool isApproved;
        private int isVAT;      
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
	
		public int DepartmentId
		{
			get { return departmentId; }
			set { departmentId = value; }
		}
	
		public decimal TotalTPA
		{
			get { return totalTPA; }
			set { totalTPA = value; }
		}
	
		public decimal TotalHD
		{
			get { return totalHD; }
			set { totalHD = value; }
		}
	
		public decimal Tax
		{
			get { return tax; }
			set { tax = value; }
		}
	
		public decimal TotalReal
		{
			get { return totalReal; }
			set { totalReal = value; }
		}
	
		public decimal TotalVAT
		{
			get { return totalVAT; }
			set { totalVAT = value; }
		}
	
		public decimal TotalCustomer
		{
			get { return totalCustomer; }
			set { totalCustomer = value; }
		}
	
		public decimal TotalNC
		{
			get { return totalNC; }
			set { totalNC = value; }
		}
	
		public decimal TotalPB
		{
			get { return totalPB; }
			set { totalPB = value; }
		}
	
		public decimal TotalBX
		{
			get { return totalBX; }
			set { totalBX = value; }
		}
	
		public decimal TotalProfit
		{
			get { return totalProfit; }
			set { totalProfit = value; }
		}
	
		public decimal TotalVT
		{
			get { return totalVT; }
			set { totalVT = value; }
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
	}
}
	