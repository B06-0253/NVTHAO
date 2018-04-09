
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{
	
	public class ModuleGroupFacade : BaseFacade
	{
		protected static ModuleGroupFacade instance = new ModuleGroupFacade(new ModuleGroupModel());
		protected ModuleGroupFacade(ModuleGroupModel model) : base(model)
		{
		}
		public static ModuleGroupFacade Instance
		{
			get { return instance; }
		}
		protected ModuleGroupFacade():base() 
		{ 
		} 
	
	}
}
	