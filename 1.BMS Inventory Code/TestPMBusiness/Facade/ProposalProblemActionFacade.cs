
using System.Collections;
using TEST.Model;
namespace TEST.Facade
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
	