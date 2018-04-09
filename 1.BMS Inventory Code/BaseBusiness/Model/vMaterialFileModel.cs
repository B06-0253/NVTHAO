
using System;
namespace BMS.Model
{
	public class vMaterialFileModel : BaseModel
	{
		private int iD;
		private int materialID;
		private string materialCode;
		private string materialName;
		private int materialFileID;
		private string name;
		private int fileType;
		private string causeDelete;
		private bool isDeleted;
		private string extension;
		private decimal length;
		private DateTime datemodified;
		private string description;
		private string note;
		private string path;
		private string createdBy;
		private DateTime createdDate;
		private string updatedBy;
		private DateTime updatedDate;
		public int ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public int MaterialID
		{
			get { return materialID; }
			set { materialID = value; }
		}
	
		public string MaterialCode
		{
			get { return materialCode; }
			set { materialCode = value; }
		}
	
		public string MaterialName
		{
			get { return materialName; }
			set { materialName = value; }
		}
	
		public int MaterialFileID
		{
			get { return materialFileID; }
			set { materialFileID = value; }
		}
	
		public string Name
		{
			get { return name; }
			set { name = value; }
		}
	
		public int FileType
		{
			get { return fileType; }
			set { fileType = value; }
		}
	
		public string CauseDelete
		{
			get { return causeDelete; }
			set { causeDelete = value; }
		}
	
		public bool IsDeleted
		{
			get { return isDeleted; }
			set { isDeleted = value; }
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
	
		public DateTime Datemodified
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
	
		public string CreatedBy
		{
			get { return createdBy; }
			set { createdBy = value; }
		}
	
		public DateTime CreatedDate
		{
			get { return createdDate; }
			set { createdDate = value; }
		}
	
		public string UpdatedBy
		{
			get { return updatedBy; }
			set { updatedBy = value; }
		}
	
		public DateTime UpdatedDate
		{
			get { return updatedDate; }
			set { updatedDate = value; }
		}
	
	}
}
	