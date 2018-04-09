
using System;
using System.Collections;
using TEST.Facade;
using TEST.Model;
namespace TEST.Business
{
	
	public class MaterialGroupBO : BaseBO
	{
		private MaterialGroupFacade facade = MaterialGroupFacade.Instance;
		protected static MaterialGroupBO instance = new MaterialGroupBO();

		protected MaterialGroupBO()
		{
			this.baseFacade = facade;
		}

		public static MaterialGroupBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	