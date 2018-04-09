
using System;
namespace BMS.Model
{
	public class File3DModel : BaseModel
	{
		private int iD;
		private string name;
		private int productGroupID;
		private decimal length;
		private DateTime datemodified;
		private string description;
		private string note;
		private string path;
		private string createdBy;
		private DateTime createdDate;
		private string updatedBy;
		private DateTime updatedDate;
        private int manufacturerID;
        private bool isDeleted;
        private string extension;

        public string Extension
        {
            get { return extension; }
            set { extension = value; }
        }
        private string code;

        public string Code
        {
            get { return code; }
            set { code = value; }
        }

        public bool IsDeleted
        {
            get { return isDeleted; }
            set { isDeleted = value; }
        }
        public int ManufacturerID
        {
            get { return manufacturerID; }
            set { manufacturerID = value; }
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
	
		public int ProductGroupID
		{
			get { return productGroupID; }
			set { productGroupID = value; }
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
	