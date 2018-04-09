
using System;
namespace TPA.Model
{
	public class ProjectStatusModel : BaseModel
	{
		private int iD;
		private string code;
		private string name;
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
	
	}
}
	