
using System;
using System.Collections;
using TPA.Facade;
using TPA.Model;
namespace TPA.Business
{
	
	public class ProjectStatusBO : BaseBO
	{
		private ProjectStatusFacade facade = ProjectStatusFacade.Instance;
		protected static ProjectStatusBO instance = new ProjectStatusBO();

		protected ProjectStatusBO()
		{
			this.baseFacade = facade;
		}

		public static ProjectStatusBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	