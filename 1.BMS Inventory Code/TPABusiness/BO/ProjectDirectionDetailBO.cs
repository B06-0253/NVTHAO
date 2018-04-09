
using System;
using System.Collections;
using TPA.Facade;
using TPA.Model;
namespace TPA.Business
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
	