
using System;
using System.Collections;
using TEST.Facade;
using TEST.Model;
namespace TEST.Business
{
	
	public class CaseVoucherDebtBO : BaseBO
	{
		private CaseVoucherDebtFacade facade = CaseVoucherDebtFacade.Instance;
		protected static CaseVoucherDebtBO instance = new CaseVoucherDebtBO();

		protected CaseVoucherDebtBO()
		{
			this.baseFacade = facade;
		}

		public static CaseVoucherDebtBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	