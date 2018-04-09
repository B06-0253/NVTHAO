
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{
	
	public class MaterialParameterValueFacade : BaseFacade
	{
		protected static MaterialParameterValueFacade instance = new MaterialParameterValueFacade(new MaterialParameterValueModel());
		protected MaterialParameterValueFacade(MaterialParameterValueModel model) : base(model)
		{
		}
		public static MaterialParameterValueFacade Instance
		{
			get { return instance; }
		}
		protected MaterialParameterValueFacade():base() 
		{ 
		} 
	
	}
}
	