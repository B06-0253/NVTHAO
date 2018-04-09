
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{
	
	public class ProjectInfoFacade : BaseFacade
	{
		protected static ProjectInfoFacade instance = new ProjectInfoFacade(new ProjectInfoModel());
		protected ProjectInfoFacade(ProjectInfoModel model) : base(model)
		{
		}
		public static ProjectInfoFacade Instance
		{
			get { return instance; }
		}
		protected ProjectInfoFacade():base() 
		{ 
		} 
	
	}
}
	