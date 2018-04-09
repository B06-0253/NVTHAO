
using System.Collections;
using TEST.Model;
namespace TEST.Facade
{
	
	public class PartsFacade : BaseFacade
	{
		protected static PartsFacade instance = new PartsFacade(new PartsModel());
		protected PartsFacade(PartsModel model) : base(model)
		{
		}
		public static PartsFacade Instance
		{
			get { return instance; }
		}
		protected PartsFacade():base() 
		{ 
		} 
	
	}
}
	