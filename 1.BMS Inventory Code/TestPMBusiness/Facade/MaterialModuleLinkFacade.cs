
using System.Collections;
using TEST.Model;
namespace TEST.Facade
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
	