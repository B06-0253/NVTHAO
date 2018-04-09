
using System.Collections;
using TPA.Model;
namespace TPA.Facade
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
	