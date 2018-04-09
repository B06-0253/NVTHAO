
using System;
using System.Collections;
using TEST.Facade;
using TEST.Model;
namespace TEST.Business
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
	