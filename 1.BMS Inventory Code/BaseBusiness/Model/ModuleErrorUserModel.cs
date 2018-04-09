
using System;
namespace BMS.Model
{
	public class ModuleErrorUserModel : BaseModel
	{
		private int iD;
		private int moduleErrorID;
		private int userID;
		private string createdBy;
		private DateTime createdDate;
		private string updatedBy;
		private DateTime updatedDate;
		public int ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public int ModuleErrorID
		{
			get { return moduleErrorID; }
			set { moduleErrorID = value; }
		}
	
		public int UserID
		{
			get { return userID; }
			set { userID = value; }
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
	