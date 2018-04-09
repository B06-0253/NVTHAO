
using System;
using System.Collections;
using BMS.Facade;
using BMS.Model;
namespace BMS.Business
{

	
	public class ProductVersionBO : BaseBO
	{
		private ProductVersionFacade facade = ProductVersionFacade.Instance;
		protected static ProductVersionBO instance = new ProductVersionBO();

		protected ProductVersionBO()
		{
			this.baseFacade = facade;
		}

		public static ProductVersionBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	