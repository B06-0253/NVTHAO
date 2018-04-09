
using System;
using System.Collections;
using BMS.Facade;
using BMS.Model;
namespace BMS.Business
{

	
	public class ProductFileBO : BaseBO
	{
		private ProductFileFacade facade = ProductFileFacade.Instance;
		protected static ProductFileBO instance = new ProductFileBO();

		protected ProductFileBO()
		{
			this.baseFacade = facade;
		}

		public static ProductFileBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	