
using System.Collections;
using TEST.Model;
namespace TEST.Facade
{
	
	public class OrdersFacade : BaseFacade
	{
		protected static OrdersFacade instance = new OrdersFacade(new OrdersModel());
		protected OrdersFacade(OrdersModel model) : base(model)
		{
		}
		public static OrdersFacade Instance
		{
			get { return instance; }
		}
		protected OrdersFacade():base() 
		{ 
		} 
	
	}
}
	