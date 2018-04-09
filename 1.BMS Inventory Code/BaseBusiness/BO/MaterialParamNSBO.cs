
using System;
using System.Collections;
using BMS.Facade;
using BMS.Model;
namespace BMS.Business
{

	
	public class MaterialParamNSBO : BaseBO
	{
		private MaterialParamNSFacade facade = MaterialParamNSFacade.Instance;
		protected static MaterialParamNSBO instance = new MaterialParamNSBO();

		protected MaterialParamNSBO()
		{
			this.baseFacade = facade;
		}

		public static MaterialParamNSBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	