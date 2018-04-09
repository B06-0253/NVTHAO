
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{
	
	public class File3DFacade : BaseFacade
	{
		protected static File3DFacade instance = new File3DFacade(new File3DModel());
		protected File3DFacade(File3DModel model) : base(model)
		{
		}
		public static File3DFacade Instance
		{
			get { return instance; }
		}
		protected File3DFacade():base() 
		{ 
		} 
	
	}
}
	