
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{
	
	public class ModuleTemFacade : BaseFacade
	{
		protected static ModuleTemFacade instance = new ModuleTemFacade(new ModuleTemModel());
		protected ModuleTemFacade(ModuleTemModel model) : base(model)
		{
		}
		public static ModuleTemFacade Instance
		{
			get { return instance; }
		}
		protected ModuleTemFacade():base() 
		{ 
		} 
	
	}
}
	