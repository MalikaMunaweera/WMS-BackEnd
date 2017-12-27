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

        public int AddWorkFlow(WorkFlow workFlow)
        {
            return dataAccess.AddWorkFlow(workFlow);
        }

        public ICollection<WorkFlow> GetWorkFlows()
        {
            return dataAccess.GetWorkFlows();
        }
    }
}
