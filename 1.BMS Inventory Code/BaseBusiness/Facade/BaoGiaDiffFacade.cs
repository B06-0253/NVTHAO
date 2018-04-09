
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{
	
	public class BaoGiaDiffFacade : BaseFacade
	{
		protected static BaoGiaDiffFacade instance = new BaoGiaDiffFacade(new BaoGiaDiffModel());
		protected BaoGiaDiffFacade(BaoGiaDiffModel model) : base(model)
		{
		}
		public static BaoGiaDiffFacade Instance
		{
			get { return instance; }
		}
		protected BaoGiaDiffFacade():base() 
		{ 
		} 
	
	}
}
	