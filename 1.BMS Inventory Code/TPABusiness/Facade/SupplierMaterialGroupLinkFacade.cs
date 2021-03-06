
using System.Collections;
using TPA.Model;
namespace TPA.Facade
{
	
	public class SupplierMaterialGroupLinkFacade : BaseFacade
	{
		protected static SupplierMaterialGroupLinkFacade instance = new SupplierMaterialGroupLinkFacade(new SupplierMaterialGroupLinkModel());
		protected SupplierMaterialGroupLinkFacade(SupplierMaterialGroupLinkModel model) : base(model)
		{
		}
		public static SupplierMaterialGroupLinkFacade Instance
		{
			get { return instance; }
		}
		protected SupplierMaterialGroupLinkFacade():base() 
		{ 
		} 
	
	}
}
	