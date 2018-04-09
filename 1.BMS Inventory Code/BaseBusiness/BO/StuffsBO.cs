
using System;
using System.Collections;
using BMS.Facade;
using BMS.Model;
namespace BMS.Business
{

	
	public class StuffsBO : BaseBO
	{
		private StuffsFacade facade = StuffsFacade.Instance;
		protected static StuffsBO instance = new StuffsBO();

		protected StuffsBO()
		{
			this.baseFacade = facade;
		}

		public static StuffsBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	