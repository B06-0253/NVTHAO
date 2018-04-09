
using System.Collections;
using TEST.Model;
namespace TEST.Facade
{
	
	public class ProjectModuleFacade : BaseFacade
	{
		protected static ProjectModuleFacade instance = new ProjectModuleFacade(new ProjectModuleModel());
		protected ProjectModuleFacade(ProjectModuleModel model) : base(model)
		{
		}
		public static ProjectModuleFacade Instance
		{
			get { return instance; }
		}
		protected ProjectModuleFacade():base() 
		{ 
		} 
	
	}
}
	