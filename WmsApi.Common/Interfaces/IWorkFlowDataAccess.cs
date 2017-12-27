using System.Collections.Generic;
using WmsApi.Common.Models;

namespace WmsApi.Common.Interfaces
{
    public interface IWorkFlowDataAccess
    {
        ICollection<WorkFlow> GetWorkFlows();
        int AddWorkFlow(WorkFlow workFlow);
    }
}
