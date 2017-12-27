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

        // GET api/values
        [HttpGet]
        [Route("GetWorkFlows")]
        public ICollection<WorkFlow> Get()
        {
            return workFloor.GetWorkFlows();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [Route("GetWorkFlowById")]
        public string Get(int id)
        {
            return $"Work Floor {id}";
        }

        // POST api/values
        [HttpPost]
        [Route("AddWorkFlow")]
        public int Post([FromBody]WorkFlow value)
        {
            return workFloor.AddWorkFlow(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
