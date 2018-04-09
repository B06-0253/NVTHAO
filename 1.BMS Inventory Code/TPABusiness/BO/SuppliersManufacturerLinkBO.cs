
using System;
using System.Collections;
using TPA.Facade;
using TPA.Model;
namespace TPA.Business
{
	
	public class SuppliersManufacturerLinkBO : BaseBO
	{
		private SuppliersManufacturerLinkFacade facade = SuppliersManufacturerLinkFacade.Instance;
		protected static SuppliersManufacturerLinkBO instance = new SuppliersManufacturerLinkBO();

		protected SuppliersManufacturerLinkBO()
		{
			this.baseFacade = facade;
		}

		public static SuppliersManufacturerLinkBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	