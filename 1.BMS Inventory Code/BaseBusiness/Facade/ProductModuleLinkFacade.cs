
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{
	
	public class ProductModuleLinkFacade : BaseFacade
	{
		protected static ProductModuleLinkFacade instance = new ProductModuleLinkFacade(new ProductModuleLinkModel());
		protected ProductModuleLinkFacade(ProductModuleLinkModel model) : base(model)
		{
		}
		public static ProductModuleLinkFacade Instance
		{
			get { return instance; }
		}
		protected ProductModuleLinkFacade():base() 
		{ 
		} 
	
	}
}
	