
using System.Collections;
using TPA.Model;
namespace TPA.Facade
{
	
	public class SessionFacade : BaseFacade
	{
		protected static SessionFacade instance = new SessionFacade(new SessionModel());
		protected SessionFacade(SessionModel model) : base(model)
		{
		}
		public static SessionFacade Instance
		{
			get { return instance; }
		}
		protected SessionFacade():base() 
		{ 
		} 
	
	}
}
	