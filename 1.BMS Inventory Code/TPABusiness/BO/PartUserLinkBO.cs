
using System;
using System.Collections;
using TPA.Facade;
using TPA.Model;
namespace TPA.Business
{
	
	public class PartUserLinkBO : BaseBO
	{
		private PartUserLinkFacade facade = PartUserLinkFacade.Instance;
		protected static PartUserLinkBO instance = new PartUserLinkBO();

		protected PartUserLinkBO()
		{
			this.baseFacade = facade;
		}

		public static PartUserLinkBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	