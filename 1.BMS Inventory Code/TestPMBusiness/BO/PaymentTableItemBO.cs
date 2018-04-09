
using System;
using System.Collections;
using TEST.Facade;
using TEST.Model;
namespace TEST.Business
{
	
	public class PaymentTableItemBO : BaseBO
	{
		private PaymentTableItemFacade facade = PaymentTableItemFacade.Instance;
		protected static PaymentTableItemBO instance = new PaymentTableItemBO();

		protected PaymentTableItemBO()
		{
			this.baseFacade = facade;
		}

		public static PaymentTableItemBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	