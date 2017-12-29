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

        // GET: api/Users/GetUsers
        [HttpGet]
        [Route("GetUsers")]
        public ICollection<User> Get()
        {
            return user.GetUsers();
        }

        // GET api/Users/GetUserByFirstName?firstName=Rose
        [HttpGet("{firstName}")]
        [Route("GetUserByFirstName")]
        public User Get(string firstName)
        {
            return user.GetUserByName(firstName);
        }
    }
}
