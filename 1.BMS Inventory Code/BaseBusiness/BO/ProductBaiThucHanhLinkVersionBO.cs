
using System;
using System.Collections;
using BMS.Facade;
using BMS.Model;
namespace BMS.Business
{

	
	public class ProductBaiThucHanhLinkVersionBO : BaseBO
	{
		private ProductBaiThucHanhLinkVersionFacade facade = ProductBaiThucHanhLinkVersionFacade.Instance;
		protected static ProductBaiThucHanhLinkVersionBO instance = new ProductBaiThucHanhLinkVersionBO();

		protected ProductBaiThucHanhLinkVersionBO()
		{
			this.baseFacade = facade;
		}

		public static ProductBaiThucHanhLinkVersionBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	