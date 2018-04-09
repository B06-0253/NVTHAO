
using System.Collections;
using TEST.Model;
namespace TEST.Facade
{
	
	public class PayVouchersFacade : BaseFacade
	{
		protected static PayVouchersFacade instance = new PayVouchersFacade(new PayVouchersModel());
		protected PayVouchersFacade(PayVouchersModel model) : base(model)
		{
		}
		public static PayVouchersFacade Instance
		{
			get { return instance; }
		}
		protected PayVouchersFacade():base() 
		{ 
		} 
	
	}
}
	