
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{
	
	public class HangMucCongViecFacade : BaseFacade
	{
		protected static HangMucCongViecFacade instance = new HangMucCongViecFacade(new HangMucCongViecModel());
		protected HangMucCongViecFacade(HangMucCongViecModel model) : base(model)
		{
		}
		public static HangMucCongViecFacade Instance
		{
			get { return instance; }
		}
		protected HangMucCongViecFacade():base() 
		{ 
		} 
	
	}
}
	