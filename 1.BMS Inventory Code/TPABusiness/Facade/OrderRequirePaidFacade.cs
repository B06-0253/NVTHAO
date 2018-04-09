
using System.Collections;
using TPA.Model;
namespace TPA.Facade
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
	