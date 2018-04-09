
using System;
using System.Collections;
using TPA.Facade;
using TPA.Model;
namespace TPA.Business
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
	