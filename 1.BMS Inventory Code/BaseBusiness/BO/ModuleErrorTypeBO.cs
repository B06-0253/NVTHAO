
using System;
using System.Collections;
using BMS.Facade;
using BMS.Model;
namespace BMS.Business
{

	
	public class ModuleErrorTypeBO : BaseBO
	{
		private ModuleErrorTypeFacade facade = ModuleErrorTypeFacade.Instance;
		protected static ModuleErrorTypeBO instance = new ModuleErrorTypeBO();

		protected ModuleErrorTypeBO()
		{
			this.baseFacade = facade;
		}

		public static ModuleErrorTypeBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	