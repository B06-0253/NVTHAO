
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{
	
	public class RequireSolutionFacade : BaseFacade
	{
		protected static RequireSolutionFacade instance = new RequireSolutionFacade(new RequireSolutionModel());
		protected RequireSolutionFacade(RequireSolutionModel model) : base(model)
		{
		}
		public static RequireSolutionFacade Instance
		{
			get { return instance; }
		}
		protected RequireSolutionFacade():base() 
		{ 
		} 
	
	}
}
	