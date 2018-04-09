
using System;
using System.Collections;
using TEST.Facade;
using TEST.Model;
namespace TEST.Business
{
	
	public class CriteriaImportImageBO : BaseBO
	{
		private CriteriaImportImageFacade facade = CriteriaImportImageFacade.Instance;
		protected static CriteriaImportImageBO instance = new CriteriaImportImageBO();

		protected CriteriaImportImageBO()
		{
			this.baseFacade = facade;
		}

		public static CriteriaImportImageBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	