
using System.Collections;
using TPA.Model;
namespace TPA.Facade
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
	