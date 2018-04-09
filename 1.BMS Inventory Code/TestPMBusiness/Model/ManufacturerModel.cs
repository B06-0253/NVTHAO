
using System;
namespace TEST.Model
{
	public class ManufacturerModel : BaseModel
	{
		private string manufacturerId;
		private string mName;
		private string note;
		private string manufacturerERPId;
		private DateTime? dateArising;
		private string manufacturerCode;
		private int nhanTinStatus;
		private string userId;
		public string ManufacturerId
		{
			get { return manufacturerId; }
			set { manufacturerId = value; }
		}
	
		public string MName
		{
			get { return mName; }
			set { mName = value; }
		}
	
		public string Note
		{
			get { return note; }
			set { note = value; }
		}
	
		public string ManufacturerERPId
		{
			get { return manufacturerERPId; }
			set { manufacturerERPId = value; }
		}
	
		public DateTime? DateArising
		{
			get { return dateArising; }
			set { dateArising = value; }
		}
	
		public string ManufacturerCode
		{
			get { return manufacturerCode; }
			set { manufacturerCode = value; }
		}
	
		public int NhanTinStatus
		{
			get { return nhanTinStatus; }
			set { nhanTinStatus = value; }
		}
	
		public string UserId
		{
			get { return userId; }
			set { userId = value; }
		}
	
	}
}
	