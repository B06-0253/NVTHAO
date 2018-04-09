
using System;
using System.Collections;
using TPA.Facade;
using TPA.Model;
namespace TPA.Business
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
	