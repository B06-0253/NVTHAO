
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{
	
	public class ModuleTemHistoryFacade : BaseFacade
	{
		protected static ModuleTemHistoryFacade instance = new ModuleTemHistoryFacade(new ModuleTemHistoryModel());
		protected ModuleTemHistoryFacade(ModuleTemHistoryModel model) : base(model)
		{
		}
		public static ModuleTemHistoryFacade Instance
		{
			get { return instance; }
		}
		protected ModuleTemHistoryFacade():base() 
		{ 
		} 
	
	}
}
	