
using System.Collections;
using TPA.Model;
namespace TPA.Facade
{
	
	public class PProductInforFacade : BaseFacade
	{
		protected static PProductInforFacade instance = new PProductInforFacade(new PProductInforModel());
		protected PProductInforFacade(PProductInforModel model) : base(model)
		{
		}
		public static PProductInforFacade Instance
		{
			get { return instance; }
		}
		protected PProductInforFacade():base() 
		{ 
		} 
	
	}
}
	