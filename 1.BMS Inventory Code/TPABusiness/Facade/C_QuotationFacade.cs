
using System.Collections;
using TPA.Model;
namespace TPA.Facade
{
	
	public class C_QuotationFacade : BaseFacade
	{
		protected static C_QuotationFacade instance = new C_QuotationFacade(new C_QuotationModel());
		protected C_QuotationFacade(C_QuotationModel model) : base(model)
		{
		}
		public static C_QuotationFacade Instance
		{
			get { return instance; }
		}
		protected C_QuotationFacade():base() 
		{ 
		} 
	
	}
}
	