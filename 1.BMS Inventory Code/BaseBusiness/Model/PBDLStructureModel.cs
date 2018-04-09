
using System;
namespace BMS.Model
{
	public class PBDLStructureModel : BaseModel
	{
		private int iD;
		private string name;
		private int departmentID;
		private int parentID;
		private string parentPath;
		private string path;
		private string description;
        private int folderType;

        public int FolderType
        {
            get { return folderType; }
            set { folderType = value; }
        }
		public int ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public string Name
		{
			get { return name; }
			set { name = value; }
		}
	
		public int DepartmentID
		{
			get { return departmentID; }
			set { departmentID = value; }
		}
	
		public int ParentID
		{
			get { return parentID; }
			set { parentID = value; }
		}
	
		public string ParentPath
		{
			get { return parentPath; }
			set { parentPath = value; }
		}
	
		public string Path
		{
			get { return path; }
			set { path = value; }
		}
	
		public string Description
		{
			get { return description; }
			set { description = value; }
		}
	
	}
}
	