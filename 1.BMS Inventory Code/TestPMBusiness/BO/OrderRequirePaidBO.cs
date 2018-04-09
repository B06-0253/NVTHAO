
using System;
using System.Collections;
using TEST.Facade;
using TEST.Model;
namespace TEST.Business
{
	
	public class OrderRequirePaidBO : BaseBO
	{
		private OrderRequirePaidFacade facade = OrderRequirePaidFacade.Instance;
		protected static OrderRequirePaidBO instance = new OrderRequirePaidBO();

		protected OrderRequirePaidBO()
		{
			this.baseFacade = facade;
		}

		public static OrderRequirePaidBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	