
using System.Collections;
using TPA.Model;
namespace TPA.Facade
{
	
	public class PaymentTableItemFacade : BaseFacade
	{
		protected static PaymentTableItemFacade instance = new PaymentTableItemFacade(new PaymentTableItemModel());
		protected PaymentTableItemFacade(PaymentTableItemModel model) : base(model)
		{
		}
		public static PaymentTableItemFacade Instance
		{
			get { return instance; }
		}
		protected PaymentTableItemFacade():base() 
		{ 
		} 
	
	}
}
	