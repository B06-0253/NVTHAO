
using System;
using System.Collections;
using TEST.Facade;
using TEST.Model;
namespace TEST.Business
{
	
	public class ProposalSentStatusBO : BaseBO
	{
		private ProposalSentStatusFacade facade = ProposalSentStatusFacade.Instance;
		protected static ProposalSentStatusBO instance = new ProposalSentStatusBO();

		protected ProposalSentStatusBO()
		{
			this.baseFacade = facade;
		}

		public static ProposalSentStatusBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	