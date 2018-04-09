
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{
	
	public class ComputerFacade : BaseFacade
	{
		protected static ComputerFacade instance = new ComputerFacade(new ComputerModel());
		protected ComputerFacade(ComputerModel model) : base(model)
		{
		}
		public static ComputerFacade Instance
		{
			get { return instance; }
		}
		protected ComputerFacade():base() 
		{ 
		} 
	
	}
}
	