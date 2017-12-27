using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WmsApi.Controllers
{
    [Route("api/Users")]
    public class UsersController : Controller
    {
        // GET: api/values
        [HttpGet]
        [Route("GetUsers")]
        public IEnumerable<string> Get()
        {
            return new string[] { "user1", "usere2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [Route("GetUserById")]
        public string Get(int id)
        {
            return $"User {id}";
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
