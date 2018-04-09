
using System;
namespace BMS.Model
{
	public class DesignStructureFileModel : BaseModel
	{
		private int iD;
		private string name;
		private int designStructureID;
        private bool exist;

        public bool Exist
        {
            get { return exist; }
            set { exist = value; }
        }
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
	
		public int DesignStructureID
		{
			get { return designStructureID; }
			set { designStructureID = value; }
		}
	
	}
}
	