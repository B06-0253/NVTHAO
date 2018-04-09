
using System;
using System.Collections;
using BMS.Facade;
using BMS.Model;
namespace BMS.Business
{

	
	public class BaoGiaItemBO : BaseBO
	{
		private BaoGiaItemFacade facade = BaoGiaItemFacade.Instance;
		protected static BaoGiaItemBO instance = new BaoGiaItemBO();

		protected BaoGiaItemBO()
		{
			this.baseFacade = facade;
		}

		public static BaoGiaItemBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	