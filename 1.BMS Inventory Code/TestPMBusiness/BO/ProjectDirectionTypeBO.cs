
using System;
using System.Collections;
using TEST.Facade;
using TEST.Model;
namespace TEST.Business
{
	
	public class ProjectDirectionTypeBO : BaseBO
	{
		private ProjectDirectionTypeFacade facade = ProjectDirectionTypeFacade.Instance;
		protected static ProjectDirectionTypeBO instance = new ProjectDirectionTypeBO();

        protected ProjectDirectionTypeBO()
		{
			this.baseFacade = facade;
		}

        public static ProjectDirectionTypeBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	