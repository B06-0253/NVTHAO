
using System.Collections;
using TPA.Model;
namespace TPA.Facade
{
	
	public class C_Quotation_KDFacade : BaseFacade
	{
		protected static C_Quotation_KDFacade instance = new C_Quotation_KDFacade(new C_Quotation_KDModel());
		protected C_Quotation_KDFacade(C_Quotation_KDModel model) : base(model)
		{
		}
		public static C_Quotation_KDFacade Instance
		{
			get { return instance; }
		}
		protected C_Quotation_KDFacade():base() 
		{ 
		} 
	
	}
}
	