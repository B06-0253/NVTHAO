
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{
	
	public class BaiThucHanhGroupFacade : BaseFacade
	{
		protected static BaiThucHanhGroupFacade instance = new BaiThucHanhGroupFacade(new BaiThucHanhGroupModel());
		protected BaiThucHanhGroupFacade(BaiThucHanhGroupModel model) : base(model)
		{
		}
		public static BaiThucHanhGroupFacade Instance
		{
			get { return instance; }
		}
		protected BaiThucHanhGroupFacade():base() 
		{ 
		} 
	
	}
}
	