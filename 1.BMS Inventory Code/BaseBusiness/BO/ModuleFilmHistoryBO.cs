
using System;
using System.Collections;
using BMS.Facade;
using BMS.Model;
namespace BMS.Business
{

	
	public class ModuleFilmHistoryBO : BaseBO
	{
		private ModuleFilmHistoryFacade facade = ModuleFilmHistoryFacade.Instance;
		protected static ModuleFilmHistoryBO instance = new ModuleFilmHistoryBO();

		protected ModuleFilmHistoryBO()
		{
			this.baseFacade = facade;
		}

		public static ModuleFilmHistoryBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	