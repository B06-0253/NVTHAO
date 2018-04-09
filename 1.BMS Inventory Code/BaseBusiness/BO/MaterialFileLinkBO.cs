
using System;
using System.Collections;
using BMS.Facade;
using BMS.Model;
namespace BMS.Business
{

	
	public class MaterialFileLinkBO : BaseBO
	{
		private MaterialFileLinkFacade facade = MaterialFileLinkFacade.Instance;
		protected static MaterialFileLinkBO instance = new MaterialFileLinkBO();

		protected MaterialFileLinkBO()
		{
			this.baseFacade = facade;
		}

		public static MaterialFileLinkBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	