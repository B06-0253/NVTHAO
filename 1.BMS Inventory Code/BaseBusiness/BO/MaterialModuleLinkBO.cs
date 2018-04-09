
using System;
using System.Collections;
using BMS.Facade;
using BMS.Model;
namespace BMS.Business
{

	
	public class MaterialModuleLinkBO : BaseBO
	{
		private MaterialModuleLinkFacade facade = MaterialModuleLinkFacade.Instance;
		protected static MaterialModuleLinkBO instance = new MaterialModuleLinkBO();

		protected MaterialModuleLinkBO()
		{
			this.baseFacade = facade;
		}

		public static MaterialModuleLinkBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	