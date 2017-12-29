using System.Collections.Generic;
using WmsApi.Common.Models;

namespace WmsApi.Common.Interfaces
{
    public interface IWorkFlowBusiness
    {
        ICollection<WorkFlow> GetWorkFlows();
        ICollection<WorkFlow> GetWorkFlowsByStatus(bool isActive);
        WorkFlow GetWorkFlow(int id);
        int AddWorkFlow(WorkFlow workFlow);
        int StartWorkFlowExecution(WorkflowExecution execution);
        int CompleteWorkFlowExecution(WorkflowExecution execution);
        int UpdateWorkFlow(WorkFlow workFlow);
        void UpdateWorkFlowActivityFields(ICollection<WorkflowActivity> activityList);
        ICollection<ActivityType> GetActivityTypes();
    }
}
