
using System;
using System.Collections;
using TEST.Facade;
using TEST.Model;
namespace TEST.Business
{
	
	public class C_QuotationDetailBO : BaseBO
	{
		private C_QuotationDetailFacade facade = C_QuotationDetailFacade.Instance;
		protected static C_QuotationDetailBO instance = new C_QuotationDetailBO();

		protected C_QuotationDetailBO()
		{
			this.baseFacade = facade;
		}

		public static C_QuotationDetailBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	