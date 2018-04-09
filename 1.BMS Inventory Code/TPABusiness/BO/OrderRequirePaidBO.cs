
using System;
using System.Collections;
using TPA.Facade;
using TPA.Model;
namespace TPA.Business
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
	