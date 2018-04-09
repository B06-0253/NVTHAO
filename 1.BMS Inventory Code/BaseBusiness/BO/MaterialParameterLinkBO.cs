
using System;
using System.Collections;
using BMS.Facade;
using BMS.Model;
namespace BMS.Business
{

	
	public class MaterialParameterLinkBO : BaseBO
	{
		private MaterialParameterLinkFacade facade = MaterialParameterLinkFacade.Instance;
		protected static MaterialParameterLinkBO instance = new MaterialParameterLinkBO();

		protected MaterialParameterLinkBO()
		{
			this.baseFacade = facade;
		}

		public static MaterialParameterLinkBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	