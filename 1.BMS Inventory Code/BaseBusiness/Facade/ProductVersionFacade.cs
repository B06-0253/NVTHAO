
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{
	
	public class ProductVersionFacade : BaseFacade
	{
		protected static ProductVersionFacade instance = new ProductVersionFacade(new ProductVersionModel());
		protected ProductVersionFacade(ProductVersionModel model) : base(model)
		{
		}
		public static ProductVersionFacade Instance
		{
			get { return instance; }
		}
		protected ProductVersionFacade():base() 
		{ 
		} 
	
	}
}
	