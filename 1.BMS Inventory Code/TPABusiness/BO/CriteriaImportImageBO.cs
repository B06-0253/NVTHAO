
using System;
using System.Collections;
using TPA.Facade;
using TPA.Model;
namespace TPA.Business
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
	