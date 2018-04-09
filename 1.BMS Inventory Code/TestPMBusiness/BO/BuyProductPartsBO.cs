
using System;
using System.Collections;
using TEST.Facade;
using TEST.Model;
namespace TEST.Business
{
	
	public class BuyProductPartsBO : BaseBO
	{
		private BuyProductPartsFacade facade = BuyProductPartsFacade.Instance;
		protected static BuyProductPartsBO instance = new BuyProductPartsBO();

		protected BuyProductPartsBO()
		{
			this.baseFacade = facade;
		}

		public static BuyProductPartsBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	