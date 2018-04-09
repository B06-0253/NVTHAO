
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{
	
	public class ModuleDesignerFacade : BaseFacade
	{
		protected static ModuleDesignerFacade instance = new ModuleDesignerFacade(new ModuleDesignerModel());
		protected ModuleDesignerFacade(ModuleDesignerModel model) : base(model)
		{
		}
		public static ModuleDesignerFacade Instance
		{
			get { return instance; }
		}
		protected ModuleDesignerFacade():base() 
		{ 
		} 
	
	}
}
	