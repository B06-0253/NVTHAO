
using System;
namespace BMS.Model
{
	public class BaoGiaModel : BaseModel
	{
		private long iD;
		private string code;
		private string projectCode;
		private string projectName;
		private string departmentName;
		private string customerCode;
		private string customerName;
		private string customerCodeF;
		private string customerNameF;
		private int customerPercentType;
		private decimal customerPercent;
		private decimal customerCash;
		private decimal customerTotal;
		private decimal totalTPA;
		private decimal totalReal;
		private decimal totalHD;
		private decimal totalVT;
		private decimal totalPhatSinh;
		private decimal totalSX;
		private decimal totalDkSX;
		private decimal totalTM;
		private decimal totalDkTM;
		private string createdBy;
		private DateTime? createdDate;
		private string updatedBy;
		private DateTime? updatedDate;
		public long ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public string Code
		{
			get { return code; }
			set { code = value; }
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
	
		public int CustomerPercentType
		{
			get { return customerPercentType; }
			set { customerPercentType = value; }
		}
	
		public decimal CustomerPercent
		{
			get { return customerPercent; }
			set { customerPercent = value; }
		}
	
		public decimal CustomerCash
		{
			get { return customerCash; }
			set { customerCash = value; }
		}
	
		public decimal CustomerTotal
		{
			get { return customerTotal; }
			set { customerTotal = value; }
		}
	
		public decimal TotalTPA
		{
			get { return totalTPA; }
			set { totalTPA = value; }
		}
	
		public decimal TotalReal
		{
			get { return totalReal; }
			set { totalReal = value; }
		}
	
		public decimal TotalHD
		{
			get { return totalHD; }
			set { totalHD = value; }
		}
	
		public decimal TotalVT
		{
			get { return totalVT; }
			set { totalVT = value; }
		}
	
		public decimal TotalPhatSinh
		{
			get { return totalPhatSinh; }
			set { totalPhatSinh = value; }
		}
	
		public decimal TotalSX
		{
			get { return totalSX; }
			set { totalSX = value; }
		}
	
		public decimal TotalDkSX
		{
			get { return totalDkSX; }
			set { totalDkSX = value; }
		}
	
		public decimal TotalTM
		{
			get { return totalTM; }
			set { totalTM = value; }
		}
	
		public decimal TotalDkTM
		{
			get { return totalDkTM; }
			set { totalDkTM = value; }
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
	
	}
}
	