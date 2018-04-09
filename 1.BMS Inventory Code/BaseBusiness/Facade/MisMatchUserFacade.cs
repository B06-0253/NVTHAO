
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{
	
	public class MisMatchUserFacade : BaseFacade
	{
		protected static MisMatchUserFacade instance = new MisMatchUserFacade(new MisMatchUserModel());
		protected MisMatchUserFacade(MisMatchUserModel model) : base(model)
		{
		}
		public static MisMatchUserFacade Instance
		{
			get { return instance; }
		}
		protected MisMatchUserFacade():base() 
		{ 
		} 
	
	}
}
	