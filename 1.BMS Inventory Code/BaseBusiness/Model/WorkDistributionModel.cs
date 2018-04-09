
using System;

namespace BMS.Model
{
	public class WorkDistributionModel : BaseModel
	{
		private int iD;
		private int workID;
		private DateTime workDate;
		private int workWeek;
		private int session;
		private int worker;
		private bool isSupport;
		private string createdBy;
		private DateTime createdDate;
		private string updatedBy;
		private DateTime updatedDate;
		public int ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public int WorkID
		{
			get { return workID; }
			set { workID = value; }
		}
	
		public DateTime WorkDate
		{
			get { return workDate; }
			set { workDate = value; }
		}
	
		public int WorkWeek
		{
			get { return workWeek; }
			set { workWeek = value; }
		}
	
		public int Session
		{
			get { return session; }
			set { session = value; }
		}
	
		public int Worker
		{
			get { return worker; }
			set { worker = value; }
		}

        public bool IsSupport
		{
			get { return isSupport; }
			set { isSupport = value; }
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
	