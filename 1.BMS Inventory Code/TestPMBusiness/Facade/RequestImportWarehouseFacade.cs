
using System.Collections;
using TEST.Model;
namespace TEST.Facade
{
	
	public class RequestImportWarehouseFacade : BaseFacade
	{
		protected static RequestImportWarehouseFacade instance = new RequestImportWarehouseFacade(new RequestImportWarehouseModel());
		protected RequestImportWarehouseFacade(RequestImportWarehouseModel model) : base(model)
		{
		}
		public static RequestImportWarehouseFacade Instance
		{
			get { return instance; }
		}
		protected RequestImportWarehouseFacade():base() 
		{ 
		} 
	
	}
}
	