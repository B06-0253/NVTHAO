
using System.Collections;
using TEST.Model;
namespace TEST.Facade
{
	
	public class ProjectFacade : BaseFacade
	{
		protected static ProjectFacade instance = new ProjectFacade(new ProjectModel());
		protected ProjectFacade(ProjectModel model) : base(model)
		{
		}
		public static ProjectFacade Instance
		{
			get { return instance; }
		}
		protected ProjectFacade():base() 
		{ 
		} 
	
	}
}
	