
using System.Collections;
using TPA.Model;
namespace TPA.Facade
{
	
	public class C_QuotationDetail_SXFacade : BaseFacade
	{
		protected static C_QuotationDetail_SXFacade instance = new C_QuotationDetail_SXFacade(new C_QuotationDetail_SXModel());
		protected C_QuotationDetail_SXFacade(C_QuotationDetail_SXModel model) : base(model)
		{
		}
		public static C_QuotationDetail_SXFacade Instance
		{
			get { return instance; }
		}
		protected C_QuotationDetail_SXFacade():base() 
		{ 
		} 
	
	}
}
	