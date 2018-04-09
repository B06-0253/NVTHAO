
using System.Collections;
using TPA.Model;
namespace TPA.Facade
{
	
	public class PartBorrowFacade : BaseFacade
	{
		protected static PartBorrowFacade instance = new PartBorrowFacade(new PartBorrowModel());
		protected PartBorrowFacade(PartBorrowModel model) : base(model)
		{
		}
		public static PartBorrowFacade Instance
		{
			get { return instance; }
		}
		protected PartBorrowFacade():base() 
		{ 
		} 
	
	}
}
	