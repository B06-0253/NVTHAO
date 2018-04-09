
using System;
using System.Collections;
using TEST.Facade;
using TEST.Model;
namespace TEST.Business
{
	
	public class ProductPartsImportBO : BaseBO
	{
		private ProductPartsImportFacade facade = ProductPartsImportFacade.Instance;
		protected static ProductPartsImportBO instance = new ProductPartsImportBO();

		protected ProductPartsImportBO()
		{
			this.baseFacade = facade;
		}

		public static ProductPartsImportBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	