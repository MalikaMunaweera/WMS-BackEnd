using WmsApi.Interfaces.Common;

namespace WmsApi.Business
{
    public class ProjectBusiness : IProjectBusiness
    {
        private IProjectDataAccess dataAccess;

        public ProjectBusiness(IProjectDataAccess projectDataAccess)
        {
            this.dataAccess = projectDataAccess;
        }

        public string GetProjects()
        {
            return dataAccess.GetProjects();
        }


    }
}
