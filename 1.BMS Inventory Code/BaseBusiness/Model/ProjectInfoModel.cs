
using System;
namespace BMS.Model
{
	public class ProjectInfoModel : BaseModel
	{
		private int iD;
		private string projectCode;
		private string projectName;
		private string customerName;
		private string lastCustomerName;
		private string contractCode;
		private string contractName;
		private string curator;
		private string reception;
		private string requirement;
		private string priority;
		private string description;
		private string createdBy;
		private DateTime createdDate;
		private string updatedBy;
		private DateTime updatedDate;
        private int status;

        public int Status
        {
            get { return status; }
            set { status = value; }
        }
		public int ID
		{
			get { return iD; }
			set { iD = value; }
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
	
		public string CustomerName
		{
			get { return customerName; }
			set { customerName = value; }
		}
	
		public string LastCustomerName
		{
			get { return lastCustomerName; }
			set { lastCustomerName = value; }
		}
	
		public string ContractCode
		{
			get { return contractCode; }
			set { contractCode = value; }
		}
	
		public string ContractName
		{
			get { return contractName; }
			set { contractName = value; }
		}
	
		public string Curator
		{
			get { return curator; }
			set { curator = value; }
		}
	
		public string Reception
		{
			get { return reception; }
			set { reception = value; }
		}
	
		public string Requirement
		{
			get { return requirement; }
			set { requirement = value; }
		}
	
		public string Priority
		{
			get { return priority; }
			set { priority = value; }
		}
	
		public string Description
		{
			get { return description; }
			set { description = value; }
		}
	
		public string CreatedBy
		{
			get { return createdBy; }
			set { createdBy = value; }
		}
	
		public DateTime CreatedDate
		{
			get { return createdDate; }
			set { createdDate = value; }
		}
	
		public string UpdatedBy
		{
			get { return updatedBy; }
			set { updatedBy = value; }
		}
	
		public DateTime UpdatedDate
		{
			get { return updatedDate; }
			set { updatedDate = value; }
		}
	
	}
}
	