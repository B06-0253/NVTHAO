
using System;
using System.Collections;
using TPA.Facade;
using TPA.Model;
namespace TPA.Business
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
	