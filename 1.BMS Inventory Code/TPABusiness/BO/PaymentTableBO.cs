
using System;
using System.Collections;
using TPA.Facade;
using TPA.Model;
namespace TPA.Business
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
	