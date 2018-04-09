
using System;
using System.Collections;
using TEST.Facade;
using TEST.Model;
namespace TEST.Business
{
	
	public class ProjectDirectionBO : BaseBO
	{
		private ProjectDirectionFacade facade = ProjectDirectionFacade.Instance;
		protected static ProjectDirectionBO instance = new ProjectDirectionBO();

		protected ProjectDirectionBO()
		{
			this.baseFacade = facade;
		}

		public static ProjectDirectionBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	