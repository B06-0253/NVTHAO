
using System;
using System.Collections;
using BMS.Facade;
using BMS.Model;
namespace BMS.Business
{

	
	public class ModuleErrorBO : BaseBO
	{
		private ModuleErrorFacade facade = ModuleErrorFacade.Instance;
		protected static ModuleErrorBO instance = new ModuleErrorBO();

		protected ModuleErrorBO()
		{
			this.baseFacade = facade;
		}

		public static ModuleErrorBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	