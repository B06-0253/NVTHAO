
using System;
namespace IE.Model
{
	public class T_DM_PHANXUONG_KMPModel : BaseModel
	{
		private int iD;
		private int pK_PHANXUONG;
		private int pK_KMP;
		private decimal tYLE;
		public int ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public int PK_PHANXUONG
		{
			get { return pK_PHANXUONG; }
			set { pK_PHANXUONG = value; }
		}

        public int PK_KMP
		{
			get { return pK_KMP; }
			set { pK_KMP = value; }
		}
	
		public decimal TYLE
		{
			get { return tYLE; }
			set { tYLE = value; }
		}
	
	}
}
	