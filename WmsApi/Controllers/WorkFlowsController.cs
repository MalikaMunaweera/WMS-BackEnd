using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WmsApi.Common.Interfaces;
using WmsApi.Common.Models;

namespace WmsApi.Controllers
{
    [Route("api/WorkFlows")]
    public class WorkFlowsController : Controller
    {
        private IWorkFlowBusiness workFloor;

        public WorkFlowsController(IWorkFlowBusiness workFloor)
        {
            this.workFloor = workFloor;
        }

        // GET api/WorkFlows/GetWorkFlows
        [HttpGet]
        [Route("GetWorkFlows")]
        public ICollection<WorkFlow> GetWorkFlows()
        {
            return workFloor.GetWorkFlows();
        }

        // GET api/WorkFlows/GetWorkFlowsByStatus?isActive=true
        [HttpGet("{isActive}")]
        [Route("GetWorkFlowsByStatus")]
        public ICollection<WorkFlow> GetWorkFlowsByStatus(bool isActive)
        {
            return workFloor.GetWorkFlowsByStatus(isActive);
        }

        // GET api/WorkFlows/GetActivityTypes
        [HttpGet]
        [Route("GetActivityTypes")]
        public ICollection<ActivityType> GetActivityTypes()
        {
            return workFloor.GetActivityTypes();
        }

        // GET api/WorkFlows/GetWorkFlowById?id=5
        [HttpGet("{id}")]
        [Route("GetWorkFlowById")]
        public WorkFlow GetWorkFlowById(int id)
        {
            return workFloor.GetWorkFlow(id);
        }

        // POST api/WorkFlows/AddWorkFlow
        [HttpPost]
        [Route("AddWorkFlow")]
        public int AddWorkFlow([FromBody]WorkFlow value)
        {
            return workFloor.AddWorkFlow(value);
        }

        // POST api/WorkFlows/StartWorkFlowExecution
        [HttpPost]
        [Route("StartWorkFlowExecution")]
        public int StartWorkFlowExecution([FromBody]WorkflowExecution value)
        {
            return workFloor.StartWorkFlowExecution(value);
        }

        // POST api/WorkFlows/UpdateWorkFlowActivityFields
        [HttpPost]
        [Route("UpdateWorkFlowActivityFields")]
        public void UpdateWorkFlowActivityFields([FromBody]ICollection<WorkflowActivity> value)
        {
            workFloor.UpdateWorkFlowActivityFields(value);
        }

        // POST api/WorkFlows/UpdateWorkFlow
        [HttpPost]
        [Route("UpdateWorkFlow")]
        public int UpdateWorkFlow([FromBody]WorkFlow value)
        {
            return workFloor.UpdateWorkFlow(value);
        }
    }
}
