
using System;
namespace BMS.Model
{
	public class TestModel : BaseModel
	{
		private int iD;
		private string moduleCode;
		private string materialCode;
		private string materialName;
		private string hang;
		private string error;
		public int ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public string ModuleCode
		{
			get { return moduleCode; }
			set { moduleCode = value; }
		}
	
		public string MaterialCode
		{
			get { return materialCode; }
			set { materialCode = value; }
		}
	
		public string MaterialName
		{
			get { return materialName; }
			set { materialName = value; }
		}
	
		public string Hang
		{
			get { return hang; }
			set { hang = value; }
		}
	
		public string Error
		{
			get { return error; }
			set { error = value; }
		}
	
	}
}
	