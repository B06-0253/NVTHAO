
using System;
namespace IE.Model
{
	public class T_DM_FCMModel : BaseModel
	{
		private int iD;
		private int fK_DTCP;
		private int c_MONTH;
		private int c_YEAR;
		private string c_CODE;
		private string c_SOHOADON;
		private int c_TYPE;
		private decimal totalHD;
		private decimal totalTPA;
		private decimal totalVAT;
		private decimal totalReal;
		private decimal totalBanHang;
		private decimal totalNC;
		private decimal totalPB;
		private decimal totalBX;
		private decimal totalProfit;
		private decimal totalTrienKhai;
        private decimal totalVT;
       
		public int ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public int FK_DTCP
		{
			get { return fK_DTCP; }
			set { fK_DTCP = value; }
		}
	
		public int C_MONTH
		{
			get { return c_MONTH; }
			set { c_MONTH = value; }
		}
	
		public int C_YEAR
		{
			get { return c_YEAR; }
			set { c_YEAR = value; }
		}
	
		public string C_CODE
		{
			get { return c_CODE; }
			set { c_CODE = value; }
		}
	
		public string C_SOHOADON
		{
			get { return c_SOHOADON; }
			set { c_SOHOADON = value; }
		}
	
		public int C_TYPE
		{
			get { return c_TYPE; }
			set { c_TYPE = value; }
		}
	
		public decimal TotalHD
		{
			get { return totalHD; }
			set { totalHD = value; }
		}
	
		public decimal TotalTPA
		{
			get { return totalTPA; }
			set { totalTPA = value; }
		}
	
		public decimal TotalVAT
		{
			get { return totalVAT; }
			set { totalVAT = value; }
		}
	
		public decimal TotalReal
		{
			get { return totalReal; }
			set { totalReal = value; }
		}
	
		public decimal TotalBanHang
		{
			get { return totalBanHang; }
			set { totalBanHang = value; }
		}
	
		public decimal TotalNC
		{
			get { return totalNC; }
			set { totalNC = value; }
		}
	
		public decimal TotalPB
		{
			get { return totalPB; }
			set { totalPB = value; }
		}
	
		public decimal TotalBX
		{
			get { return totalBX; }
			set { totalBX = value; }
		}
	
		public decimal TotalProfit
		{
			get { return totalProfit; }
			set { totalProfit = value; }
		}
	
		public decimal TotalTrienKhai
		{
			get { return totalTrienKhai; }
			set { totalTrienKhai = value; }
		}

        public decimal TotalVT
        {
            get { return totalVT; }
            set { totalVT = value; }
        }
	}
}
	