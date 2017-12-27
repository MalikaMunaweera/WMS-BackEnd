using System.Linq;
using WmsApi.Data.Entities;
using WmsApi.Interfaces.Common;

namespace WmsApi.Data
{
    public class ProjectDataAccess : IProjectDataAccess
    {
        WMSContext db = new WMSContext();


        public string GetProjects()
        {
            return db.Project.Select(n => n.Name).FirstOrDefault();
        }
    }
}
