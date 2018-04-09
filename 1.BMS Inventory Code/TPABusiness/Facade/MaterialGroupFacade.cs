
using System.Collections;
using TPA.Model;
namespace TPA.Facade
{
	
	public class MaterialGroupFacade : BaseFacade
	{
		protected static MaterialGroupFacade instance = new MaterialGroupFacade(new MaterialGroupModel());
		protected MaterialGroupFacade(MaterialGroupModel model) : base(model)
		{
		}
		public static MaterialGroupFacade Instance
		{
			get { return instance; }
		}
		protected MaterialGroupFacade():base() 
		{ 
		} 
	
	}
}
	