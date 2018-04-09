
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{
	
	public class ProductFileFacade : BaseFacade
	{
		protected static ProductFileFacade instance = new ProductFileFacade(new ProductFileModel());
		protected ProductFileFacade(ProductFileModel model) : base(model)
		{
		}
		public static ProductFileFacade Instance
		{
			get { return instance; }
		}
		protected ProductFileFacade():base() 
		{ 
		} 
	
	}
}
	