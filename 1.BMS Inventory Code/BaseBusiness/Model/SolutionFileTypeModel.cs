
using System;
namespace BMS.Model
{
	public class SolutionFileTypeModel : BaseModel
	{
		private long iD;
		private string typeName;
		public long ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public string TypeName
		{
			get { return typeName; }
			set { typeName = value; }
		}
	
	}
}
	