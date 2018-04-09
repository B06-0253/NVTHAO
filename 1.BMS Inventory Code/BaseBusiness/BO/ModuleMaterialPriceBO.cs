
using System;
using System.Collections;
using BMS.Facade;
using BMS.Model;
namespace BMS.Business
{

	
	public class ModuleMaterialPriceBO : BaseBO
	{
		private ModuleMaterialPriceFacade facade = ModuleMaterialPriceFacade.Instance;
		protected static ModuleMaterialPriceBO instance = new ModuleMaterialPriceBO();

		protected ModuleMaterialPriceBO()
		{
			this.baseFacade = facade;
		}

		public static ModuleMaterialPriceBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	