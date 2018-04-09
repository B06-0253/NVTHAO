
using System;
using System.Collections;
using TEST.Facade;
using TEST.Model;
namespace TEST.Business
{
	
	public class PartsPriceAuditBO : BaseBO
	{
		private PartsPriceAuditFacade facade = PartsPriceAuditFacade.Instance;
		protected static PartsPriceAuditBO instance = new PartsPriceAuditBO();

		protected PartsPriceAuditBO()
		{
			this.baseFacade = facade;
		}

		public static PartsPriceAuditBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	