
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{
	
	public class ModuleFilmFacade : BaseFacade
	{
		protected static ModuleFilmFacade instance = new ModuleFilmFacade(new ModuleFilmModel());
		protected ModuleFilmFacade(ModuleFilmModel model) : base(model)
		{
		}
		public static ModuleFilmFacade Instance
		{
			get { return instance; }
		}
		protected ModuleFilmFacade():base() 
		{ 
		} 
	
	}
}
	