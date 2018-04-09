
using System;
using System.Collections;
using TPA.Facade;
using TPA.Model;
namespace TPA.Business
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
	