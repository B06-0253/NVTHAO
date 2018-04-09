
using System;
namespace BMS.Model
{
	public class ProductBaiThucHanhLinkVersionModel : BaseModel
	{
		private int iD;
		private int productVersionID;
		private int baiThucHanhID;
		public int ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public int ProductVersionID
		{
			get { return productVersionID; }
			set { productVersionID = value; }
		}
	
		public int BaiThucHanhID
		{
			get { return baiThucHanhID; }
			set { baiThucHanhID = value; }
		}
	
	}
}
	