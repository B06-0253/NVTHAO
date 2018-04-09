
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{
	
	public class ModuleErrorFacade : BaseFacade
	{
		protected static ModuleErrorFacade instance = new ModuleErrorFacade(new ModuleErrorModel());
		protected ModuleErrorFacade(ModuleErrorModel model) : base(model)
		{
		}
		public static ModuleErrorFacade Instance
		{
			get { return instance; }
		}
		protected ModuleErrorFacade():base() 
		{ 
		} 
	
	}
}
	