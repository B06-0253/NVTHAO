
using System;
namespace TPA.Model
{
	public class OrdersFileModel : BaseModel
	{
		private long iD;
		private string orderId;
		private string fileName;
		private string filePath;
		private string fileLocalPath;
		private long size;
		private DateTime? dateCreated;
		public long ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public string OrderId
		{
			get { return orderId; }
			set { orderId = value; }
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
	
		public string FileLocalPath
		{
			get { return fileLocalPath; }
			set { fileLocalPath = value; }
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
	
	}
}
	