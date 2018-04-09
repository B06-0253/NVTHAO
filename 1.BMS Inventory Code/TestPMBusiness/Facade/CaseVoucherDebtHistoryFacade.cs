
using System.Collections;
using TEST.Model;
namespace TEST.Facade
{
	
	public class CaseVoucherDebtHistoryFacade : BaseFacade
	{
		protected static CaseVoucherDebtHistoryFacade instance = new CaseVoucherDebtHistoryFacade(new CaseVoucherDebtHistoryModel());
		protected CaseVoucherDebtHistoryFacade(CaseVoucherDebtHistoryModel model) : base(model)
		{
		}
		public static CaseVoucherDebtHistoryFacade Instance
		{
			get { return instance; }
		}
		protected CaseVoucherDebtHistoryFacade():base() 
		{ 
		} 
	
	}
}
	