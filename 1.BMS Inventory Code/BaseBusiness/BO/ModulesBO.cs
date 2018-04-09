
using System;
using System.Collections;
using BMS.Facade;
using BMS.Model;
namespace BMS.Business
{

	
	public class ModulesBO : BaseBO
	{
		private ModulesFacade facade = ModulesFacade.Instance;
		protected static ModulesBO instance = new ModulesBO();

		protected ModulesBO()
		{
			this.baseFacade = facade;
		}

		public static ModulesBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	