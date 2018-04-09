
using System.Collections;
using TPA.Model;
namespace TPA.Facade
{
	
	public class ProposalSentStatusFacade : BaseFacade
	{
		protected static ProposalSentStatusFacade instance = new ProposalSentStatusFacade(new ProposalSentStatusModel());
		protected ProposalSentStatusFacade(ProposalSentStatusModel model) : base(model)
		{
		}
		public static ProposalSentStatusFacade Instance
		{
			get { return instance; }
		}
		protected ProposalSentStatusFacade():base() 
		{ 
		} 
	
	}
}
	