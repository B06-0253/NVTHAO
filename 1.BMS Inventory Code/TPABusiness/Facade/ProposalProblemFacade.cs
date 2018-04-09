
using System.Collections;
using TPA.Model;
namespace TPA.Facade
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
	