
using System;
using System.Collections;
using TEST.Facade;
using TEST.Model;
namespace TEST.Business
{
	
	public class PartBorrowBO : BaseBO
	{
		private PartBorrowFacade facade = PartBorrowFacade.Instance;
		protected static PartBorrowBO instance = new PartBorrowBO();

		protected PartBorrowBO()
		{
			this.baseFacade = facade;
		}

		public static PartBorrowBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	