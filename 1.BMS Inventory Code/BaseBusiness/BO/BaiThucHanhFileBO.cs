
using System;
using System.Collections;
using BMS.Facade;
using BMS.Model;
namespace BMS.Business
{

	
	public class BaiThucHanhFileBO : BaseBO
	{
		private BaiThucHanhFileFacade facade = BaiThucHanhFileFacade.Instance;
		protected static BaiThucHanhFileBO instance = new BaiThucHanhFileBO();

		protected BaiThucHanhFileBO()
		{
			this.baseFacade = facade;
		}

		public static BaiThucHanhFileBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	