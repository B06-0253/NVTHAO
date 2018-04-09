
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{
	
	public class MaterialFacade : BaseFacade
	{
		protected static MaterialFacade instance = new MaterialFacade(new MaterialModel());
		protected MaterialFacade(MaterialModel model) : base(model)
		{
		}
		public static MaterialFacade Instance
		{
			get { return instance; }
		}
		protected MaterialFacade():base() 
		{ 
		} 
	
	}
}
	