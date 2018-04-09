
using System.Collections;
using TEST.Model;
namespace TEST.Facade
{
	
	public class PaymentTableFacade : BaseFacade
	{
		protected static PaymentTableFacade instance = new PaymentTableFacade(new PaymentTableModel());
		protected PaymentTableFacade(PaymentTableModel model) : base(model)
		{
		}
		public static PaymentTableFacade Instance
		{
			get { return instance; }
		}
		protected PaymentTableFacade():base() 
		{ 
		} 
	
	}
}
	