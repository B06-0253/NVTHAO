
using System.Collections;
using TPA.Model;
namespace TPA.Facade
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
	