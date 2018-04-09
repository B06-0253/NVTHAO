
using System;
using System.Collections;
using TEST.Facade;
using TEST.Model;
namespace TEST.Business
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
	