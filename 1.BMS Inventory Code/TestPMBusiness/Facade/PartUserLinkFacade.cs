
using System.Collections;
using TEST.Model;
namespace TEST.Facade
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
	