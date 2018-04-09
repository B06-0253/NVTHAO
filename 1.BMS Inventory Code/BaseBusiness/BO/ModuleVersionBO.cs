
using System;
using System.Collections;
using BMS.Facade;
using BMS.Model;
namespace BMS.Business
{

	
	public class ModuleVersionBO : BaseBO
	{
		private ModuleVersionFacade facade = ModuleVersionFacade.Instance;
		protected static ModuleVersionBO instance = new ModuleVersionBO();

		protected ModuleVersionBO()
		{
			this.baseFacade = facade;
		}

		public static ModuleVersionBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	