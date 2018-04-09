
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{
	
	public class BaoLoiFacade : BaseFacade
	{
		protected static BaoLoiFacade instance = new BaoLoiFacade(new BaoLoiModel());
		protected BaoLoiFacade(BaoLoiModel model) : base(model)
		{
		}
		public static BaoLoiFacade Instance
		{
			get { return instance; }
		}
		protected BaoLoiFacade():base() 
		{ 
		} 
	
	}
}
	