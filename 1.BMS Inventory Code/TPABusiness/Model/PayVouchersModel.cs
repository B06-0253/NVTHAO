
using System;
namespace TPA.Model
{
	public class PayVouchersModel : BaseModel
	{
		private int iD;
		private string name;
        private int type;
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

        public int Type
        {
            get { return type; }
            set { type = value; }
        }	
	}
}
	