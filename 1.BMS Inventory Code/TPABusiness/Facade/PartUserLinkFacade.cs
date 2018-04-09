
using System.Collections;
using TPA.Model;
namespace TPA.Facade
{
	
	public class PartUserLinkFacade : BaseFacade
	{
		protected static PartUserLinkFacade instance = new PartUserLinkFacade(new PartUserLinkModel());
		protected PartUserLinkFacade(PartUserLinkModel model) : base(model)
		{
		}
		public static PartUserLinkFacade Instance
		{
			get { return instance; }
		}
		protected PartUserLinkFacade():base() 
		{ 
		} 
	
	}
}
	