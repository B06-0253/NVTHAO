
using System.Collections;
using TPA.Model;
namespace TPA.Facade
{
	
	public class ProposalBuyFacade : BaseFacade
	{
		protected static ProposalBuyFacade instance = new ProposalBuyFacade(new ProposalBuyModel());
		protected ProposalBuyFacade(ProposalBuyModel model) : base(model)
		{
		}
		public static ProposalBuyFacade Instance
		{
			get { return instance; }
		}
		protected ProposalBuyFacade():base() 
		{ 
		} 
	
	}
}
	