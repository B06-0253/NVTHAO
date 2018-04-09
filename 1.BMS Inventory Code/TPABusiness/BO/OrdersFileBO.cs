
using System;
using System.Collections;
using TPA.Facade;
using TPA.Model;
namespace TPA.Business
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
	