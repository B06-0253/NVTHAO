
using System.Collections;
using TPA.Model;
namespace TPA.Facade
{
	
	public class SuppliersFacade : BaseFacade
	{
		protected static SuppliersFacade instance = new SuppliersFacade(new SuppliersModel());
		protected SuppliersFacade(SuppliersModel model) : base(model)
		{
		}
		public static SuppliersFacade Instance
		{
			get { return instance; }
		}
		protected SuppliersFacade():base() 
		{ 
		} 
	
	}
}
	