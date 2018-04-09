
using System.Collections;
using TEST.Model;
namespace TEST.Facade
{
	
	public class OrderInvoiceFacade : BaseFacade
	{
		protected static OrderInvoiceFacade instance = new OrderInvoiceFacade(new OrderInvoiceModel());
		protected OrderInvoiceFacade(OrderInvoiceModel model) : base(model)
		{
		}
		public static OrderInvoiceFacade Instance
		{
			get { return instance; }
		}
		protected OrderInvoiceFacade():base() 
		{ 
		} 
	
	}
}
	