
using System;
using System.Collections;
using TPA.Facade;
using TPA.Model;
namespace TPA.Business
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
	