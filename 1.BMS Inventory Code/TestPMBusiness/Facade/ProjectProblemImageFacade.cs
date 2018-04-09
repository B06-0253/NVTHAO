
using System.Collections;
using TEST.Model;
namespace TEST.Facade
{
	
	public class ProjectProblemImageFacade : BaseFacade
	{
		protected static ProjectProblemImageFacade instance = new ProjectProblemImageFacade(new ProjectProblemImageModel());
		protected ProjectProblemImageFacade(ProjectProblemImageModel model) : base(model)
		{
		}
		public static ProjectProblemImageFacade Instance
		{
			get { return instance; }
		}
		protected ProjectProblemImageFacade():base() 
		{ 
		} 
	
	}
}
	