
using System.Collections;
using TEST.Model;
namespace TEST.Facade
{
	
	public class ProposalProblemFacade : BaseFacade
	{
		protected static ProposalProblemFacade instance = new ProposalProblemFacade(new ProposalProblemModel());
		protected ProposalProblemFacade(ProposalProblemModel model) : base(model)
		{
		}
		public static ProposalProblemFacade Instance
		{
			get { return instance; }
		}
		protected ProposalProblemFacade():base() 
		{ 
		} 
	
	}
}
	