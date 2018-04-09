
using System;
using System.Collections;
using TEST.Facade;
using TEST.Model;
namespace TEST.Business
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
	