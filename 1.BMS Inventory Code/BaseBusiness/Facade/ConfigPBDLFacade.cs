
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{
	
	public class ConfigPBDLFacade : BaseFacade
	{
		protected static ConfigPBDLFacade instance = new ConfigPBDLFacade(new ConfigPBDLModel());
		protected ConfigPBDLFacade(ConfigPBDLModel model) : base(model)
		{
		}
		public static ConfigPBDLFacade Instance
		{
			get { return instance; }
		}
		protected ConfigPBDLFacade():base() 
		{ 
		} 
	
	}
}
	