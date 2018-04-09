
using System;
using System.Collections;
using TEST.Facade;
using TEST.Model;
namespace TEST.Business
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
	