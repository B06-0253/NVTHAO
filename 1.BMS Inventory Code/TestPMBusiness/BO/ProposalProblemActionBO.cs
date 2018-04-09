
using System;
using System.Collections;
using TEST.Facade;
using TEST.Model;
namespace TEST.Business
{
	
	public class ProposalProblemActionBO : BaseBO
	{
		private ProposalProblemActionFacade facade = ProposalProblemActionFacade.Instance;
		protected static ProposalProblemActionBO instance = new ProposalProblemActionBO();

		protected ProposalProblemActionBO()
		{
			this.baseFacade = facade;
		}

		public static ProposalProblemActionBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	