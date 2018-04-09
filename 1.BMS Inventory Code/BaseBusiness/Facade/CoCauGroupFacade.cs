
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{
	
	public class CoCauGroupFacade : BaseFacade
	{
		protected static CoCauGroupFacade instance = new CoCauGroupFacade(new CoCauGroupModel());
		protected CoCauGroupFacade(CoCauGroupModel model) : base(model)
		{
		}
		public static CoCauGroupFacade Instance
		{
			get { return instance; }
		}
		protected CoCauGroupFacade():base() 
		{ 
		} 
	
	}
}
	