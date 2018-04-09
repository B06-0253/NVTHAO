
using System;
using System.Collections;
using BMS.Facade;
using BMS.Model;
namespace BMS.Business
{

	
	public class ConfigNoConvertMaterialBO : BaseBO
	{
		private ConfigNoConvertMaterialFacade facade = ConfigNoConvertMaterialFacade.Instance;
		protected static ConfigNoConvertMaterialBO instance = new ConfigNoConvertMaterialBO();

		protected ConfigNoConvertMaterialBO()
		{
			this.baseFacade = facade;
		}

		public static ConfigNoConvertMaterialBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	