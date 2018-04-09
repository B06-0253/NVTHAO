
using System.Collections;
using TPA.Model;
namespace TPA.Facade
{
	
	public class PayVoucherDebtFacade : BaseFacade
	{
		protected static PayVoucherDebtFacade instance = new PayVoucherDebtFacade(new PayVoucherDebtModel());
		protected PayVoucherDebtFacade(PayVoucherDebtModel model) : base(model)
		{
		}
		public static PayVoucherDebtFacade Instance
		{
			get { return instance; }
		}
		protected PayVoucherDebtFacade():base() 
		{ 
		} 
	
	}
}
	