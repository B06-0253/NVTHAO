
using System;
using System.Collections;
using TPA.Facade;
using TPA.Model;
namespace TPA.Business
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
	