
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{
	
	public class CheckCTTKHistoryFacade : BaseFacade
	{
		protected static CheckCTTKHistoryFacade instance = new CheckCTTKHistoryFacade(new CheckCTTKHistoryModel());
		protected CheckCTTKHistoryFacade(CheckCTTKHistoryModel model) : base(model)
		{
		}
		public static CheckCTTKHistoryFacade Instance
		{
			get { return instance; }
		}
		protected CheckCTTKHistoryFacade():base() 
		{ 
		} 
	
	}
}
	