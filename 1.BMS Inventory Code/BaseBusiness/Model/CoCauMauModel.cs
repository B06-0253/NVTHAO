
using System;
namespace BMS.Model
{
	public class CoCauMauModel : BaseModel
	{
		private long iD;
		private string code;
		private string name;
		private long coCauGroupID;
		private string note;
		private int status;
		private string specifications;
		private string imagePath;
		private string description;
		private string createdBy;
		private DateTime? createdDate;
		private string updatedBy;
		private DateTime? updatedDate;
		public long ID
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
	
		public long CoCauGroupID
		{
			get { return coCauGroupID; }
			set { coCauGroupID = value; }
		}
	
		public string Note
		{
			get { return note; }
			set { note = value; }
		}
	
		public int Status
		{
			get { return status; }
			set { status = value; }
		}
	
		public string Specifications
		{
			get { return specifications; }
			set { specifications = value; }
		}
	
		public string ImagePath
		{
			get { return imagePath; }
			set { imagePath = value; }
		}
	
		public string Description
		{
			get { return description; }
			set { description = value; }
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
	