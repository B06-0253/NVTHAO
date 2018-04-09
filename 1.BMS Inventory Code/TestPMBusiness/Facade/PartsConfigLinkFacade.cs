
using System.Collections;
using TEST.Model;
namespace TEST.Facade
{
	
	public class PartsConfigLinkFacade : BaseFacade
	{
		protected static PartsConfigLinkFacade instance = new PartsConfigLinkFacade(new PartsConfigLinkModel());
		protected PartsConfigLinkFacade(PartsConfigLinkModel model) : base(model)
		{
		}
		public static PartsConfigLinkFacade Instance
		{
			get { return instance; }
		}
		protected PartsConfigLinkFacade():base() 
		{ 
		} 
	
	}
}
	