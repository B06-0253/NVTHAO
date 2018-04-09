
using System;
using System.Collections;
using TPA.Facade;
using TPA.Model;
namespace TPA.Business
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
	