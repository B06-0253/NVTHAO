
using System.Collections;
using TEST.Model;
namespace TEST.Facade
{
	
	public class OrderRequirePaidFacade : BaseFacade
	{
		protected static OrderRequirePaidFacade instance = new OrderRequirePaidFacade(new OrderRequirePaidModel());
		protected OrderRequirePaidFacade(OrderRequirePaidModel model) : base(model)
		{
		}
		public static OrderRequirePaidFacade Instance
		{
			get { return instance; }
		}
		protected OrderRequirePaidFacade():base() 
		{ 
		} 
	
	}
}
	