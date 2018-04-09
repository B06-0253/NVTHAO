
using System.Collections;
using TPA.Model;
namespace TPA.Facade
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
	