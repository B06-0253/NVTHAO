
using System;
using System.Collections;
using TPA.Facade;
using TPA.Model;
namespace TPA.Business
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
	