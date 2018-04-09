
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{
	
	public class ModulePartFacade : BaseFacade
	{
		protected static ModulePartFacade instance = new ModulePartFacade(new ModulePartModel());
		protected ModulePartFacade(ModulePartModel model) : base(model)
		{
		}
		public static ModulePartFacade Instance
		{
			get { return instance; }
		}
		protected ModulePartFacade():base() 
		{ 
		} 
	
	}
}
	