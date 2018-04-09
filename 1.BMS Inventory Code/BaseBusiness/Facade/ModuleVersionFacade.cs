
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{
	
	public class ModuleVersionFacade : BaseFacade
	{
		protected static ModuleVersionFacade instance = new ModuleVersionFacade(new ModuleVersionModel());
		protected ModuleVersionFacade(ModuleVersionModel model) : base(model)
		{
		}
		public static ModuleVersionFacade Instance
		{
			get { return instance; }
		}
		protected ModuleVersionFacade():base() 
		{ 
		} 
	
	}
}
	