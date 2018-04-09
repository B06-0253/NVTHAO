
using System;
using System.Collections;
using TPA.Facade;
using TPA.Model;
namespace TPA.Business
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
	