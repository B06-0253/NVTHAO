
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{
	
	public class BaoGiaItemFacade : BaseFacade
	{
		protected static BaoGiaItemFacade instance = new BaoGiaItemFacade(new BaoGiaItemModel());
		protected BaoGiaItemFacade(BaoGiaItemModel model) : base(model)
		{
		}
		public static BaoGiaItemFacade Instance
		{
			get { return instance; }
		}
		protected BaoGiaItemFacade():base() 
		{ 
		} 
	
	}
}
	