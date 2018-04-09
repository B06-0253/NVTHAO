
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{
	
	public class ProductBaiThucHanhLinkVersionFacade : BaseFacade
	{
		protected static ProductBaiThucHanhLinkVersionFacade instance = new ProductBaiThucHanhLinkVersionFacade(new ProductBaiThucHanhLinkVersionModel());
		protected ProductBaiThucHanhLinkVersionFacade(ProductBaiThucHanhLinkVersionModel model) : base(model)
		{
		}
		public static ProductBaiThucHanhLinkVersionFacade Instance
		{
			get { return instance; }
		}
		protected ProductBaiThucHanhLinkVersionFacade():base() 
		{ 
		} 
	
	}
}
	