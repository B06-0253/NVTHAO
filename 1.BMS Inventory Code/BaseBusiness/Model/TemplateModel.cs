
using System;
namespace BMS.Model
{
	public class TemplateModel : BaseModel
	{
		private int iD;
		private string name;
		private string code;
		private string description;
		private int type;
		private string pathFolderC;
		private int productID;
		private string createdBy;
		private DateTime createdDate;
		private string updatedBy;
		private DateTime updatedDate;
		private bool isDisplay;
		private int priority;
		private int status;
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
	
		public string Code
		{
			get { return code; }
			set { code = value; }
		}
	
		public string Description
		{
			get { return description; }
			set { description = value; }
		}
	
		public int Type
		{
			get { return type; }
			set { type = value; }
		}
	
		public string PathFolderC
		{
			get { return pathFolderC; }
			set { pathFolderC = value; }
		}
	
		public int ProductID
		{
			get { return productID; }
			set { productID = value; }
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
	
		public bool IsDisplay
		{
			get { return isDisplay; }
			set { isDisplay = value; }
		}
	
		public int Priority
		{
			get { return priority; }
			set { priority = value; }
		}
	
		public int Status
		{
			get { return status; }
			set { status = value; }
		}
	
	}
}
	