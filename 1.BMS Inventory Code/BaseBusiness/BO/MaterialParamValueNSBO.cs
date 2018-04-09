
using System;
using System.Collections;
using BMS.Facade;
using BMS.Model;
namespace BMS.Business
{

	
	public class MaterialParamValueNSBO : BaseBO
	{
		private MaterialParamValueNSFacade facade = MaterialParamValueNSFacade.Instance;
		protected static MaterialParamValueNSBO instance = new MaterialParamValueNSBO();

		protected MaterialParamValueNSBO()
		{
			this.baseFacade = facade;
		}

		public static MaterialParamValueNSBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	