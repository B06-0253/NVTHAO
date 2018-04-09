
using System;
namespace TPA.Model
{
	public class ProjectProblemActionUserLinkModel : BaseModel
	{
		private long iD;
		private long projectProblemActionID;
		private string userId;
		public long ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public long ProjectProblemActionID
		{
			get { return projectProblemActionID; }
			set { projectProblemActionID = value; }
		}
	
		public string UserId
		{
			get { return userId; }
			set { userId = value; }
		}
	
	}
}
	