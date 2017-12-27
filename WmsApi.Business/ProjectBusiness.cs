using System.Collections.Generic;
using WmsApi.Common.Interfaces;
using WmsApi.Common.Models;

namespace WmsApi.Business
{
    public class ProjectBusiness : IProjectBusiness
    {
        private IProjectDataAccess dataAccess;

        public ProjectBusiness(IProjectDataAccess projectDataAccess)
        {
            this.dataAccess = projectDataAccess;
        }

        public ICollection<Project> GetProjects()
        {
            return dataAccess.GetProjects();
        }


    }
}
