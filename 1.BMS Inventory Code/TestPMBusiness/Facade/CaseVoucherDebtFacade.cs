
using System.Collections;
using TEST.Model;
namespace TEST.Facade
{
	
	public class CaseVoucherDebtFacade : BaseFacade
	{
		protected static CaseVoucherDebtFacade instance = new CaseVoucherDebtFacade(new CaseVoucherDebtModel());
		protected CaseVoucherDebtFacade(CaseVoucherDebtModel model) : base(model)
		{
		}
		public static CaseVoucherDebtFacade Instance
		{
			get { return instance; }
		}
		protected CaseVoucherDebtFacade():base() 
		{ 
		} 
	
	}
}
	