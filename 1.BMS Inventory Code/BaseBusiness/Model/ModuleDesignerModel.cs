
using System;
namespace BMS.Model
{
	public class ModuleDesignerModel : BaseModel
	{
		private int iD;
		private string workDetail;
		private string tenCum;
		private string maCum;
		private int moduleID;
		private string loginName;
		private string description;
		private int groupType;
        private string author;

        public string Author
        {
            get { return author; }
            set { author = value; }
        }
		public int ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public string WorkDetail
		{
			get { return workDetail; }
			set { workDetail = value; }
		}
	
		public string TenCum
		{
			get { return tenCum; }
			set { tenCum = value; }
		}
	
		public string MaCum
		{
			get { return maCum; }
			set { maCum = value; }
		}
	
		public int ModuleID
		{
			get { return moduleID; }
			set { moduleID = value; }
		}

        public string LoginName
		{
			get { return loginName; }
			set { loginName = value; }
		}
	
		public string Description
		{
			get { return description; }
			set { description = value; }
		}
	
		public int GroupType
		{
			get { return groupType; }
			set { groupType = value; }
		}
	
	}
}
	