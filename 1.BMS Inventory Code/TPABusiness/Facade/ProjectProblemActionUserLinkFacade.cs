
using System.Collections;
using TPA.Model;
namespace TPA.Facade
{
	
	public class ProjectProblemActionUserLinkFacade : BaseFacade
	{
		protected static ProjectProblemActionUserLinkFacade instance = new ProjectProblemActionUserLinkFacade(new ProjectProblemActionUserLinkModel());
		protected ProjectProblemActionUserLinkFacade(ProjectProblemActionUserLinkModel model) : base(model)
		{
		}
		public static ProjectProblemActionUserLinkFacade Instance
		{
			get { return instance; }
		}
		protected ProjectProblemActionUserLinkFacade():base() 
		{ 
		} 
	
	}
}
	