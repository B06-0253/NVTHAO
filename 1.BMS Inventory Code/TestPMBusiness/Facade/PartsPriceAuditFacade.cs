
using System.Collections;
using TEST.Model;
namespace TEST.Facade
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
	