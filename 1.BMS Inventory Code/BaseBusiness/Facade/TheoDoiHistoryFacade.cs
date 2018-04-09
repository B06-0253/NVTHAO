
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{
	
	public class TheoDoiHistoryFacade : BaseFacade
	{
		protected static TheoDoiHistoryFacade instance = new TheoDoiHistoryFacade(new TheoDoiHistoryModel());
		protected TheoDoiHistoryFacade(TheoDoiHistoryModel model) : base(model)
		{
		}
		public static TheoDoiHistoryFacade Instance
		{
			get { return instance; }
		}
		protected TheoDoiHistoryFacade():base() 
		{ 
		} 
	
	}
}
	