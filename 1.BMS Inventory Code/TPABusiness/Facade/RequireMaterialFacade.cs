
using System.Collections;
using TPA.Model;
namespace TPA.Facade
{
	
	public class RequireMaterialFacade : BaseFacade
	{
		protected static RequireMaterialFacade instance = new RequireMaterialFacade(new RequireMaterialModel());
		protected RequireMaterialFacade(RequireMaterialModel model) : base(model)
		{
		}
		public static RequireMaterialFacade Instance
		{
			get { return instance; }
		}
		protected RequireMaterialFacade():base() 
		{ 
		} 
	
	}
}
	