
using System;
namespace BMS.Model
{
	public class NgayNghiModel : BaseModel
	{
		private int iD;
		private DateTime ngayNghi;
		public int ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public DateTime NgayNghi
		{
			get { return ngayNghi; }
			set { ngayNghi = value; }
		}
	
	}
}
	