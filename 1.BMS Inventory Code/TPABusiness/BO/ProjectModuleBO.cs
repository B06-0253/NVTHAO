
using System;
using System.Collections;
using TPA.Facade;
using TPA.Model;
namespace TPA.Business
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
	