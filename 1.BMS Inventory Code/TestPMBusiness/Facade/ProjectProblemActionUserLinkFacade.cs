
using System.Collections;
using TEST.Model;
namespace TEST.Facade
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
	