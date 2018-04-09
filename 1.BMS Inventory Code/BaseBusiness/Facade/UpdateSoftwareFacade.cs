
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{
	
	public class UpdateSoftwareFacade : BaseFacade
	{
		protected static UpdateSoftwareFacade instance = new UpdateSoftwareFacade(new UpdateSoftwareModel());
		protected UpdateSoftwareFacade(UpdateSoftwareModel model) : base(model)
		{
		}
		public static UpdateSoftwareFacade Instance
		{
			get { return instance; }
		}
		protected UpdateSoftwareFacade():base() 
		{ 
		} 
	
	}
}
	