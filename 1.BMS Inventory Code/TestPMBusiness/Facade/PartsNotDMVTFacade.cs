
using System.Collections;
using TEST.Model;
namespace TEST.Facade
{
	
	public class PartsNotDMVTFacade : BaseFacade
	{
		protected static PartsNotDMVTFacade instance = new PartsNotDMVTFacade(new PartsNotDMVTModel());
		protected PartsNotDMVTFacade(PartsNotDMVTModel model) : base(model)
		{
		}
		public static PartsNotDMVTFacade Instance
		{
			get { return instance; }
		}
		protected PartsNotDMVTFacade():base() 
		{ 
		} 
	
	}
}
	