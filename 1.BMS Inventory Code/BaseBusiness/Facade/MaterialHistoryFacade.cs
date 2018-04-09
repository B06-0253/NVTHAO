
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{
	
	public class MaterialHistoryFacade : BaseFacade
	{
		protected static MaterialHistoryFacade instance = new MaterialHistoryFacade(new MaterialHistoryModel());
		protected MaterialHistoryFacade(MaterialHistoryModel model) : base(model)
		{
		}
		public static MaterialHistoryFacade Instance
		{
			get { return instance; }
		}
		protected MaterialHistoryFacade():base() 
		{ 
		} 
	
	}
}
	