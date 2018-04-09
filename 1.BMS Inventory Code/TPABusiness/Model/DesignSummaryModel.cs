
using System;
namespace TPA.Model
{
	public class DesignSummaryModel : BaseModel
	{
		private long iD;
		private string projectId;
		private string projectCode;
		private string productId;
		private string contractId;
		private string customerName;
		private string userNamePTC;
		private int departmentIDYC;
		private int departmentIDTH;
		private DateTime? dateYC;
		private DateTime? dateHT;
		private string hangMuc;
		private string version;
		private int userID;
		private string productNameTK;
		private string productCodeTK;
		private string productNamePhu;
		private string productCodePhu;
		private string createdBy;
		private DateTime? createdDate;
		private string updatedBy;
		private DateTime? updatedDate;
		private bool isApproved;
		public long ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public string ProjectId
		{
			get { return projectId; }
			set { projectId = value; }
		}
	
		public string ProjectCode
		{
			get { return projectCode; }
			set { projectCode = value; }
		}
	
		public string ProductId
		{
			get { return productId; }
			set { productId = value; }
		}
	
		public string ContractId
		{
			get { return contractId; }
			set { contractId = value; }
		}
	
		public string CustomerName
		{
			get { return customerName; }
			set { customerName = value; }
		}
	
		public string UserNamePTC
		{
			get { return userNamePTC; }
			set { userNamePTC = value; }
		}
	
		public int DepartmentIDYC
		{
			get { return departmentIDYC; }
			set { departmentIDYC = value; }
		}
	
		public int DepartmentIDTH
		{
			get { return departmentIDTH; }
			set { departmentIDTH = value; }
		}
	
		public DateTime? DateYC
		{
			get { return dateYC; }
			set { dateYC = value; }
		}
	
		public DateTime? DateHT
		{
			get { return dateHT; }
			set { dateHT = value; }
		}
	
		public string HangMuc
		{
			get { return hangMuc; }
			set { hangMuc = value; }
		}
	
		public string Version
		{
			get { return version; }
			set { version = value; }
		}
	
		public int UserID
		{
			get { return userID; }
			set { userID = value; }
		}
	
		public string ProductNameTK
		{
			get { return productNameTK; }
			set { productNameTK = value; }
		}
	
		public string ProductCodeTK
		{
			get { return productCodeTK; }
			set { productCodeTK = value; }
		}
	
		public string ProductNamePhu
		{
			get { return productNamePhu; }
			set { productNamePhu = value; }
		}
	
		public string ProductCodePhu
		{
			get { return productCodePhu; }
			set { productCodePhu = value; }
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
	
	}
}
	