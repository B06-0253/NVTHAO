
using System;
namespace BMS.Model
{
	public class ModuleErrorImageModel : BaseModel
	{
		private long iD;
		private string fileName;
		private string filePath;
		private long size;
		private DateTime dateCreated;
		private int moduleErrorID;
		public long ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public string FileName
		{
			get { return fileName; }
			set { fileName = value; }
		}
	
		public string FilePath
		{
			get { return filePath; }
			set { filePath = value; }
		}
	
		public long Size
		{
			get { return size; }
			set { size = value; }
		}
	
		public DateTime DateCreated
		{
			get { return dateCreated; }
			set { dateCreated = value; }
		}
	
		public int ModuleErrorID
		{
			get { return moduleErrorID; }
			set { moduleErrorID = value; }
		}
	
	}
}
	