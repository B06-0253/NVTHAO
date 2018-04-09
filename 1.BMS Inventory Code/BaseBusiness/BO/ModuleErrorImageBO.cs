
using System;
using System.Collections;
using BMS.Facade;
using BMS.Model;
namespace BMS.Business
{

	
	public class ModuleErrorImageBO : BaseBO
	{
		private ModuleErrorImageFacade facade = ModuleErrorImageFacade.Instance;
		protected static ModuleErrorImageBO instance = new ModuleErrorImageBO();

		protected ModuleErrorImageBO()
		{
			this.baseFacade = facade;
		}

		public static ModuleErrorImageBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	