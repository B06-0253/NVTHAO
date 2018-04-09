
using System.Collections;
using TPA.Model;
namespace TPA.Facade
{
	
	public class WorkingDiariesLocationFacade : BaseFacade
	{
		protected static WorkingDiariesLocationFacade instance = new WorkingDiariesLocationFacade(new WorkingDiariesLocationModel());
		protected WorkingDiariesLocationFacade(WorkingDiariesLocationModel model) : base(model)
		{
		}
		public static WorkingDiariesLocationFacade Instance
		{
			get { return instance; }
		}
		protected WorkingDiariesLocationFacade():base() 
		{ 
		} 
	
	}
}
	