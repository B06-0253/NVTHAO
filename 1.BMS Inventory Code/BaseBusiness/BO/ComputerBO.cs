
using System;
using System.Collections;
using BMS.Facade;
using BMS.Model;
namespace BMS.Business
{

	
	public class ComputerBO : BaseBO
	{
		private ComputerFacade facade = ComputerFacade.Instance;
		protected static ComputerBO instance = new ComputerBO();

		protected ComputerBO()
		{
			this.baseFacade = facade;
		}

		public static ComputerBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	