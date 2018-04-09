
using System;
using System.Collections;
using BMS.Facade;
using BMS.Model;
namespace BMS.Business
{

	
	public class BaiThucHanhBO : BaseBO
	{
		private BaiThucHanhFacade facade = BaiThucHanhFacade.Instance;
		protected static BaiThucHanhBO instance = new BaiThucHanhBO();

		protected BaiThucHanhBO()
		{
			this.baseFacade = facade;
		}

		public static BaiThucHanhBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	