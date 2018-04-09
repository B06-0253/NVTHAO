
using System.Collections;
using TEST.Model;
namespace TEST.Facade
{
	
	public class C_GroundFacade : BaseFacade
	{
		protected static C_GroundFacade instance = new C_GroundFacade(new C_GroundModel());
		protected C_GroundFacade(C_GroundModel model) : base(model)
		{
		}
		public static C_GroundFacade Instance
		{
			get { return instance; }
		}
		protected C_GroundFacade():base() 
		{ 
		} 
	
	}
}
	