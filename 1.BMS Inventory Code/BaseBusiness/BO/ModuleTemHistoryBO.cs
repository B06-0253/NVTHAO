
using System;
using System.Collections;
using BMS.Facade;
using BMS.Model;
namespace BMS.Business
{

	
	public class ModuleTemHistoryBO : BaseBO
	{
		private ModuleTemHistoryFacade facade = ModuleTemHistoryFacade.Instance;
		protected static ModuleTemHistoryBO instance = new ModuleTemHistoryBO();

		protected ModuleTemHistoryBO()
		{
			this.baseFacade = facade;
		}

		public static ModuleTemHistoryBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	