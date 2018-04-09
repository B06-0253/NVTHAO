
using System.Collections;
using TPA.Model;
namespace TPA.Facade
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
	