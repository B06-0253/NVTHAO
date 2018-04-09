
using System;
using System.Collections;
using TEST.Facade;
using TEST.Model;
namespace TEST.Business
{
	
	public class SuppliersBO : BaseBO
	{
		private SuppliersFacade facade = SuppliersFacade.Instance;
		protected static SuppliersBO instance = new SuppliersBO();

		protected SuppliersBO()
		{
			this.baseFacade = facade;
		}

		public static SuppliersBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	