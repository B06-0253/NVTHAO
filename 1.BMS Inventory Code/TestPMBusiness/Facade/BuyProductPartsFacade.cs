
using System.Collections;
using TEST.Model;
namespace TEST.Facade
{
	
	public class BuyProductPartsFacade : BaseFacade
	{
		protected static BuyProductPartsFacade instance = new BuyProductPartsFacade(new BuyProductPartsModel());
		protected BuyProductPartsFacade(BuyProductPartsModel model) : base(model)
		{
		}
		public static BuyProductPartsFacade Instance
		{
			get { return instance; }
		}
		protected BuyProductPartsFacade():base() 
		{ 
		} 
	
	}
}
	