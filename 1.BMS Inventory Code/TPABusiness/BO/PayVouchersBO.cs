
using System;
using System.Collections;
using TPA.Facade;
using TPA.Model;
namespace TPA.Business
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
	