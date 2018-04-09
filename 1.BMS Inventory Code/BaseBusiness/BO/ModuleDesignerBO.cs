
using System;
using System.Collections;
using BMS.Facade;
using BMS.Model;
namespace BMS.Business
{

	
	public class ModuleDesignerBO : BaseBO
	{
		private ModuleDesignerFacade facade = ModuleDesignerFacade.Instance;
		protected static ModuleDesignerBO instance = new ModuleDesignerBO();

		protected ModuleDesignerBO()
		{
			this.baseFacade = facade;
		}

		public static ModuleDesignerBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	