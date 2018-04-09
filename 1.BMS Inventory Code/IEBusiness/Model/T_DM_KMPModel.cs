
using System;
namespace IE.Model
{
	public class T_DM_KMPModel : BaseModel
	{
		private int pK_ID;
		private int fK_DVCS;
		private bool c_CAP;
		private string c_MA;
		private string c_MOTA;
		private string fK_TKNO;
		private string fK_TKCO;
		private bool c_TINHLAI;
		private decimal c_DONGIA;
		private bool c_VATTU;
		private bool c_AN;
		private DateTime? c_LASTEXPORT;
		private int fK_GROUP;
		public int PK_ID
		{
			get { return pK_ID; }
			set { pK_ID = value; }
		}
	
		public int FK_DVCS
		{
			get { return fK_DVCS; }
			set { fK_DVCS = value; }
		}
	
		public bool C_CAP
		{
			get { return c_CAP; }
			set { c_CAP = value; }
		}
	
		public string C_MA
		{
			get { return c_MA; }
			set { c_MA = value; }
		}
	
		public string C_MOTA
		{
			get { return c_MOTA; }
			set { c_MOTA = value; }
		}
	
		public string FK_TKNO
		{
			get { return fK_TKNO; }
			set { fK_TKNO = value; }
		}
	
		public string FK_TKCO
		{
			get { return fK_TKCO; }
			set { fK_TKCO = value; }
		}
	
		public bool C_TINHLAI
		{
			get { return c_TINHLAI; }
			set { c_TINHLAI = value; }
		}
	
		public decimal C_DONGIA
		{
			get { return c_DONGIA; }
			set { c_DONGIA = value; }
		}
	
		public bool C_VATTU
		{
			get { return c_VATTU; }
			set { c_VATTU = value; }
		}
	
		public bool C_AN
		{
			get { return c_AN; }
			set { c_AN = value; }
		}
	
		public DateTime? C_LASTEXPORT
		{
			get { return c_LASTEXPORT; }
			set { c_LASTEXPORT = value; }
		}
	
		public int FK_GROUP
		{
			get { return fK_GROUP; }
			set { fK_GROUP = value; }
		}
	
	}
}
	