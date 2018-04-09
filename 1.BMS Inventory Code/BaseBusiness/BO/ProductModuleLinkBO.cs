
using System;
using System.Collections;
using BMS.Facade;
using BMS.Model;
namespace BMS.Business
{

	
	public class ProductModuleLinkBO : BaseBO
	{
		private ProductModuleLinkFacade facade = ProductModuleLinkFacade.Instance;
		protected static ProductModuleLinkBO instance = new ProductModuleLinkBO();

		protected ProductModuleLinkBO()
		{
			this.baseFacade = facade;
		}

		public static ProductModuleLinkBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	