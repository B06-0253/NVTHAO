
using System.Collections;
using TEST.Model;
namespace TEST.Facade
{
	
	public class SuppliersManufacturerLinkFacade : BaseFacade
	{
		protected static SuppliersManufacturerLinkFacade instance = new SuppliersManufacturerLinkFacade(new SuppliersManufacturerLinkModel());
		protected SuppliersManufacturerLinkFacade(SuppliersManufacturerLinkModel model) : base(model)
		{
		}
		public static SuppliersManufacturerLinkFacade Instance
		{
			get { return instance; }
		}
		protected SuppliersManufacturerLinkFacade():base() 
		{ 
		} 
	
	}
}
	