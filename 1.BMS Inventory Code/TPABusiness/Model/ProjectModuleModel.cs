
using System;
namespace TPA.Model
{
	public class ProjectModuleModel : BaseModel
	{
		private string projectModuleId;
		private string projectModuleName;
		private string projectModuleCode;
		private string specifications;
		private string note;
		private int isModuleStandard;
		private int projectDirectionID;
		public string ProjectModuleId
		{
			get { return projectModuleId; }
			set { projectModuleId = value; }
		}
	
		public string ProjectModuleName
		{
			get { return projectModuleName; }
			set { projectModuleName = value; }
		}
	
		public string ProjectModuleCode
		{
			get { return projectModuleCode; }
			set { projectModuleCode = value; }
		}
	
		public string Specifications
		{
			get { return specifications; }
			set { specifications = value; }
		}
	
		public string Note
		{
			get { return note; }
			set { note = value; }
		}
	
		public int IsModuleStandard
		{
			get { return isModuleStandard; }
			set { isModuleStandard = value; }
		}
	
		public int ProjectDirectionID
		{
			get { return projectDirectionID; }
			set { projectDirectionID = value; }
		}
	
	}
}
	