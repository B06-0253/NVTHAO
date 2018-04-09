
using System;
using System.Collections;
using BMS.Facade;
using BMS.Model;
namespace BMS.Business
{

	
	public class ProductModuleLinkVersionBO : BaseBO
	{
		private ProductModuleLinkVersionFacade facade = ProductModuleLinkVersionFacade.Instance;
		protected static ProductModuleLinkVersionBO instance = new ProductModuleLinkVersionBO();

		protected ProductModuleLinkVersionBO()
		{
			this.baseFacade = facade;
		}

		public static ProductModuleLinkVersionBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	