
using System.Collections;
using TEST.Model;
namespace TEST.Facade
{
	
	public class SuppliersUserLinkFacade : BaseFacade
	{
		protected static SuppliersUserLinkFacade instance = new SuppliersUserLinkFacade(new SuppliersUserLinkModel());
		protected SuppliersUserLinkFacade(SuppliersUserLinkModel model) : base(model)
		{
		}
		public static SuppliersUserLinkFacade Instance
		{
			get { return instance; }
		}
		protected SuppliersUserLinkFacade():base() 
		{ 
		} 
	
	}
}
	