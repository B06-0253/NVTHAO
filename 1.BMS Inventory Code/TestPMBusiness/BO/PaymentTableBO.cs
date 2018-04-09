
using System;
using System.Collections;
using TEST.Facade;
using TEST.Model;
namespace TEST.Business
{
	
	public class PaymentTableBO : BaseBO
	{
		private PaymentTableFacade facade = PaymentTableFacade.Instance;
		protected static PaymentTableBO instance = new PaymentTableBO();

		protected PaymentTableBO()
		{
			this.baseFacade = facade;
		}

		public static PaymentTableBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	