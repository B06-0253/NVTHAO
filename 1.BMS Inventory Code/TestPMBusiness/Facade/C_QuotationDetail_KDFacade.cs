
using System.Collections;
using TEST.Model;
namespace TEST.Facade
{
	
	public class C_QuotationDetail_KDFacade : BaseFacade
	{
		protected static C_QuotationDetail_KDFacade instance = new C_QuotationDetail_KDFacade(new C_QuotationDetail_KDModel());
		protected C_QuotationDetail_KDFacade(C_QuotationDetail_KDModel model) : base(model)
		{
		}
		public static C_QuotationDetail_KDFacade Instance
		{
			get { return instance; }
		}
		protected C_QuotationDetail_KDFacade():base() 
		{ 
		} 
	
	}
}
	