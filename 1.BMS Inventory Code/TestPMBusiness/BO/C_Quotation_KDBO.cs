
using System;
using System.Collections;
using TEST.Facade;
using TEST.Model;
namespace TEST.Business
{
	
	public class C_Quotation_KDBO : BaseBO
	{
		private C_Quotation_KDFacade facade = C_Quotation_KDFacade.Instance;
		protected static C_Quotation_KDBO instance = new C_Quotation_KDBO();

		protected C_Quotation_KDBO()
		{
			this.baseFacade = facade;
		}

		public static C_Quotation_KDBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	