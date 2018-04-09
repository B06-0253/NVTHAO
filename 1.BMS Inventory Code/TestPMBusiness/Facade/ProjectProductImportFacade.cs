
using System.Collections;
using TEST.Model;
namespace TEST.Facade
{
	
	public class ProjectProductImportFacade : BaseFacade
	{
		protected static ProjectProductImportFacade instance = new ProjectProductImportFacade(new ProjectProductImportModel());
		protected ProjectProductImportFacade(ProjectProductImportModel model) : base(model)
		{
		}
		public static ProjectProductImportFacade Instance
		{
			get { return instance; }
		}
		protected ProjectProductImportFacade():base() 
		{ 
		} 
	
	}
}
	