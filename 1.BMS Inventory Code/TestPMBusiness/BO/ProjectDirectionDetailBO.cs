
using System;
using System.Collections;
using TEST.Facade;
using TEST.Model;
namespace TEST.Business
{
	
	public class ProjectDirectionDetailBO : BaseBO
	{
		private ProjectDirectionDetailFacade facade = ProjectDirectionDetailFacade.Instance;
		protected static ProjectDirectionDetailBO instance = new ProjectDirectionDetailBO();

		protected ProjectDirectionDetailBO()
		{
			this.baseFacade = facade;
		}

		public static ProjectDirectionDetailBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	