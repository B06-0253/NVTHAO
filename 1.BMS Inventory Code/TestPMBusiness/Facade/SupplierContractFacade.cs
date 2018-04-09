
using System.Collections;
using TEST.Model;
namespace TEST.Facade
{
	
	public class SupplierContractFacade : BaseFacade
	{
		protected static SupplierContractFacade instance = new SupplierContractFacade(new SupplierContractModel());
		protected SupplierContractFacade(SupplierContractModel model) : base(model)
		{
		}
		public static SupplierContractFacade Instance
		{
			get { return instance; }
		}
		protected SupplierContractFacade():base() 
		{ 
		} 
	
	}
}
	