
using System;
namespace TPA.Model
{
	public class SupplierContractModel : BaseModel
	{
		private int iD;
		private string supplierId;
		private int contractType;
		private DateTime? signDate;
		private DateTime? outDate;
		private bool isReceived;
		public int ID
		{
			get { return iD; }
			set { iD = value; }
		}
	
		public string SupplierId
		{
			get { return supplierId; }
			set { supplierId = value; }
		}
	
		public int ContractType
		{
			get { return contractType; }
			set { contractType = value; }
		}
	
		public DateTime? SignDate
		{
			get { return signDate; }
			set { signDate = value; }
		}
	
		public DateTime? OutDate
		{
			get { return outDate; }
			set { outDate = value; }
		}
	
		public bool IsReceived
		{
			get { return isReceived; }
			set { isReceived = value; }
		}
	
	}
}
	