
using System;
using System.Collections;
using TPA.Facade;
using TPA.Model;
namespace TPA.Business
{
	
	public class RequirePartsBO : BaseBO
	{
		private RequirePartsFacade facade = RequirePartsFacade.Instance;
		protected static RequirePartsBO instance = new RequirePartsBO();

		protected RequirePartsBO()
		{
			this.baseFacade = facade;
		}

		public static RequirePartsBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	