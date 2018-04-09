
using System;
using System.Collections;
using TPA.Facade;
using TPA.Model;
namespace TPA.Business
{
	
	public class SuppliersUserLinkBO : BaseBO
	{
		private SuppliersUserLinkFacade facade = SuppliersUserLinkFacade.Instance;
		protected static SuppliersUserLinkBO instance = new SuppliersUserLinkBO();

		protected SuppliersUserLinkBO()
		{
			this.baseFacade = facade;
		}

		public static SuppliersUserLinkBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	