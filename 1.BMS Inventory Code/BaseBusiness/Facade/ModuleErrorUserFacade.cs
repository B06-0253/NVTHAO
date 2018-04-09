
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{
	
	public class ModuleErrorUserFacade : BaseFacade
	{
		protected static ModuleErrorUserFacade instance = new ModuleErrorUserFacade(new ModuleErrorUserModel());
		protected ModuleErrorUserFacade(ModuleErrorUserModel model) : base(model)
		{
		}
		public static ModuleErrorUserFacade Instance
		{
			get { return instance; }
		}
		protected ModuleErrorUserFacade():base() 
		{ 
		} 
	
	}
}
	