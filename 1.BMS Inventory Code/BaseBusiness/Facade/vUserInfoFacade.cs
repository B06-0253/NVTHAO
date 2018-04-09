
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{

    public class vUserInfoFacade : BaseFacade
	{
		protected static vUserInfoFacade instance = new vUserInfoFacade(new vUserInfoModel());
		protected vUserInfoFacade(vUserInfoModel model) : base(model)
		{
		}
		public static vUserInfoFacade Instance
		{
			get { return instance; }
		}
		protected vUserInfoFacade():base() 
		{ 
		} 
	
	}
}
	