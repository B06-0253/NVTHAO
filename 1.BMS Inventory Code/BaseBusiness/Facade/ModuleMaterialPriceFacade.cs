
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{
	
	public class ModuleMaterialPriceFacade : BaseFacade
	{
		protected static ModuleMaterialPriceFacade instance = new ModuleMaterialPriceFacade(new ModuleMaterialPriceModel());
		protected ModuleMaterialPriceFacade(ModuleMaterialPriceModel model) : base(model)
		{
		}
		public static ModuleMaterialPriceFacade Instance
		{
			get { return instance; }
		}
		protected ModuleMaterialPriceFacade():base() 
		{ 
		} 
	
	}
}
	