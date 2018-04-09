
using System;
using System.Collections;
using BMS.Facade;
using BMS.Model;
namespace BMS.Business
{

	
	public class ModuleTemBO : BaseBO
	{
		private ModuleTemFacade facade = ModuleTemFacade.Instance;
		protected static ModuleTemBO instance = new ModuleTemBO();

		protected ModuleTemBO()
		{
			this.baseFacade = facade;
		}

		public static ModuleTemBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	