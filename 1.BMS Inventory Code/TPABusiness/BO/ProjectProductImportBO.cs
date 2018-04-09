
using System;
using System.Collections;
using TPA.Facade;
using TPA.Model;
namespace TPA.Business
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
	