
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{
	
	public class MisMatchFacade : BaseFacade
	{
		protected static MisMatchFacade instance = new MisMatchFacade(new MisMatchModel());
		protected MisMatchFacade(MisMatchModel model) : base(model)
		{
		}
		public static MisMatchFacade Instance
		{
			get { return instance; }
		}
		protected MisMatchFacade():base() 
		{ 
		} 
	
	}
}
	