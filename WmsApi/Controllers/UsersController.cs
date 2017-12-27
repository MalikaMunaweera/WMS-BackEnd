using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WmsApi.Common.Interfaces;
using WmsApi.Common.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WmsApi.Controllers
{
    [Route("api/Users")]
    public class UsersController : Controller
    {
        private IUserBusiness user;

        public UsersController(IUserBusiness user)
        {
            this.user = user;
        }

        // GET: api/values
        [HttpGet]
        [Route("GetUsers")]
        public ICollection<User> Get()
        {
            return user.GetUsers();
        }

        // GET api/values/5
        [HttpGet("{firstName}")]
        [Route("GetUserByFirstName")]
        public User Get(string firstName)
        {
            return user.GetUserByName(firstName);
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
