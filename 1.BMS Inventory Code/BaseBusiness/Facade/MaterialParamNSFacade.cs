
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{
	
	public class MaterialParamNSFacade : BaseFacade
	{
		protected static MaterialParamNSFacade instance = new MaterialParamNSFacade(new MaterialParamNSModel());
		protected MaterialParamNSFacade(MaterialParamNSModel model) : base(model)
		{
		}
		public static MaterialParamNSFacade Instance
		{
			get { return instance; }
		}
		protected MaterialParamNSFacade():base() 
		{ 
		} 
	
	}
}
	