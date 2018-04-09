
using System;
using System.Collections;
using TEST.Facade;
using TEST.Model;
namespace TEST.Business
{
	
	public class OrdersBO : BaseBO
	{
		private OrdersFacade facade = OrdersFacade.Instance;
		protected static OrdersBO instance = new OrdersBO();

		protected OrdersBO()
		{
			this.baseFacade = facade;
		}

		public static OrdersBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	