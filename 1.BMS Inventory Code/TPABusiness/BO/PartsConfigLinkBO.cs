
using System;
using System.Collections;
using TPA.Facade;
using TPA.Model;
namespace TPA.Business
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
	