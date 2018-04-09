
using System;
using System.Collections;
using BMS.Facade;
using BMS.Model;
namespace BMS.Business
{

	
	public class BaiThucHanhModuleBO : BaseBO
	{
		private BaiThucHanhModuleFacade facade = BaiThucHanhModuleFacade.Instance;
		protected static BaiThucHanhModuleBO instance = new BaiThucHanhModuleBO();

		protected BaiThucHanhModuleBO()
		{
			this.baseFacade = facade;
		}

		public static BaiThucHanhModuleBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	