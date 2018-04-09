
using System;
using System.Collections;
using BMS.Facade;
using BMS.Model;
namespace BMS.Business
{

	
	public class ProductsBO : BaseBO
	{
		private ProductsFacade facade = ProductsFacade.Instance;
		protected static ProductsBO instance = new ProductsBO();

		protected ProductsBO()
		{
			this.baseFacade = facade;
		}

		public static ProductsBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	