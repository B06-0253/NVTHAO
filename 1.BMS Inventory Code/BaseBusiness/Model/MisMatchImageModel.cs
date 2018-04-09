
using System;
namespace BMS.Model
{
	public class MisMatchImageModel : BaseModel
	{
		private long iD;
		private string fileName;
		private string filePath;
		private long size;
		private int misMatchID;
		private string createdBy;
		private DateTime? createdDate;
		private string updatedBy;
		private DateTime? updatedDate;
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
	
		public int MisMatchID
		{
			get { return misMatchID; }
			set { misMatchID = value; }
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
	