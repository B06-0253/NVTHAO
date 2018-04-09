
using System.Collections;
using TPA.Model;
namespace TPA.Facade
{
	
	public class WorkingDiariesFacade : BaseFacade
	{
		protected static WorkingDiariesFacade instance = new WorkingDiariesFacade(new WorkingDiariesModel());
		protected WorkingDiariesFacade(WorkingDiariesModel model) : base(model)
		{
		}
		public static WorkingDiariesFacade Instance
		{
			get { return instance; }
		}
		protected WorkingDiariesFacade():base() 
		{ 
		} 
	
	}
}
	