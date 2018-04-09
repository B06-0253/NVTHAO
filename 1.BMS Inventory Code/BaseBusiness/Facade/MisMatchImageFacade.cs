
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{
	
	public class MisMatchImageFacade : BaseFacade
	{
		protected static MisMatchImageFacade instance = new MisMatchImageFacade(new MisMatchImageModel());
		protected MisMatchImageFacade(MisMatchImageModel model) : base(model)
		{
		}
		public static MisMatchImageFacade Instance
		{
			get { return instance; }
		}
		protected MisMatchImageFacade():base() 
		{ 
		} 
	
	}
}
	