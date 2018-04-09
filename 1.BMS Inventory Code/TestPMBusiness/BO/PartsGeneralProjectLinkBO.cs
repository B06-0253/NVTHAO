
using System;
using System.Collections;
using TEST.Facade;
using TEST.Model;
namespace TEST.Business
{
	
	public class PartsGeneralProjectLinkBO : BaseBO
	{
		private PartsGeneralProjectLinkFacade facade = PartsGeneralProjectLinkFacade.Instance;
		protected static PartsGeneralProjectLinkBO instance = new PartsGeneralProjectLinkBO();

		protected PartsGeneralProjectLinkBO()
		{
			this.baseFacade = facade;
		}

		public static PartsGeneralProjectLinkBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	