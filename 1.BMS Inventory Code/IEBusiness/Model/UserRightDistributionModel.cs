
using System;
namespace IE.Model
{
	public class UserRightDistributionModel : BaseModel
	{
		private int iD;
		private int formAndFunctionID;
		private int userID;
		public int ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public int FormAndFunctionID
		{
			get { return formAndFunctionID; }
			set { formAndFunctionID = value; }
		}
	
		public int UserID
		{
			get { return userID; }
			set { userID = value; }
		}
	
	}
}
	