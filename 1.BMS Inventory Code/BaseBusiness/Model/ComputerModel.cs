
using System;
namespace BMS.Model
{
	public class ComputerModel : BaseModel
	{
	
		public int ID { get; set; }
	
		public string ComputerName { get; set; }
	
		public string Description { get; set; }

        public string PBXNum { get; set; }

		public string ExtNum1 { get; set; }
	
		public string ExtNum2 { get; set; }
	
		public string ExtNum3 { get; set; }
	
		public string ExtNum4 { get; set; }
	
		public string ExtNum5 { get; set; }
	
		public string CreatedBy { get; set; }
	
		public DateTime CreatedDate { get; set; }
	
		public string UpdatedBy { get; set; }
	
		public DateTime UpdatedDate { get; set; }
	
	}
}
	