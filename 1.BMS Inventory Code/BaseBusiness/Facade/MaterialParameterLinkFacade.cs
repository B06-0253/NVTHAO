
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{
	
	public class MaterialParameterLinkFacade : BaseFacade
	{
		protected static MaterialParameterLinkFacade instance = new MaterialParameterLinkFacade(new MaterialParameterLinkModel());
		protected MaterialParameterLinkFacade(MaterialParameterLinkModel model) : base(model)
		{
		}
		public static MaterialParameterLinkFacade Instance
		{
			get { return instance; }
		}
		protected MaterialParameterLinkFacade():base() 
		{ 
		} 
	
	}
}
	