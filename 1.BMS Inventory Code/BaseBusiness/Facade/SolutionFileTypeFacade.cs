
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{
	
	public class SolutionFileTypeFacade : BaseFacade
	{
		protected static SolutionFileTypeFacade instance = new SolutionFileTypeFacade(new SolutionFileTypeModel());
		protected SolutionFileTypeFacade(SolutionFileTypeModel model) : base(model)
		{
		}
		public static SolutionFileTypeFacade Instance
		{
			get { return instance; }
		}
		protected SolutionFileTypeFacade():base() 
		{ 
		} 
	
	}
}
	