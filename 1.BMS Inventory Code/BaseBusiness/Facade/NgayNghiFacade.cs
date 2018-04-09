
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{
	
	public class NgayNghiFacade : BaseFacade
	{
		protected static NgayNghiFacade instance = new NgayNghiFacade(new NgayNghiModel());
		protected NgayNghiFacade(NgayNghiModel model) : base(model)
		{
		}
		public static NgayNghiFacade Instance
		{
			get { return instance; }
		}
		protected NgayNghiFacade():base() 
		{ 
		} 
	
	}
}
	