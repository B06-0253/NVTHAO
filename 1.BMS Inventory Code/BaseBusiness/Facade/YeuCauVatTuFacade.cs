
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{
	
	public class YeuCauVatTuFacade : BaseFacade
	{
		protected static YeuCauVatTuFacade instance = new YeuCauVatTuFacade(new YeuCauVatTuModel());
		protected YeuCauVatTuFacade(YeuCauVatTuModel model) : base(model)
		{
		}
		public static YeuCauVatTuFacade Instance
		{
			get { return instance; }
		}
		protected YeuCauVatTuFacade():base() 
		{ 
		} 
	
	}
}
	