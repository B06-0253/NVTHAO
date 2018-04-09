
using System.Collections;
using TPA.Model;
namespace TPA.Facade
{
	
	public class ProductPartsImportFacade : BaseFacade
	{
		protected static ProductPartsImportFacade instance = new ProductPartsImportFacade(new ProductPartsImportModel());
		protected ProductPartsImportFacade(ProductPartsImportModel model) : base(model)
		{
		}
		public static ProductPartsImportFacade Instance
		{
			get { return instance; }
		}
		protected ProductPartsImportFacade():base() 
		{ 
		} 
	
	}
}
	