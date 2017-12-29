using System.Collections.Generic;
using WmsApi.Common.Interfaces;
using WmsApi.Common.Models;

namespace WmsApi.Business
{
    public class WorkFlowBusiness : IWorkFlowBusiness
    {
        private IWorkFlowDataAccess dataAccess;

        public WorkFlowBusiness(IWorkFlowDataAccess workFlowDataAccess)
        {
            this.dataAccess = workFlowDataAccess;
        }

        public ICollection<WorkFlow> GetWorkFlows()
        {
            return dataAccess.GetWorkFlows();
        }

        public ICollection<WorkFlow> GetWorkFlowsByStatus(bool isActive)
        {
            return dataAccess.GetWorkFlowsByStatus(isActive);
        }

        public WorkFlow GetWorkFlow(int id)
        {
            return dataAccess.GetWorkFlow(id);
        }

        public int AddWorkFlow(WorkFlow workFlow)
        {
            return dataAccess.AddWorkFlow(workFlow);
        }

        public int StartWorkFlowExecution(WorkflowExecution execution)
        {
            return dataAccess.StartWorkFlowExecution(execution);
        }

        public int CompleteWorkFlowExecution(WorkflowExecution execution)
        {
            return dataAccess.CompleteWorkFlowExecution(execution);
        }

        public int UpdateWorkFlow(WorkFlow workFlow)
        {
            return dataAccess.AddWorkFlow(workFlow);
        }

        public void UpdateWorkFlowActivityFields(ICollection<WorkflowActivity> activityList)
        {
            foreach (var activity in activityList)
            {
                foreach (var field in activity.Fields)
                {
                    dataAccess.UpdateWorkFlowActivityFields(field);
                }
            }
        }

        public ICollection<ActivityType> GetActivityTypes()
        {
            return dataAccess.GetActivityTypes();
        }
    }
}
