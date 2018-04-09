
using System;
namespace TPA.Model
{
	public class PaymentTableItemModel : BaseModel
	{
		private long iD;
		private long paymentTableID;
		private string code;
		private string name;
		private string content;
		private string target;
		private bool isCash;
		private decimal percentPay;
		private decimal total;
		private decimal totalTH;
		private decimal deliveryCost;
		private decimal diffCost;
		private decimal totalCash;
		private decimal totalCK;
		private string contentCheck;
		private string note;
		private string userId;
		private bool isPaid;
		private bool isApproved;
		private int costID;
		private int companyID;
		private string projectId;
		private string departmentId;
		private int countProject;
		private decimal vAT;
		private int contractStatus;
		private int invoiceStatus;
		private bool isPO;
		private bool isCongNo;
		private bool isCuongVe;
		private bool isTTGH;
		private bool isGDD;
		private bool isVV_DA_NCC;
		private int orderRequirePaidID;
		public long ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public long PaymentTableID
		{
			get { return paymentTableID; }
			set { paymentTableID = value; }
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
	
		public string Content
		{
			get { return content; }
			set { content = value; }
		}
	
		public string Target
		{
			get { return target; }
			set { target = value; }
		}
	
		public bool IsCash
		{
			get { return isCash; }
			set { isCash = value; }
		}
	
		public decimal PercentPay
		{
			get { return percentPay; }
			set { percentPay = value; }
		}
	
		public decimal Total
		{
			get { return total; }
			set { total = value; }
		}
	
		public decimal TotalTH
		{
			get { return totalTH; }
			set { totalTH = value; }
		}
	
		public decimal DeliveryCost
		{
			get { return deliveryCost; }
			set { deliveryCost = value; }
		}
	
		public decimal DiffCost
		{
			get { return diffCost; }
			set { diffCost = value; }
		}
	
		public decimal TotalCash
		{
			get { return totalCash; }
			set { totalCash = value; }
		}
	
		public decimal TotalCK
		{
			get { return totalCK; }
			set { totalCK = value; }
		}
	
		public string ContentCheck
		{
			get { return contentCheck; }
			set { contentCheck = value; }
		}
	
		public string Note
		{
			get { return note; }
			set { note = value; }
		}
	
		public string UserId
		{
			get { return userId; }
			set { userId = value; }
		}
	
		public bool IsPaid
		{
			get { return isPaid; }
			set { isPaid = value; }
		}
	
		public bool IsApproved
		{
			get { return isApproved; }
			set { isApproved = value; }
		}
	
		public int CostID
		{
			get { return costID; }
			set { costID = value; }
		}
	
		public int CompanyID
		{
			get { return companyID; }
			set { companyID = value; }
		}
	
		public string ProjectId
		{
			get { return projectId; }
			set { projectId = value; }
		}
	
		public string DepartmentId
		{
			get { return departmentId; }
			set { departmentId = value; }
		}
	
		public int CountProject
		{
			get { return countProject; }
			set { countProject = value; }
		}
	
		public decimal VAT
		{
			get { return vAT; }
			set { vAT = value; }
		}
	
		public int ContractStatus
		{
			get { return contractStatus; }
			set { contractStatus = value; }
		}
	
		public int InvoiceStatus
		{
			get { return invoiceStatus; }
			set { invoiceStatus = value; }
		}
	
		public bool IsPO
		{
			get { return isPO; }
			set { isPO = value; }
		}
	
		public bool IsCongNo
		{
			get { return isCongNo; }
			set { isCongNo = value; }
		}
	
		public bool IsCuongVe
		{
			get { return isCuongVe; }
			set { isCuongVe = value; }
		}
	
		public bool IsTTGH
		{
			get { return isTTGH; }
			set { isTTGH = value; }
		}
	
		public bool IsGDD
		{
			get { return isGDD; }
			set { isGDD = value; }
		}
	
		public bool IsVV_DA_NCC
		{
			get { return isVV_DA_NCC; }
			set { isVV_DA_NCC = value; }
		}
	
		public int OrderRequirePaidID
		{
			get { return orderRequirePaidID; }
			set { orderRequirePaidID = value; }
		}
	
	}
}
	