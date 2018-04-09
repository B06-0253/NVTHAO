
using System;
using System.Collections;
using BMS.Facade;
using BMS.Model;
namespace BMS.Business
{

	
	public class MaterialFileBO : BaseBO
	{
		private MaterialFileFacade facade = MaterialFileFacade.Instance;
		protected static MaterialFileBO instance = new MaterialFileBO();

		protected MaterialFileBO()
		{
			this.baseFacade = facade;
		}

		public static MaterialFileBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	