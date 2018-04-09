
using System.Collections;
using TEST.Model;
namespace TEST.Facade
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
	