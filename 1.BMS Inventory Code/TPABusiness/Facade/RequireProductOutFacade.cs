
using System.Collections;
using TPA.Model;
namespace TPA.Facade
{
	
	public class RequireProductOutFacade : BaseFacade
	{
		protected static RequireProductOutFacade instance = new RequireProductOutFacade(new RequireProductOutModel());
		protected RequireProductOutFacade(RequireProductOutModel model) : base(model)
		{
		}
		public static RequireProductOutFacade Instance
		{
			get { return instance; }
		}
		protected RequireProductOutFacade():base() 
		{ 
		} 
	
	}
}
	