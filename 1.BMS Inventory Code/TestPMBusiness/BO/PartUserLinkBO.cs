
using System;
using System.Collections;
using TEST.Facade;
using TEST.Model;
namespace TEST.Business
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
	