
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{
	
	public class vDMVTCFacade : BaseFacade
	{
		protected static vDMVTCFacade instance = new vDMVTCFacade(new vDMVTCModel());
		protected vDMVTCFacade(vDMVTCModel model) : base(model)
		{
		}
		public static vDMVTCFacade Instance
		{
			get { return instance; }
		}
		protected vDMVTCFacade():base() 
		{ 
		} 
	
	}
}
	