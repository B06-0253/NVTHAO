
using System;
using System.Collections;
using BMS.Facade;
using BMS.Model;
namespace BMS.Business
{

	
	public class BaiThucHanhModuleVersionBO : BaseBO
	{
		private BaiThucHanhModuleVersionFacade facade = BaiThucHanhModuleVersionFacade.Instance;
		protected static BaiThucHanhModuleVersionBO instance = new BaiThucHanhModuleVersionBO();

		protected BaiThucHanhModuleVersionBO()
		{
			this.baseFacade = facade;
		}

		public static BaiThucHanhModuleVersionBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	