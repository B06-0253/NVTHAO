
using System;
using System.Collections;
using BMS.Facade;
using BMS.Model;
namespace BMS.Business
{

	
	public class BaiThucHanhVersionBO : BaseBO
	{
		private BaiThucHanhVersionFacade facade = BaiThucHanhVersionFacade.Instance;
		protected static BaiThucHanhVersionBO instance = new BaiThucHanhVersionBO();

		protected BaiThucHanhVersionBO()
		{
			this.baseFacade = facade;
		}

		public static BaiThucHanhVersionBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	