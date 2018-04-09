
using System;
namespace TPA.Model
{
	public class MaterialModuleLinkModel : BaseModel
	{
		private long iD;
		private string moduleCode;
		private int moduleID;
		private int materialID;
		private string sTT;
		private string name;
		private string thongSo;
		private string code;
		private string maVatLieu;
		private string unit;
		private decimal qty;
		private decimal qtyReal;
		private string vatLieu;
		private decimal weight;
		private string hang;
		private string note;
		private string designer;
		private DateTime? dateCreated;
		private bool isExist;
		private string author;
		private decimal price;
		private decimal delivery;
		private long sizeTK;
		private long sizeDn;
		private long sizeDt;
		public long ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public string ModuleCode
		{
			get { return moduleCode; }
			set { moduleCode = value; }
		}
	
		public int ModuleID
		{
			get { return moduleID; }
			set { moduleID = value; }
		}
	
		public int MaterialID
		{
			get { return materialID; }
			set { materialID = value; }
		}
	
		public string STT
		{
			get { return sTT; }
			set { sTT = value; }
		}
	
		public string Name
		{
			get { return name; }
			set { name = value; }
		}
	
		public string ThongSo
		{
			get { return thongSo; }
			set { thongSo = value; }
		}
	
		public string Code
		{
			get { return code; }
			set { code = value; }
		}
	
		public string MaVatLieu
		{
			get { return maVatLieu; }
			set { maVatLieu = value; }
		}
	
		public string Unit
		{
			get { return unit; }
			set { unit = value; }
		}
	
		public decimal Qty
		{
			get { return qty; }
			set { qty = value; }
		}
	
		public decimal QtyReal
		{
			get { return qtyReal; }
			set { qtyReal = value; }
		}
	
		public string VatLieu
		{
			get { return vatLieu; }
			set { vatLieu = value; }
		}
	
		public decimal Weight
		{
			get { return weight; }
			set { weight = value; }
		}
	
		public string Hang
		{
			get { return hang; }
			set { hang = value; }
		}
	
		public string Note
		{
			get { return note; }
			set { note = value; }
		}
	
		public string Designer
		{
			get { return designer; }
			set { designer = value; }
		}
	
		public DateTime? DateCreated
		{
			get { return dateCreated; }
			set { dateCreated = value; }
		}
	
		public bool IsExist
		{
			get { return isExist; }
			set { isExist = value; }
		}
	
		public string Author
		{
			get { return author; }
			set { author = value; }
		}
	
		public decimal Price
		{
			get { return price; }
			set { price = value; }
		}
	
		public decimal Delivery
		{
			get { return delivery; }
			set { delivery = value; }
		}
	
		public long SizeTK
		{
			get { return sizeTK; }
			set { sizeTK = value; }
		}
	
		public long SizeDn
		{
			get { return sizeDn; }
			set { sizeDn = value; }
		}
	
		public long SizeDt
		{
			get { return sizeDt; }
			set { sizeDt = value; }
		}
	
	}
}
	