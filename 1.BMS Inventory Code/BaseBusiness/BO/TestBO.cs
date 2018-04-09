
using System;
using System.Collections;
using BMS.Facade;
using BMS.Model;
namespace BMS.Business
{

	
	public class TestBO : BaseBO
	{
		private TestFacade facade = TestFacade.Instance;
		protected static TestBO instance = new TestBO();

		protected TestBO()
		{
			this.baseFacade = facade;
		}

		public static TestBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	