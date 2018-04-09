
using System.Collections;
using TPA.Model;
namespace TPA.Facade
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
	