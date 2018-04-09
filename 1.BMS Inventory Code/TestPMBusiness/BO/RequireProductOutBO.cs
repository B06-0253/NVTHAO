
using System;
using System.Collections;
using TEST.Facade;
using TEST.Model;
namespace TEST.Business
{
	
	public class RequireProductOutBO : BaseBO
	{
		private RequireProductOutFacade facade = RequireProductOutFacade.Instance;
		protected static RequireProductOutBO instance = new RequireProductOutBO();

		protected RequireProductOutBO()
		{
			this.baseFacade = facade;
		}

		public static RequireProductOutBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	