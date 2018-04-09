
using System;
using System.Collections;
using TPA.Facade;
using TPA.Model;
namespace TPA.Business
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
	