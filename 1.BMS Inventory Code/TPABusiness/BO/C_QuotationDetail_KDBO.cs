
using System;
using System.Collections;
using TPA.Facade;
using TPA.Model;
namespace TPA.Business
{
	
	public class C_QuotationDetail_KDBO : BaseBO
	{
		private C_QuotationDetail_KDFacade facade = C_QuotationDetail_KDFacade.Instance;
		protected static C_QuotationDetail_KDBO instance = new C_QuotationDetail_KDBO();

		protected C_QuotationDetail_KDBO()
		{
			this.baseFacade = facade;
		}

		public static C_QuotationDetail_KDBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	