
using System.Collections;
using TEST.Model;
namespace TEST.Facade
{
	
	public class PartsNormFacade : BaseFacade
	{
		protected static PartsNormFacade instance = new PartsNormFacade(new PartsNormModel());
		protected PartsNormFacade(PartsNormModel model) : base(model)
		{
		}
		public static PartsNormFacade Instance
		{
			get { return instance; }
		}
		protected PartsNormFacade():base() 
		{ 
		} 
	
	}
}
	