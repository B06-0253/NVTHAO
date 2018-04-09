
using System;
using System.Collections;
using TEST.Facade;
using TEST.Model;
namespace TEST.Business
{
	
	public class PartsConfigLinkBO : BaseBO
	{
		private PartsConfigLinkFacade facade = PartsConfigLinkFacade.Instance;
		protected static PartsConfigLinkBO instance = new PartsConfigLinkBO();

		protected PartsConfigLinkBO()
		{
			this.baseFacade = facade;
		}

		public static PartsConfigLinkBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	