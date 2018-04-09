
using System;
using System.Collections;
using BMS.Facade;
using BMS.Model;
namespace BMS.Business
{

	
	public class BaoGiaDiffBO : BaseBO
	{
		private BaoGiaDiffFacade facade = BaoGiaDiffFacade.Instance;
		protected static BaoGiaDiffBO instance = new BaoGiaDiffBO();

		protected BaoGiaDiffBO()
		{
			this.baseFacade = facade;
		}

		public static BaoGiaDiffBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	