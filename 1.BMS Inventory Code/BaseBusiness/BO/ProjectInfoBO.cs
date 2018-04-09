
using System;
using System.Collections;
using BMS.Facade;
using BMS.Model;
namespace BMS.Business
{

	
	public class ProjectInfoBO : BaseBO
	{
		private ProjectInfoFacade facade = ProjectInfoFacade.Instance;
		protected static ProjectInfoBO instance = new ProjectInfoBO();

		protected ProjectInfoBO()
		{
			this.baseFacade = facade;
		}

		public static ProjectInfoBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	