
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{
	
	public class SolutionFacade : BaseFacade
	{
		protected static SolutionFacade instance = new SolutionFacade(new SolutionModel());
		protected SolutionFacade(SolutionModel model) : base(model)
		{
		}
		public static SolutionFacade Instance
		{
			get { return instance; }
		}
		protected SolutionFacade():base() 
		{ 
		} 
	
	}
}
	