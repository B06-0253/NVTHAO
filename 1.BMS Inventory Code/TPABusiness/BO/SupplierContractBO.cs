
using System;
using System.Collections;
using TPA.Facade;
using TPA.Model;
namespace TPA.Business
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
	