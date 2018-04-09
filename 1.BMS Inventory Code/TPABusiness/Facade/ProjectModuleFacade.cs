
using System.Collections;
using TPA.Model;
namespace TPA.Facade
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
	