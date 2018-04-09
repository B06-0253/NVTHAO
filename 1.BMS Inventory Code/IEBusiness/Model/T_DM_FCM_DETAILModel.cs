
using System;
namespace IE.Model
{
	public class T_DM_FCM_DETAILModel : BaseModel
	{
		private int iD;
		private int fK_FCM;
		private int fK_PHANXUONG;
		private int fK_KMP;
		private decimal c_PRICE;
		public int ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public int FK_FCM
		{
			get { return fK_FCM; }
			set { fK_FCM = value; }
		}
	
		public int FK_PHANXUONG
		{
			get { return fK_PHANXUONG; }
			set { fK_PHANXUONG = value; }
		}
	
		public int FK_KMP
		{
			get { return fK_KMP; }
			set { fK_KMP = value; }
		}
	
		public decimal C_PRICE
		{
			get { return c_PRICE; }
			set { c_PRICE = value; }
		}
	
	}
}
	