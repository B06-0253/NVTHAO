
using System.Collections;
using TEST.Model;
namespace TEST.Facade
{
	
	public class PartAccessoriesFacade : BaseFacade
	{
		protected static PartAccessoriesFacade instance = new PartAccessoriesFacade(new PartAccessoriesModel());
		protected PartAccessoriesFacade(PartAccessoriesModel model) : base(model)
		{
		}
		public static PartAccessoriesFacade Instance
		{
			get { return instance; }
		}
		protected PartAccessoriesFacade():base() 
		{ 
		} 
	
	}
}
	