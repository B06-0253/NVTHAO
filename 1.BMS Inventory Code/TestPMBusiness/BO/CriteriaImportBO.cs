
using System;
using System.Collections;
using TEST.Facade;
using TEST.Model;
namespace TEST.Business
{
	
	public class CriteriaImportBO : BaseBO
	{
		private CriteriaImportFacade facade = CriteriaImportFacade.Instance;
		protected static CriteriaImportBO instance = new CriteriaImportBO();

		protected CriteriaImportBO()
		{
			this.baseFacade = facade;
		}

		public static CriteriaImportBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	