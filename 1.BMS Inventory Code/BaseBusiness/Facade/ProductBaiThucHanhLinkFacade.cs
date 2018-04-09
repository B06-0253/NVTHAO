
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{
	
	public class ProductBaiThucHanhLinkFacade : BaseFacade
	{
		protected static ProductBaiThucHanhLinkFacade instance = new ProductBaiThucHanhLinkFacade(new ProductBaiThucHanhLinkModel());
		protected ProductBaiThucHanhLinkFacade(ProductBaiThucHanhLinkModel model) : base(model)
		{
		}
		public static ProductBaiThucHanhLinkFacade Instance
		{
			get { return instance; }
		}
		protected ProductBaiThucHanhLinkFacade():base() 
		{ 
		} 
	
	}
}
	