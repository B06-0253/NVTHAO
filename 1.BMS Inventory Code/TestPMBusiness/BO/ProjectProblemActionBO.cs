
using System;
using System.Collections;
using TEST.Facade;
using TEST.Model;
namespace TEST.Business
{
	
	public class ProjectProblemActionBO : BaseBO
	{
		private ProjectProblemActionFacade facade = ProjectProblemActionFacade.Instance;
		protected static ProjectProblemActionBO instance = new ProjectProblemActionBO();

		protected ProjectProblemActionBO()
		{
			this.baseFacade = facade;
		}

		public static ProjectProblemActionBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	