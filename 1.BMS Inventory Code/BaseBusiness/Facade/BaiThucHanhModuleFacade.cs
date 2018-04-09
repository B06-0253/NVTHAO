
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{
	
	public class BaiThucHanhModuleFacade : BaseFacade
	{
		protected static BaiThucHanhModuleFacade instance = new BaiThucHanhModuleFacade(new BaiThucHanhModuleModel());
		protected BaiThucHanhModuleFacade(BaiThucHanhModuleModel model) : base(model)
		{
		}
		public static BaiThucHanhModuleFacade Instance
		{
			get { return instance; }
		}
		protected BaiThucHanhModuleFacade():base() 
		{ 
		} 
	
	}
}
	