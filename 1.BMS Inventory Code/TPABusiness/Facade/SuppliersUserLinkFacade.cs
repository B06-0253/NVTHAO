
using System.Collections;
using TPA.Model;
namespace TPA.Facade
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
	