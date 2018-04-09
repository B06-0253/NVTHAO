
using System;
using System.Collections;
using BMS.Facade;
using BMS.Model;
namespace BMS.Business
{

	
	public class ModuleErrorUserBO : BaseBO
	{
		private ModuleErrorUserFacade facade = ModuleErrorUserFacade.Instance;
		protected static ModuleErrorUserBO instance = new ModuleErrorUserBO();

		protected ModuleErrorUserBO()
		{
			this.baseFacade = facade;
		}

		public static ModuleErrorUserBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	