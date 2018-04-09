
using System.Collections;
using TPA.Model;
namespace TPA.Facade
{
	
	public class ProjectDirectionFacade : BaseFacade
	{
		protected static ProjectDirectionFacade instance = new ProjectDirectionFacade(new ProjectDirectionModel());
		protected ProjectDirectionFacade(ProjectDirectionModel model) : base(model)
		{
		}
		public static ProjectDirectionFacade Instance
		{
			get { return instance; }
		}
		protected ProjectDirectionFacade():base() 
		{ 
		} 
	
	}
}
	