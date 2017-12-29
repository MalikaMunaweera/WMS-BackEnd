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

        // GET: api/Projects/GetProjects
        [HttpGet]
        [Route("GetProjects")]
        public ICollection<Project> Get()
        {
            return project.GetProjects();
        }

        // GET api/Projects/GetProjectById?id=5
        [HttpGet("{id}")]
        [Route("GetProjectById")]
        public string Get(int id)
        {
            return $"Project {id}";
        }
    }
}
