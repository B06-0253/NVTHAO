
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{
	
	public class TheoDoiFacade : BaseFacade
	{
		protected static TheoDoiFacade instance = new TheoDoiFacade(new TheoDoiModel());
		protected TheoDoiFacade(TheoDoiModel model) : base(model)
		{
		}
		public static TheoDoiFacade Instance
		{
			get { return instance; }
		}
		protected TheoDoiFacade():base() 
		{ 
		} 
	
	}
}
	