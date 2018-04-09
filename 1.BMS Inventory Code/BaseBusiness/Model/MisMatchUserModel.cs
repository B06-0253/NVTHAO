
using System;
namespace BMS.Model
{
	public class MisMatchUserModel : BaseModel
	{
		private int iD;
		private int misMatchID;
		private int userID;
		private string createdBy;
		private DateTime? createdDate;
		private string updatedBy;
		private DateTime? updatedDate;
		public int ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public int MisMatchID
		{
			get { return misMatchID; }
			set { misMatchID = value; }
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
	