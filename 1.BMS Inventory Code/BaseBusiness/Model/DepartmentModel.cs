
using System;
namespace BMS.Model
{
	public class DepartmentModel : BaseModel
	{
	
		public int ID { get; set; }
	
		public string Code { get; set; }
	
		public string Name { get; set; }
	
		public string Description { get; set; }
	
		public string CreatedBy { get; set; }
	
		public DateTime CreatedDate { get; set; }
	
		public string UpdatedBy { get; set; }
	
		public DateTime UpdatedDate { get; set; }
	
		public int Status { get; set; }
	
		public string Email { get; set; }
	
		public int HeadofDepartment { get; set; }
	
		public Boolean IsShowHotline { get; set; }
	
        //public Boolean IsShowInventory { get; set; }
	
        //public Boolean IsShowOther { get; set; }
	
	}
}
	