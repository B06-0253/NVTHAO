
using System;
namespace BMS.Model
{
	public class CostDetailModel : BaseModel
	{
		private int iD;
		private string code;
		private string name;
		private int type;
		private int isFix;
		private string description;
		private int departmentID;
		private string createdBy;
		private DateTime? createdDate;
		private string updatedBy;
		private DateTime? updatedDate;
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
	
		public string Name
		{
			get { return name; }
			set { name = value; }
		}
	
		public int Type
		{
			get { return type; }
			set { type = value; }
		}
	
		public int IsFix
		{
			get { return isFix; }
			set { isFix = value; }
		}
	
		public string Description
		{
			get { return description; }
			set { description = value; }
		}
	
		public int DepartmentID
		{
			get { return departmentID; }
			set { departmentID = value; }
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
	