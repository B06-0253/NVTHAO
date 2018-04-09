
using System;
namespace BMS.Model
{
	public class RequireSolutionModel : BaseModel
	{
		private long iD;
		private string code;
		private string name;
		private string description;
		private string customerName;
		private string customerCode;
		private DateTime? requireDate;
		private DateTime? solutionDate;
		private string nguoiDaiDien;
		private string phone;
		private string email;
		private int requirePerson;
		private int nguoiPhuTrach;
		private int priority;
		private decimal cost;
		private string createdBy;
		private DateTime? createdDate;
		private string updatedBy;
		private DateTime? updatedDate;
		private bool isDeleted;
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
	
		public string Name
		{
			get { return name; }
			set { name = value; }
		}
	
		public string Description
		{
			get { return description; }
			set { description = value; }
		}
	
		public string CustomerName
		{
			get { return customerName; }
			set { customerName = value; }
		}
	
		public string CustomerCode
		{
			get { return customerCode; }
			set { customerCode = value; }
		}
	
		public DateTime? RequireDate
		{
			get { return requireDate; }
			set { requireDate = value; }
		}
	
		public DateTime? SolutionDate
		{
			get { return solutionDate; }
			set { solutionDate = value; }
		}
	
		public string NguoiDaiDien
		{
			get { return nguoiDaiDien; }
			set { nguoiDaiDien = value; }
		}
	
		public string Phone
		{
			get { return phone; }
			set { phone = value; }
		}
	
		public string Email
		{
			get { return email; }
			set { email = value; }
		}
	
		public int RequirePerson
		{
			get { return requirePerson; }
			set { requirePerson = value; }
		}
	
		public int NguoiPhuTrach
		{
			get { return nguoiPhuTrach; }
			set { nguoiPhuTrach = value; }
		}
	
		public int Priority
		{
			get { return priority; }
			set { priority = value; }
		}
	
		public decimal Cost
		{
			get { return cost; }
			set { cost = value; }
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
	
		public bool IsDeleted
		{
			get { return isDeleted; }
			set { isDeleted = value; }
		}
	
	}
}
	