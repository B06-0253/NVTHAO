
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{
	
	public class SolutionTechnologyFacade : BaseFacade
	{
		protected static SolutionTechnologyFacade instance = new SolutionTechnologyFacade(new SolutionTechnologyModel());
		protected SolutionTechnologyFacade(SolutionTechnologyModel model) : base(model)
		{
		}
		public static SolutionTechnologyFacade Instance
		{
			get { return instance; }
		}
		protected SolutionTechnologyFacade():base() 
		{ 
		} 
	
	}
}
	