
using System;
using System.Collections;
using BMS.Utils;
using BMS.Facade;
using BMS.Model;
namespace BMS.Business
{	
	public class ProjectsBO : BaseBO
	{
		private ProjectsFacade facade = ProjectsFacade.Instance;
		protected static ProjectsBO instance = new ProjectsBO();

		protected ProjectsBO()
		{
			this.baseFacade = facade;
		}

		public static ProjectsBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	