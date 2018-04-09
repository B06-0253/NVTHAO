
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{
	
	public class ModuleErrorImageFacade : BaseFacade
	{
		protected static ModuleErrorImageFacade instance = new ModuleErrorImageFacade(new ModuleErrorImageModel());
		protected ModuleErrorImageFacade(ModuleErrorImageModel model) : base(model)
		{
		}
		public static ModuleErrorImageFacade Instance
		{
			get { return instance; }
		}
		protected ModuleErrorImageFacade():base() 
		{ 
		} 
	
	}
}
	