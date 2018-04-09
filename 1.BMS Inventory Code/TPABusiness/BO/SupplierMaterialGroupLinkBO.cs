
using System;
using System.Collections;
using TPA.Facade;
using TPA.Model;
namespace TPA.Business
{
	
	public class SupplierMaterialGroupLinkBO : BaseBO
	{
		private SupplierMaterialGroupLinkFacade facade = SupplierMaterialGroupLinkFacade.Instance;
		protected static SupplierMaterialGroupLinkBO instance = new SupplierMaterialGroupLinkBO();

		protected SupplierMaterialGroupLinkBO()
		{
			this.baseFacade = facade;
		}

		public static SupplierMaterialGroupLinkBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	