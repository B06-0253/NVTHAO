
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{
	
	public class ProductsFacade : BaseFacade
	{
		protected static ProductsFacade instance = new ProductsFacade(new ProductsModel());
		protected ProductsFacade(ProductsModel model) : base(model)
		{
		}
		public static ProductsFacade Instance
		{
			get { return instance; }
		}
		protected ProductsFacade():base() 
		{ 
		} 
	
	}
}
	