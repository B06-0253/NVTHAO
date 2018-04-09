
using System;
namespace BMS.Model
{
	public class ProductBaiThucHanhLinkModel : BaseModel
	{
		private int iD;
		private int baiThucHanhID;
		private int productID;
		public int ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public int BaiThucHanhID
		{
			get { return baiThucHanhID; }
			set { baiThucHanhID = value; }
		}
	
		public int ProductID
		{
			get { return productID; }
			set { productID = value; }
		}
	
	}
}
	