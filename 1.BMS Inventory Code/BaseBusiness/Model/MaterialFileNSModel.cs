
using System;
namespace BMS.Model
{
	public class MaterialFileNSModel : BaseModel
	{
		private int iD;
		private int materialNSID;
		private string name;
		private decimal length;
		private string filePath;
		private string createdBy;
		private DateTime? createdDate;
		private string updatedBy;
		private DateTime? updatedDate;
        private string localFilePath;

        public string LocalFilePath
        {
            get { return localFilePath; }
            set { localFilePath = value; }
        }

		public int ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public int MaterialNSID
		{
			get { return materialNSID; }
			set { materialNSID = value; }
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
	
		public string FilePath
		{
			get { return filePath; }
			set { filePath = value; }
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
	