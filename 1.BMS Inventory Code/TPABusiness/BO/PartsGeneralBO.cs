
using System;
using System.Collections;
using TPA.Facade;
using TPA.Model;
namespace TPA.Business
{
	
	public class PartsGeneralBO : BaseBO
	{
		private PartsGeneralFacade facade = PartsGeneralFacade.Instance;
		protected static PartsGeneralBO instance = new PartsGeneralBO();

		protected PartsGeneralBO()
		{
			this.baseFacade = facade;
		}

		public static PartsGeneralBO Instance
		{
			get { return instance; }
		}
		
	
        //public ArrayList FindBypartsId(string partsId)
        //{
        //    return facade.FindByPartsId(partsId);
        //}

		
	}
}
	