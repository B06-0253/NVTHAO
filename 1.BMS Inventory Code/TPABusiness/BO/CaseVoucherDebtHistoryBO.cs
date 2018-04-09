
using System;
using System.Collections;
using TPA.Facade;
using TPA.Model;
namespace TPA.Business
{
	
	public class CaseVoucherDebtHistoryBO : BaseBO
	{
		private CaseVoucherDebtHistoryFacade facade = CaseVoucherDebtHistoryFacade.Instance;
		protected static CaseVoucherDebtHistoryBO instance = new CaseVoucherDebtHistoryBO();

		protected CaseVoucherDebtHistoryBO()
		{
			this.baseFacade = facade;
		}

		public static CaseVoucherDebtHistoryBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	