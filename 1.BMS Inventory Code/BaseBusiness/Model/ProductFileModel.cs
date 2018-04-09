
using System;
namespace BMS.Model
{
	public class ProductFileModel : BaseModel
	{
		private int iD;
		private int productID;
		private string name;
		private decimal length;
		private string path;
		private string localPath;
		private int version;
		private string createdBy;
		private DateTime? createdDate;
		private string updatedBy;
		private DateTime? updatedDate;
		public int ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public int ProductID
		{
			get { return productID; }
			set { productID = value; }
		}
	
		public string Name
		{
			get { return name; }
			set { name = value; }
		}
	
		public decimal Length
		{
			get { return length; }
			set { length = value; }
		}
	
		public string Path
		{
			get { return path; }
			set { path = value; }
		}
	
		public string LocalPath
		{
			get { return localPath; }
			set { localPath = value; }
		}
	
		public int Version
		{
			get { return version; }
			set { version = value; }
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
	