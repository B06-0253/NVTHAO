
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{
	
	public class StuffsFacade : BaseFacade
	{
		protected static StuffsFacade instance = new StuffsFacade(new StuffsModel());
		protected StuffsFacade(StuffsModel model) : base(model)
		{
		}
		public static StuffsFacade Instance
		{
			get { return instance; }
		}
		protected StuffsFacade():base() 
		{ 
		} 
	
	}
}
	