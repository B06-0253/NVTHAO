
using System.Collections;
using TPA.Model;
namespace TPA.Facade
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
	