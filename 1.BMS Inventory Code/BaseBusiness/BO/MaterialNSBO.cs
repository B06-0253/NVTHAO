
using System;
using System.Collections;
using BMS.Facade;
using BMS.Model;
namespace BMS.Business
{

	
	public class MaterialNSBO : BaseBO
	{
		private MaterialNSFacade facade = MaterialNSFacade.Instance;
		protected static MaterialNSBO instance = new MaterialNSBO();

		protected MaterialNSBO()
		{
			this.baseFacade = facade;
		}

		public static MaterialNSBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	