
using System;
using System.Collections;
using TPA.Facade;
using TPA.Model;
namespace TPA.Business
{
	
	public class ProjectProblemActionUserLinkBO : BaseBO
	{
		private ProjectProblemActionUserLinkFacade facade = ProjectProblemActionUserLinkFacade.Instance;
		protected static ProjectProblemActionUserLinkBO instance = new ProjectProblemActionUserLinkBO();

		protected ProjectProblemActionUserLinkBO()
		{
			this.baseFacade = facade;
		}

		public static ProjectProblemActionUserLinkBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	