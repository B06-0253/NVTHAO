
using System.Collections;
using TPA.Model;
namespace TPA.Facade
{
	
	public class ProjectDirectionTypeFacade : BaseFacade
	{
		protected static ProjectDirectionTypeFacade instance = new ProjectDirectionTypeFacade(new ProjectDirectionTypeModel());
		protected ProjectDirectionTypeFacade(ProjectDirectionTypeModel model) : base(model)
		{
		}
		public static ProjectDirectionTypeFacade Instance
		{
			get { return instance; }
		}
		protected ProjectDirectionTypeFacade():base() 
		{ 
		} 
	
	}
}
	