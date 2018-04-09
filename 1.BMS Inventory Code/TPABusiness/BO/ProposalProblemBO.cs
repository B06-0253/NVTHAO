
using System;
using System.Collections;
using TPA.Facade;
using TPA.Model;
namespace TPA.Business
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
	