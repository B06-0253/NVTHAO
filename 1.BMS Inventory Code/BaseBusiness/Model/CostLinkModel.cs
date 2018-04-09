
using System;
namespace BMS.Model
{
	public class CostLinkModel : BaseModel
	{
		private int iD;
		private int costGroupID;
		private int costDetailID;
		private decimal costPercent;
		private string createdBy;
		private DateTime? createdDate;
		private string updatedBy;
		private DateTime? updatedDate;
		public int ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public int CostGroupID
		{
			get { return costGroupID; }
			set { costGroupID = value; }
		}
	
		public int CostDetailID
		{
			get { return costDetailID; }
			set { costDetailID = value; }
		}
	
		public decimal CostPercent
		{
			get { return costPercent; }
			set { costPercent = value; }
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
	