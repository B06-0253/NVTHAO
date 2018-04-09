
using System.Collections;
using TEST.Model;
namespace TEST.Facade
{
	
	public class ProjectProductsFacade : BaseFacade
	{
		protected static ProjectProductsFacade instance = new ProjectProductsFacade(new ProjectProductsModel());
		protected ProjectProductsFacade(ProjectProductsModel model) : base(model)
		{
		}
		public static ProjectProductsFacade Instance
		{
			get { return instance; }
		}
		protected ProjectProductsFacade():base() 
		{ 
		} 
	
	}
}
	