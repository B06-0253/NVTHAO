
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{
	
	public class TestFacade : BaseFacade
	{
		protected static TestFacade instance = new TestFacade(new TestModel());
		protected TestFacade(TestModel model) : base(model)
		{
		}
		public static TestFacade Instance
		{
			get { return instance; }
		}
		protected TestFacade():base() 
		{ 
		} 
	
	}
}
	