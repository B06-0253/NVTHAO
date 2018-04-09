
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{
	
	public class ConfigNoConvertMaterialFacade : BaseFacade
	{
		protected static ConfigNoConvertMaterialFacade instance = new ConfigNoConvertMaterialFacade(new ConfigNoConvertMaterialModel());
		protected ConfigNoConvertMaterialFacade(ConfigNoConvertMaterialModel model) : base(model)
		{
		}
		public static ConfigNoConvertMaterialFacade Instance
		{
			get { return instance; }
		}
		protected ConfigNoConvertMaterialFacade():base() 
		{ 
		} 
	
	}
}
	