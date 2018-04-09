
using System;
using System.Collections;
using BMS.Facade;
using BMS.Model;
namespace BMS.Business
{

	
	public class MaterialBO : BaseBO
	{
		private MaterialFacade facade = MaterialFacade.Instance;
		protected static MaterialBO instance = new MaterialBO();

		protected MaterialBO()
		{
			this.baseFacade = facade;
		}

		public static MaterialBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	