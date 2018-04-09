
using System;
using System.Collections;
using TEST.Facade;
using TEST.Model;
namespace TEST.Business
{
	
	public class ProposalBuyBO : BaseBO
	{
		private ProposalBuyFacade facade = ProposalBuyFacade.Instance;
		protected static ProposalBuyBO instance = new ProposalBuyBO();

		protected ProposalBuyBO()
		{
			this.baseFacade = facade;
		}

		public static ProposalBuyBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	