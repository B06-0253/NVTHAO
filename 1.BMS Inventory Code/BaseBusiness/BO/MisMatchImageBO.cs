
using System;
using System.Collections;
using BMS.Facade;
using BMS.Model;
namespace BMS.Business
{

	
	public class MisMatchImageBO : BaseBO
	{
		private MisMatchImageFacade facade = MisMatchImageFacade.Instance;
		protected static MisMatchImageBO instance = new MisMatchImageBO();

		protected MisMatchImageBO()
		{
			this.baseFacade = facade;
		}

		public static MisMatchImageBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	