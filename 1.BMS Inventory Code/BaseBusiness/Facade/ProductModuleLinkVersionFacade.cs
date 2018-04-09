
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{
	
	public class ProductModuleLinkVersionFacade : BaseFacade
	{
		protected static ProductModuleLinkVersionFacade instance = new ProductModuleLinkVersionFacade(new ProductModuleLinkVersionModel());
		protected ProductModuleLinkVersionFacade(ProductModuleLinkVersionModel model) : base(model)
		{
		}
		public static ProductModuleLinkVersionFacade Instance
		{
			get { return instance; }
		}
		protected ProductModuleLinkVersionFacade():base() 
		{ 
		} 
	
	}
}
	