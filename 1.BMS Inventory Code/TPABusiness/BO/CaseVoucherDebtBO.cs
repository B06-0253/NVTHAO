
using System;
using System.Collections;
using TPA.Facade;
using TPA.Model;
namespace TPA.Business
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
	