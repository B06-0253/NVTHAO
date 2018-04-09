
using System;
namespace BMS.Model
{
	public class MaterialFileModel : BaseModel
	{
		private int iD;
		private string code;
		private string name;
		private string extension;
		private decimal length;
		private DateTime? datemodified;
		private string description;
		private string note;
		private string path;
		private bool isDeleted;
		private string causeDelete;
		private int fileType;
		private string createdBy;
		private DateTime? createdDate;
		private string updatedBy;
		private DateTime? updatedDate;
		private int custormerID;
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
	
		public string Extension
		{
			get { return extension; }
			set { extension = value; }
		}
	
		public decimal Length
		{
			get { return length; }
			set { length = value; }
		}
	
		public DateTime? Datemodified
		{
			get { return datemodified; }
			set { datemodified = value; }
		}
	
		public string Description
		{
			get { return description; }
			set { description = value; }
		}
	
		public string Note
		{
			get { return note; }
			set { note = value; }
		}
	
		public string Path
		{
			get { return path; }
			set { path = value; }
		}
	
		public bool IsDeleted
		{
			get { return isDeleted; }
			set { isDeleted = value; }
		}
	
		public string CauseDelete
		{
			get { return causeDelete; }
			set { causeDelete = value; }
		}
	
		public int FileType
		{
			get { return fileType; }
			set { fileType = value; }
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
	
		public int CustormerID
		{
			get { return custormerID; }
			set { custormerID = value; }
		}
	
	}
}
	