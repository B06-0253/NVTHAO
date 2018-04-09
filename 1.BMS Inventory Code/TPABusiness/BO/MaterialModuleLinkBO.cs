
using System;
using System.Collections;
using TPA.Facade;
using TPA.Model;
namespace TPA.Business
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
	