
using System;
using System.Collections;
using TPA.Facade;
using TPA.Model;
namespace TPA.Business
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
	