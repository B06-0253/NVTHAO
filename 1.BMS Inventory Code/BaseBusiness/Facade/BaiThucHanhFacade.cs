
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{
	
	public class BaiThucHanhFacade : BaseFacade
	{
		protected static BaiThucHanhFacade instance = new BaiThucHanhFacade(new BaiThucHanhModel());
		protected BaiThucHanhFacade(BaiThucHanhModel model) : base(model)
		{
		}
		public static BaiThucHanhFacade Instance
		{
			get { return instance; }
		}
		protected BaiThucHanhFacade():base() 
		{ 
		} 
	
	}
}
	