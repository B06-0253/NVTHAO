
using System.Collections;
using TEST.Model;
namespace TEST.Facade
{
	
	public class ProjectDirectionDetailFacade : BaseFacade
	{
		protected static ProjectDirectionDetailFacade instance = new ProjectDirectionDetailFacade(new ProjectDirectionDetailModel());
		protected ProjectDirectionDetailFacade(ProjectDirectionDetailModel model) : base(model)
		{
		}
		public static ProjectDirectionDetailFacade Instance
		{
			get { return instance; }
		}
		protected ProjectDirectionDetailFacade():base() 
		{ 
		} 
	
	}
}
	