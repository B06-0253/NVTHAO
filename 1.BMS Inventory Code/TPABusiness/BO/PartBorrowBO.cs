
using System;
using System.Collections;
using TPA.Facade;
using TPA.Model;
namespace TPA.Business
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
	