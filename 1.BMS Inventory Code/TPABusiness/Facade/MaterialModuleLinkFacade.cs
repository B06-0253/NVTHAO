
using System.Collections;
using TPA.Model;
namespace TPA.Facade
{
	
	public class MaterialModuleLinkFacade : BaseFacade
	{
		protected static MaterialModuleLinkFacade instance = new MaterialModuleLinkFacade(new MaterialModuleLinkModel());
		protected MaterialModuleLinkFacade(MaterialModuleLinkModel model) : base(model)
		{
		}
		public static MaterialModuleLinkFacade Instance
		{
			get { return instance; }
		}
		protected MaterialModuleLinkFacade():base() 
		{ 
		} 
	
	}
}
	