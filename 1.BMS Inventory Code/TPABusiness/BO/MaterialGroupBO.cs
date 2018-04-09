
using System;
using System.Collections;
using TPA.Facade;
using TPA.Model;
namespace TPA.Business
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
	