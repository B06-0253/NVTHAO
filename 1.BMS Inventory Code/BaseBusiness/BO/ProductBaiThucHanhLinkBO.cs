
using System;
using System.Collections;
using BMS.Facade;
using BMS.Model;
namespace BMS.Business
{

	
	public class ProductBaiThucHanhLinkBO : BaseBO
	{
		private ProductBaiThucHanhLinkFacade facade = ProductBaiThucHanhLinkFacade.Instance;
		protected static ProductBaiThucHanhLinkBO instance = new ProductBaiThucHanhLinkBO();

		protected ProductBaiThucHanhLinkBO()
		{
			this.baseFacade = facade;
		}

		public static ProductBaiThucHanhLinkBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	