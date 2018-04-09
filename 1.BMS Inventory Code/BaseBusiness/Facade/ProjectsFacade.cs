
using System.Collections;
using BMS.Model;
namespace BMS.Facade
{

    public class ProjectsFacade : BaseFacade
    {
        protected static ProjectsFacade instance = new ProjectsFacade(new ProjectsModel());
        protected ProjectsFacade(ProjectsModel model)
            : base(model)
        {
        }
        public static ProjectsFacade Instance
        {
            get { return instance; }
        }
        protected ProjectsFacade()
            : base()
        {
        }

    }
}
