
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{
	
	public class TemplateFacade : BaseFacade
	{
		protected static TemplateFacade instance = new TemplateFacade(new TemplateModel());
		protected TemplateFacade(TemplateModel model) : base(model)
		{
		}
		public static TemplateFacade Instance
		{
			get { return instance; }
		}
		protected TemplateFacade():base() 
		{ 
		} 
	
	}
}
	