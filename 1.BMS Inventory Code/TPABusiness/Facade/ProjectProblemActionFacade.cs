
using System.Collections;
using TPA.Model;
namespace TPA.Facade
{
	
	public class ProjectProblemActionFacade : BaseFacade
	{
		protected static ProjectProblemActionFacade instance = new ProjectProblemActionFacade(new ProjectProblemActionModel());
		protected ProjectProblemActionFacade(ProjectProblemActionModel model) : base(model)
		{
		}
		public static ProjectProblemActionFacade Instance
		{
			get { return instance; }
		}
		protected ProjectProblemActionFacade():base() 
		{ 
		} 
	
	}
}
	