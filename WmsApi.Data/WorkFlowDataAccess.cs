using System.Collections.Generic;
using System.Linq;
using WmsApi.Data.Entities;
using WmsApi.Common.Interfaces;
using WmsApi.Common.Models;

namespace WmsApi.Data
{
    public class WorkFlowDataAccess : IWorkFlowDataAccess
    {
        WMSContext db = new WMSContext();

        public int AddWorkFlow(Common.Models.WorkFlow workFlow)
        {
            Entities.Workflow WF = new Entities.Workflow
            {
                Id = workFlow.Id,
                Version = workFlow.Version,
                Name = workFlow.Name,
                CreatedDate = workFlow.CreatedDate,
                CreatedBy = workFlow.CreatedBy,
                IsActive = workFlow.IsActive
            };
            db.Workflow.Add(WF);
            db.SaveChanges();
            return WF.Id;
        }

        public ICollection<Common.Models.WorkFlow> GetWorkFlows()
        {
            return db.Workflow.Select(workFlow => new Common.Models.WorkFlow
            {
                Id = workFlow.Id,
                Version = workFlow.Version,
                Name = workFlow.Name,
                CreatedDate = workFlow.CreatedDate,
                CreatedBy = workFlow.CreatedBy,
                IsActive = workFlow.IsActive
            }).ToList();
        }
    }
}
