
using System.Collections;
using TPA.Model;
namespace TPA.Facade
{
	
	public class C_QuotationDetailFacade : BaseFacade
	{
		protected static C_QuotationDetailFacade instance = new C_QuotationDetailFacade(new C_QuotationDetailModel());
		protected C_QuotationDetailFacade(C_QuotationDetailModel model) : base(model)
		{
		}
		public static C_QuotationDetailFacade Instance
		{
			get { return instance; }
		}
		protected C_QuotationDetailFacade():base() 
		{ 
		} 
	
	}
}
	