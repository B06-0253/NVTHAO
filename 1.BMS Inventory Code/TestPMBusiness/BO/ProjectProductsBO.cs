
using System;
using System.Collections;
using TEST.Facade;
using TEST.Model;
namespace TEST.Business
{
	
	public class ProjectProductsBO : BaseBO
	{
		private ProjectProductsFacade facade = ProjectProductsFacade.Instance;
		protected static ProjectProductsBO instance = new ProjectProductsBO();

		protected ProjectProductsBO()
		{
			this.baseFacade = facade;
		}

		public static ProjectProductsBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	