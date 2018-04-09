
using System.Collections;
using TPA.Model;
namespace TPA.Facade
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
	