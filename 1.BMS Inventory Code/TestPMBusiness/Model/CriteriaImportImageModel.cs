
using System;
namespace TEST.Model
{
	public class CriteriaImportImageModel : BaseModel
	{
		private long iD;
		private string fileName;
		private string filePath;
		private long size;
		private DateTime? dateCreated;
		private string criteriaImportId;
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
	
		public DateTime? DateCreated
		{
			get { return dateCreated; }
			set { dateCreated = value; }
		}
	
		public string CriteriaImportId
		{
			get { return criteriaImportId; }
			set { criteriaImportId = value; }
		}
	
	}
}
	