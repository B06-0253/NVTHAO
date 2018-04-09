
using System;
using System.Collections;
using BMS.Facade;
using BMS.Model;
namespace BMS.Business
{

	
	public class ConfigPBDLBO : BaseBO
	{
		private ConfigPBDLFacade facade = ConfigPBDLFacade.Instance;
		protected static ConfigPBDLBO instance = new ConfigPBDLBO();

		protected ConfigPBDLBO()
		{
			this.baseFacade = facade;
		}

		public static ConfigPBDLBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	