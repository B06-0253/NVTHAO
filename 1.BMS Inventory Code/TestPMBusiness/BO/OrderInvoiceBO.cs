
using System;
using System.Collections;
using TEST.Facade;
using TEST.Model;
namespace TEST.Business
{
	
	public class OrderInvoiceBO : BaseBO
	{
		private OrderInvoiceFacade facade = OrderInvoiceFacade.Instance;
		protected static OrderInvoiceBO instance = new OrderInvoiceBO();

		protected OrderInvoiceBO()
		{
			this.baseFacade = facade;
		}

		public static OrderInvoiceBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	