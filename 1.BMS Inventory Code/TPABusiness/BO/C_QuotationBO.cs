
using System;
using System.Collections;
using TPA.Facade;
using TPA.Model;
namespace TPA.Business
{
	
	public class C_QuotationBO : BaseBO
	{
		private C_QuotationFacade facade = C_QuotationFacade.Instance;
		protected static C_QuotationBO instance = new C_QuotationBO();

		protected C_QuotationBO()
		{
			this.baseFacade = facade;
		}

		public static C_QuotationBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	