
using System;
namespace BMS.Model
{
	public class CurrencyModel : BaseModel
	{
		private string iD;
		private string name;
		private bool masterStatus;
		private string createdBy;
		private DateTime createdDate;
		private string updatedBy;
		private DateTime updatedDate;
		public string ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public string Name
		{
			get { return name; }
			set { name = value; }
		}
	
		public bool MasterStatus
		{
			get { return masterStatus; }
			set { masterStatus = value; }
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
	