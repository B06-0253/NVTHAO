
using System;
using System.Collections;
using TEST.Facade;
using TEST.Model;
namespace TEST.Business
{
	
	public class ProjectModuleBO : BaseBO
	{
		private ProjectModuleFacade facade = ProjectModuleFacade.Instance;
		protected static ProjectModuleBO instance = new ProjectModuleBO();

		protected ProjectModuleBO()
		{
			this.baseFacade = facade;
		}

		public static ProjectModuleBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	