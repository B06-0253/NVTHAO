
using System.Collections;
using TEST.Model;
namespace TEST.Facade
{
	
	public class OrdersFileFacade : BaseFacade
	{
		protected static OrdersFileFacade instance = new OrdersFileFacade(new OrdersFileModel());
		protected OrdersFileFacade(OrdersFileModel model) : base(model)
		{
		}
		public static OrdersFileFacade Instance
		{
			get { return instance; }
		}
		protected OrdersFileFacade():base() 
		{ 
		} 
	
	}
}
	