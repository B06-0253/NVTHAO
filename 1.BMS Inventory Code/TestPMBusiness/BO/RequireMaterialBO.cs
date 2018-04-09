
using System;
using System.Collections;
using TEST.Facade;
using TEST.Model;
namespace TEST.Business
{
	
	public class RequireMaterialBO : BaseBO
	{
		private RequireMaterialFacade facade = RequireMaterialFacade.Instance;
		protected static RequireMaterialBO instance = new RequireMaterialBO();

		protected RequireMaterialBO()
		{
			this.baseFacade = facade;
		}

		public static RequireMaterialBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	