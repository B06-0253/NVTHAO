
using System.Collections;
using TPA.Model;
namespace TPA.Facade
{
	
	public class ProjectStatusFacade : BaseFacade
	{
		protected static ProjectStatusFacade instance = new ProjectStatusFacade(new ProjectStatusModel());
		protected ProjectStatusFacade(ProjectStatusModel model) : base(model)
		{
		}
		public static ProjectStatusFacade Instance
		{
			get { return instance; }
		}
		protected ProjectStatusFacade():base() 
		{ 
		} 
	
	}
}
	