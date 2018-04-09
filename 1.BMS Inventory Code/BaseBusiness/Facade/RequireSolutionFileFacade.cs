
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{
	
	public class RequireSolutionFileFacade : BaseFacade
	{
		protected static RequireSolutionFileFacade instance = new RequireSolutionFileFacade(new RequireSolutionFileModel());
		protected RequireSolutionFileFacade(RequireSolutionFileModel model) : base(model)
		{
		}
		public static RequireSolutionFileFacade Instance
		{
			get { return instance; }
		}
		protected RequireSolutionFileFacade():base() 
		{ 
		} 
	
	}
}
	