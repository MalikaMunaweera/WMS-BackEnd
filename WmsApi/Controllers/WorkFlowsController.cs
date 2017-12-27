using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WmsApi.Controllers
{
    [Route("api/WorkFlows")]
    public class WorkFlowsController : Controller
    {
        // GET api/values
        [HttpGet]
        [Route("GetWorkFlows")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
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
        public void Post([FromBody]string value)
        {
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
