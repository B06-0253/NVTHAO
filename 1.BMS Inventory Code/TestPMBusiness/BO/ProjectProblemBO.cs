
using System;
using System.Collections;
using TEST.Facade;
using TEST.Model;
namespace TEST.Business
{
	
	public class ProjectProblemBO : BaseBO
	{
		private ProjectProblemFacade facade = ProjectProblemFacade.Instance;
		protected static ProjectProblemBO instance = new ProjectProblemBO();

		protected ProjectProblemBO()
		{
			this.baseFacade = facade;
		}

		public static ProjectProblemBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	