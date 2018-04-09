
using System;
using System.Collections;
using BMS.Facade;
using BMS.Model;
namespace BMS.Business
{

	
	public class CoCauMauBO : BaseBO
	{
		private CoCauMauFacade facade = CoCauMauFacade.Instance;
		protected static CoCauMauBO instance = new CoCauMauBO();

		protected CoCauMauBO()
		{
			this.baseFacade = facade;
		}

		public static CoCauMauBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	