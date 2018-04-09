
using System;
namespace BMS.Model
{
	public class ModuleGroupModel : BaseModel
	{
		private int iD;
		private string code;
		private string name;
		private string description;
        private string createdBy;

        private int parentID;
        
        public int ParentID
        {
            get { return parentID; }
            set { parentID = value; }
        }
        
        public string CreatedBy
        {
            get { return createdBy; }
            set { createdBy = value; }
        }
        private DateTime createdDate;

        public DateTime CreatedDate
        {
            get { return createdDate; }
            set { createdDate = value; }
        }
        private string updatedBy;

        public string UpdatedBy
        {
            get { return updatedBy; }
            set { updatedBy = value; }
        }
        private DateTime updatedDate;

        public DateTime UpdatedDate
        {
            get { return updatedDate; }
            set { updatedDate = value; }
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
	
		public string Description
		{
			get { return description; }
			set { description = value; }
		}
	
	}
}
	