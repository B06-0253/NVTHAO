
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{
	
	public class ModuleFilmHistoryFacade : BaseFacade
	{
		protected static ModuleFilmHistoryFacade instance = new ModuleFilmHistoryFacade(new ModuleFilmHistoryModel());
		protected ModuleFilmHistoryFacade(ModuleFilmHistoryModel model) : base(model)
		{
		}
		public static ModuleFilmHistoryFacade Instance
		{
			get { return instance; }
		}
		protected ModuleFilmHistoryFacade():base() 
		{ 
		} 
	
	}
}
	