
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{
	
	public class ProjectSynFacade : BaseFacade
	{
		protected static ProjectSynFacade instance = new ProjectSynFacade(new ProjectSynModel());
		protected ProjectSynFacade(ProjectSynModel model) : base(model)
		{
		}
		public static ProjectSynFacade Instance
		{
			get { return instance; }
		}
		protected ProjectSynFacade():base() 
		{ 
		} 
	
	}
}
	