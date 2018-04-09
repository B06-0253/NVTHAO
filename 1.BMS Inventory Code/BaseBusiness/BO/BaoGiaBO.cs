
using System;
using System.Collections;
using BMS.Facade;
using BMS.Model;
namespace BMS.Business
{

	
	public class BaoGiaBO : BaseBO
	{
		private BaoGiaFacade facade = BaoGiaFacade.Instance;
		protected static BaoGiaBO instance = new BaoGiaBO();

		protected BaoGiaBO()
		{
			this.baseFacade = facade;
		}

		public static BaoGiaBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	