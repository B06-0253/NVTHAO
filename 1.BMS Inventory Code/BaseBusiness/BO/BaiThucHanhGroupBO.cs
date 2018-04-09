
using System;
using System.Collections;
using BMS.Facade;
using BMS.Model;
namespace BMS.Business
{

	
	public class BaiThucHanhGroupBO : BaseBO
	{
		private BaiThucHanhGroupFacade facade = BaiThucHanhGroupFacade.Instance;
		protected static BaiThucHanhGroupBO instance = new BaiThucHanhGroupBO();

		protected BaiThucHanhGroupBO()
		{
			this.baseFacade = facade;
		}

		public static BaiThucHanhGroupBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	