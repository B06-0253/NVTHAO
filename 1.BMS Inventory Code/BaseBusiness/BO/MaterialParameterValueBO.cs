
using System;
using System.Collections;
using BMS.Facade;
using BMS.Model;
namespace BMS.Business
{

	
	public class MaterialParameterValueBO : BaseBO
	{
		private MaterialParameterValueFacade facade = MaterialParameterValueFacade.Instance;
		protected static MaterialParameterValueBO instance = new MaterialParameterValueBO();

		protected MaterialParameterValueBO()
		{
			this.baseFacade = facade;
		}

		public static MaterialParameterValueBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	