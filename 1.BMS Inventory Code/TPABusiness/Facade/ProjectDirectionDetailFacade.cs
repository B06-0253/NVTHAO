
using System.Collections;
using TPA.Model;
namespace TPA.Facade
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
	