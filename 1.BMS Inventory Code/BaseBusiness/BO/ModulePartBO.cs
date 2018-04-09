
using System;
using System.Collections;
using BMS.Facade;
using BMS.Model;
namespace BMS.Business
{

	
	public class ModulePartBO : BaseBO
	{
		private ModulePartFacade facade = ModulePartFacade.Instance;
		protected static ModulePartBO instance = new ModulePartBO();

		protected ModulePartBO()
		{
			this.baseFacade = facade;
		}

		public static ModulePartBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	