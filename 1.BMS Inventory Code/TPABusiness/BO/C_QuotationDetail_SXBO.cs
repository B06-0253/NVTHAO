
using System;
using System.Collections;
using TPA.Facade;
using TPA.Model;
namespace TPA.Business
{
	
	public class C_QuotationDetail_SXBO : BaseBO
	{
		private C_QuotationDetail_SXFacade facade = C_QuotationDetail_SXFacade.Instance;
		protected static C_QuotationDetail_SXBO instance = new C_QuotationDetail_SXBO();

		protected C_QuotationDetail_SXBO()
		{
			this.baseFacade = facade;
		}

		public static C_QuotationDetail_SXBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	