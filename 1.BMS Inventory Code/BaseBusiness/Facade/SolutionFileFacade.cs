
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{
	
	public class SolutionFileFacade : BaseFacade
	{
		protected static SolutionFileFacade instance = new SolutionFileFacade(new SolutionFileModel());
		protected SolutionFileFacade(SolutionFileModel model) : base(model)
		{
		}
		public static SolutionFileFacade Instance
		{
			get { return instance; }
		}
		protected SolutionFileFacade():base() 
		{ 
		} 
	
	}
}
	