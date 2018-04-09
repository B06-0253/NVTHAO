
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{
	
	public class SanPhamDAFacade : BaseFacade
	{
		protected static SanPhamDAFacade instance = new SanPhamDAFacade(new SanPhamDAModel());
		protected SanPhamDAFacade(SanPhamDAModel model) : base(model)
		{
		}
		public static SanPhamDAFacade Instance
		{
			get { return instance; }
		}
		protected SanPhamDAFacade():base() 
		{ 
		} 
	
	}
}
	