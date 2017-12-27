using System.Collections.Generic;
using WmsApi.Common.Models;

namespace WmsApi.Common.Interfaces
{
    public interface IProjectDataAccess
    {
        ICollection<Project> GetProjects();
    }
}
