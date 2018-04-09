
using System;
using System.Collections;
using BMS.Facade;
using BMS.Model;
namespace BMS.Business
{

	
	public class ModuleGroupBO : BaseBO
	{
		private ModuleGroupFacade facade = ModuleGroupFacade.Instance;
		protected static ModuleGroupBO instance = new ModuleGroupBO();

		protected ModuleGroupBO()
		{
			this.baseFacade = facade;
		}

		public static ModuleGroupBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	