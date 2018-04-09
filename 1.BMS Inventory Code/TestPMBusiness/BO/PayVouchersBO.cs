
using System;
using System.Collections;
using TEST.Facade;
using TEST.Model;
namespace TEST.Business
{
	
	public class PayVouchersBO : BaseBO
	{
		private PayVouchersFacade facade = PayVouchersFacade.Instance;
		protected static PayVouchersBO instance = new PayVouchersBO();

		protected PayVouchersBO()
		{
			this.baseFacade = facade;
		}

		public static PayVouchersBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	