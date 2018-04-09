
using System;
using System.Collections;
using TPA.Facade;
using TPA.Model;
namespace TPA.Business
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
	