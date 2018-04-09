
using System;
using System.Collections;
using TEST.Facade;
using TEST.Model;
namespace TEST.Business
{
	
	public class ProjectProblemImageBO : BaseBO
	{
		private ProjectProblemImageFacade facade = ProjectProblemImageFacade.Instance;
		protected static ProjectProblemImageBO instance = new ProjectProblemImageBO();

		protected ProjectProblemImageBO()
		{
			this.baseFacade = facade;
		}

		public static ProjectProblemImageBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	