
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{
	
	public class ModulesFacade : BaseFacade
	{
		protected static ModulesFacade instance = new ModulesFacade(new ModulesModel());
		protected ModulesFacade(ModulesModel model) : base(model)
		{
		}
		public static ModulesFacade Instance
		{
			get { return instance; }
		}
		protected ModulesFacade():base() 
		{ 
		} 
	
	}
}
	