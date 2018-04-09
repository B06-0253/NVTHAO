
using System;
using System.Collections;
using TEST.Facade;
using TEST.Model;
namespace TEST.Business
{
	
	public class SupplierContractBO : BaseBO
	{
		private SupplierContractFacade facade = SupplierContractFacade.Instance;
		protected static SupplierContractBO instance = new SupplierContractBO();

		protected SupplierContractBO()
		{
			this.baseFacade = facade;
		}

		public static SupplierContractBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	