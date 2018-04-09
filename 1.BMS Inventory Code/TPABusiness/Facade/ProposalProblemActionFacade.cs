
using System.Collections;
using TPA.Model;
namespace TPA.Facade
{
	
	public class ProposalProblemActionFacade : BaseFacade
	{
		protected static ProposalProblemActionFacade instance = new ProposalProblemActionFacade(new ProposalProblemActionModel());
		protected ProposalProblemActionFacade(ProposalProblemActionModel model) : base(model)
		{
		}
		public static ProposalProblemActionFacade Instance
		{
			get { return instance; }
		}
		protected ProposalProblemActionFacade():base() 
		{ 
		} 
	
	}
}
	