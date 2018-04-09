
using System;
using System.Collections;
using BMS.Facade;
using BMS.Model;
namespace BMS.Business
{

	
	public class UpdateSoftwareBO : BaseBO
	{
		private UpdateSoftwareFacade facade = UpdateSoftwareFacade.Instance;
		protected static UpdateSoftwareBO instance = new UpdateSoftwareBO();

		protected UpdateSoftwareBO()
		{
			this.baseFacade = facade;
		}

		public static UpdateSoftwareBO Instance
		{
			get { return instance; }
		}
		
	
	}
}
	