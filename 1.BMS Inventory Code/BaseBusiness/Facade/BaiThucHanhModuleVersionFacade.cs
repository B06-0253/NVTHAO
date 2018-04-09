
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{
	
	public class BaiThucHanhModuleVersionFacade : BaseFacade
	{
		protected static BaiThucHanhModuleVersionFacade instance = new BaiThucHanhModuleVersionFacade(new BaiThucHanhModuleVersionModel());
		protected BaiThucHanhModuleVersionFacade(BaiThucHanhModuleVersionModel model) : base(model)
		{
		}
		public static BaiThucHanhModuleVersionFacade Instance
		{
			get { return instance; }
		}
		protected BaiThucHanhModuleVersionFacade():base() 
		{ 
		} 
	
	}
}
	