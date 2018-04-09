
using System;
namespace TPA.Model
{
	public class ProjectDirectionTypeModel : BaseModel
	{
		private int iD;
		private string code;
		private string name;
		private decimal qty;
		private decimal timeDK;
        private int parentID;

        public int ParentID
        {
            get { return parentID; }
            set { parentID = value; }
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
	
		public decimal Qty
		{
			get { return qty; }
			set { qty = value; }
		}
	
		public decimal TimeDK
		{
			get { return timeDK; }
			set { timeDK = value; }
		}
	
	}
}
	