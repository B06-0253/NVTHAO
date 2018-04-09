
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{
	
	public class MaterialParamValueNSFacade : BaseFacade
	{
		protected static MaterialParamValueNSFacade instance = new MaterialParamValueNSFacade(new MaterialParamValueNSModel());
		protected MaterialParamValueNSFacade(MaterialParamValueNSModel model) : base(model)
		{
		}
		public static MaterialParamValueNSFacade Instance
		{
			get { return instance; }
		}
		protected MaterialParamValueNSFacade():base() 
		{ 
		} 
	
	}
}
	