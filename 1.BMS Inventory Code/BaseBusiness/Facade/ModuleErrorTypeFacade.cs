
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{
	
	public class ModuleErrorTypeFacade : BaseFacade
	{
		protected static ModuleErrorTypeFacade instance = new ModuleErrorTypeFacade(new ModuleErrorTypeModel());
		protected ModuleErrorTypeFacade(ModuleErrorTypeModel model) : base(model)
		{
		}
		public static ModuleErrorTypeFacade Instance
		{
			get { return instance; }
		}
		protected ModuleErrorTypeFacade():base() 
		{ 
		} 
	
	}
}
	