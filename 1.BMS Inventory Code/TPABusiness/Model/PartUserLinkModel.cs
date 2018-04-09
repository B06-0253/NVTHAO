
using System;
namespace TPA.Model
{
	public class PartUserLinkModel : BaseModel
	{
		private long iD;
		private string partsId;
		private string userId;
		public long ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public string PartsId
		{
			get { return partsId; }
			set { partsId = value; }
		}
	
		public string UserId
		{
			get { return userId; }
			set { userId = value; }
		}
	
	}
}
	