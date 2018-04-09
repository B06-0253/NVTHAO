
using System;
using System.Collections;
using TEST.Facade;
using TEST.Model;
namespace TEST.Business
{
	
	public class ProjectProductImportBO : BaseBO
	{
		private ProjectProductImportFacade facade = ProjectProductImportFacade.Instance;
		protected static ProjectProductImportBO instance = new ProjectProductImportBO();

		protected ProjectProductImportBO()
		{
			this.baseFacade = facade;
		}

		public static ProjectProductImportBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	