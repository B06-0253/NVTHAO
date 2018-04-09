
using System;
namespace BMS.Model
{
	public class MisMatchModel : BaseModel
	{
		private int iD;
		private string code;
		private string projectCode;
		private string moduleCode;
		private string description;
		private decimal cost;
		private DateTime? completeTime;
		private int confirmTK;
		private int statusTK;
		private int statusKCS;
		private int userFind;
		private string confirmSendMailTK;
		private string confirmSendMailKCS;
		private int confirmTemp;
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
	
		public string ProjectCode
		{
			get { return projectCode; }
			set { projectCode = value; }
		}
	
		public string ModuleCode
		{
			get { return moduleCode; }
			set { moduleCode = value; }
		}
	
		public string Description
		{
			get { return description; }
			set { description = value; }
		}
	
		public decimal Cost
		{
			get { return cost; }
			set { cost = value; }
		}
	
		public DateTime? CompleteTime
		{
			get { return completeTime; }
			set { completeTime = value; }
		}
	
		public int ConfirmTK
		{
			get { return confirmTK; }
			set { confirmTK = value; }
		}
	
		public int StatusTK
		{
			get { return statusTK; }
			set { statusTK = value; }
		}
	
		public int StatusKCS
		{
			get { return statusKCS; }
			set { statusKCS = value; }
		}
	
		public int UserFind
		{
			get { return userFind; }
			set { userFind = value; }
		}
	
		public string ConfirmSendMailTK
		{
			get { return confirmSendMailTK; }
			set { confirmSendMailTK = value; }
		}
	
		public string ConfirmSendMailKCS
		{
			get { return confirmSendMailKCS; }
			set { confirmSendMailKCS = value; }
		}
	
		public int ConfirmTemp
		{
			get { return confirmTemp; }
			set { confirmTemp = value; }
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
	