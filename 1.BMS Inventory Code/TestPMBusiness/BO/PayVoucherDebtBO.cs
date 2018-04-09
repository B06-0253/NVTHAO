
using System;
using System.Collections;
using TEST.Facade;
using TEST.Model;
namespace TEST.Business
{
	
	public class PayVoucherDebtBO : BaseBO
	{
		private PayVoucherDebtFacade facade = PayVoucherDebtFacade.Instance;
		protected static PayVoucherDebtBO instance = new PayVoucherDebtBO();

		protected PayVoucherDebtBO()
		{
			this.baseFacade = facade;
		}

		public static PayVoucherDebtBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	