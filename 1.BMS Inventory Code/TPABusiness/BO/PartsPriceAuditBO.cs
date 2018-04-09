
using System;
using System.Collections;
using TPA.Facade;
using TPA.Model;
namespace TPA.Business
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
	