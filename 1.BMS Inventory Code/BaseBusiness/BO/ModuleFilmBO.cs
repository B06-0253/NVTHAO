
using System;
using System.Collections;
using BMS.Facade;
using BMS.Model;
namespace BMS.Business
{

	
	public class ModuleFilmBO : BaseBO
	{
		private ModuleFilmFacade facade = ModuleFilmFacade.Instance;
		protected static ModuleFilmBO instance = new ModuleFilmBO();

		protected ModuleFilmBO()
		{
			this.baseFacade = facade;
		}

		public static ModuleFilmBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	