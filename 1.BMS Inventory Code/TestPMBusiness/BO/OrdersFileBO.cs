
using System;
using System.Collections;
using TEST.Facade;
using TEST.Model;
namespace TEST.Business
{
	
	public class OrdersFileBO : BaseBO
	{
		private OrdersFileFacade facade = OrdersFileFacade.Instance;
		protected static OrdersFileBO instance = new OrdersFileBO();

		protected OrdersFileBO()
		{
			this.baseFacade = facade;
		}

		public static OrdersFileBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	