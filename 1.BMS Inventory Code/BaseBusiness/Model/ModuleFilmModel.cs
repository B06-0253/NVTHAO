
using System;
namespace BMS.Model
{
	public class ModuleFilmModel : BaseModel
	{
		private int iD;
		private string code;
		private string name;
		private int lastTimeChange;
		private DateTime lastDateChange;
		private int moduleID;
		private string createdBy;
		private DateTime createdDate;
		private string updatedBy;
		private DateTime updatedDate;
        private int type;
        private long size;
        private string reason;

        public string Reason
        {
            get { return reason; }
            set { reason = value; }
        }

        public long Size
        {
            get { return size; }
            set { size = value; }
        }

        public int Type
        {
            get { return type; }
            set { type = value; }
        }

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
	
		public int LastTimeChange
		{
			get { return lastTimeChange; }
			set { lastTimeChange = value; }
		}
	
		public DateTime LastDateChange
		{
			get { return lastDateChange; }
			set { lastDateChange = value; }
		}
	
		public int ModuleID
		{
			get { return moduleID; }
			set { moduleID = value; }
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
	