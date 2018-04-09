
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{
	
	public class CoCauMauFacade : BaseFacade
	{
		protected static CoCauMauFacade instance = new CoCauMauFacade(new CoCauMauModel());
		protected CoCauMauFacade(CoCauMauModel model) : base(model)
		{
		}
		public static CoCauMauFacade Instance
		{
			get { return instance; }
		}
		protected CoCauMauFacade():base() 
		{ 
		} 
	
	}
}
	