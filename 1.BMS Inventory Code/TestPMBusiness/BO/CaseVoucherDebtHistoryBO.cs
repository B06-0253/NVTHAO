
using System;
using System.Collections;
using TEST.Facade;
using TEST.Model;
namespace TEST.Business
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
	