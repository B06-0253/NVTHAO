
using System.Collections;
using TEST.Model;
namespace TEST.Facade
{
	
	public class RequirePartsFacade : BaseFacade
	{
		protected static RequirePartsFacade instance = new RequirePartsFacade(new RequirePartsModel());
		protected RequirePartsFacade(RequirePartsModel model) : base(model)
		{
		}
		public static RequirePartsFacade Instance
		{
			get { return instance; }
		}
		protected RequirePartsFacade():base() 
		{ 
		} 
	
	}
}
	