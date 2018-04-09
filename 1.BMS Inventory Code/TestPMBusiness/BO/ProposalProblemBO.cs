
using System;
using System.Collections;
using TEST.Facade;
using TEST.Model;
namespace TEST.Business
{
	
	public class ProposalProblemBO : BaseBO
	{
		private ProposalProblemFacade facade = ProposalProblemFacade.Instance;
		protected static ProposalProblemBO instance = new ProposalProblemBO();

		protected ProposalProblemBO()
		{
			this.baseFacade = facade;
		}

		public static ProposalProblemBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	