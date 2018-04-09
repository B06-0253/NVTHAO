
using System;
using System.Collections;
using BMS.Facade;
using BMS.Model;
namespace BMS.Business
{

	
	public class CoCauGroupBO : BaseBO
	{
		private CoCauGroupFacade facade = CoCauGroupFacade.Instance;
		protected static CoCauGroupBO instance = new CoCauGroupBO();

		protected CoCauGroupBO()
		{
			this.baseFacade = facade;
		}

		public static CoCauGroupBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	