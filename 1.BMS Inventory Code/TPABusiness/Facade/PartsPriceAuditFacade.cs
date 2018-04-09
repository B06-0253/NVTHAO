
using System.Collections;
using TPA.Model;
namespace TPA.Facade
{
	
	public class PartsPriceAuditFacade : BaseFacade
	{
		protected static PartsPriceAuditFacade instance = new PartsPriceAuditFacade(new PartsPriceAuditModel());
		protected PartsPriceAuditFacade(PartsPriceAuditModel model) : base(model)
		{
		}
		public static PartsPriceAuditFacade Instance
		{
			get { return instance; }
		}
		protected PartsPriceAuditFacade():base() 
		{ 
		} 
	
	}
}
	