
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{
	
	public class SolutionItemFacade : BaseFacade
	{
		protected static SolutionItemFacade instance = new SolutionItemFacade(new SolutionItemModel());
		protected SolutionItemFacade(SolutionItemModel model) : base(model)
		{
		}
		public static SolutionItemFacade Instance
		{
			get { return instance; }
		}
		protected SolutionItemFacade():base() 
		{ 
		} 
	
	}
}
	