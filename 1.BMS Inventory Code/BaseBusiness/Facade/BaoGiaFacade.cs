
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{
	
	public class BaoGiaFacade : BaseFacade
	{
		protected static BaoGiaFacade instance = new BaoGiaFacade(new BaoGiaModel());
		protected BaoGiaFacade(BaoGiaModel model) : base(model)
		{
		}
		public static BaoGiaFacade Instance
		{
			get { return instance; }
		}
		protected BaoGiaFacade():base() 
		{ 
		} 
	
	}
}
	