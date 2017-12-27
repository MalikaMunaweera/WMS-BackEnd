using System.Collections.Generic;
using System.Linq;
using WmsApi.Data.Entities;
using WmsApi.Common.Interfaces;

namespace WmsApi.Data
{
    public class ProjectDataAccess : IProjectDataAccess
    {
        WMSContext db = new WMSContext();

        public ICollection<Common.Models.Project> GetProjects()
        {
            return db.Project.Select(s => new Common.Models.Project { Id = s.Id, Name = s.Name }).ToList();
        }
    }
}
