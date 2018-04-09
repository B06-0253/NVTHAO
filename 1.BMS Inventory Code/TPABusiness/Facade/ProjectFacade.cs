
using System.Collections;
using TPA.Model;
namespace TPA.Facade
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
	