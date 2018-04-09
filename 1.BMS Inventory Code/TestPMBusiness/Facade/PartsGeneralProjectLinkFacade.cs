
using System.Collections;
using TEST.Model;
namespace TEST.Facade
{
	
	public class PartsGeneralProjectLinkFacade : BaseFacade
	{
		protected static PartsGeneralProjectLinkFacade instance = new PartsGeneralProjectLinkFacade(new PartsGeneralProjectLinkModel());
		protected PartsGeneralProjectLinkFacade(PartsGeneralProjectLinkModel model) : base(model)
		{
		}
		public static PartsGeneralProjectLinkFacade Instance
		{
			get { return instance; }
		}
		protected PartsGeneralProjectLinkFacade():base() 
		{ 
		} 
	
	}
}
	