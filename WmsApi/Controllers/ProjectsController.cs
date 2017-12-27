using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WmsApi.Common.Models;
using WmsApi.Common.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WmsApi.Controllers
{
    [Route("api/Projects")]
    public class ProjectsController : Controller
    {
        private IProjectBusiness project;

        public ProjectsController(IProjectBusiness project)
        {
            this.project = project;
        }

        // GET: api/values
        [HttpGet]
        [Route("GetProjects")]
        public ICollection<Project> Get()
        {
            //var a = project.GetProjects();
            return project.GetProjects();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [Route("GetProjectById")]
        public string Get(int id)
        {
            return $"Project {id}";
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
