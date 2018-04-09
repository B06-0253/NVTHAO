
using System.Collections;
using TPA.Model;
namespace TPA.Facade
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
	