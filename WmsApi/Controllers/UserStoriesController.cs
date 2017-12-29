using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WmsApi.Common.Interfaces;
using WmsApi.Common.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WmsApi.Controllers
{
    [Route("api/UserStories")]
    public class UserStoriesController : Controller
    {
        private IUserStoryBusiness userStory;

        public UserStoriesController(IUserStoryBusiness userStory)
        {
            this.userStory = userStory;
        }

        // GET: api/UserStories/GetUserStories
        [HttpGet]
        [Route("GetUserStories")]
        public ICollection<UserStory> GetUserStories()
        {
            return userStory.GetUserStories();
        }

        // GET: api/UserStories/GetUserStoriesByStatus?status=new
        [HttpGet("{status}")]
        [Route("GetUserStoriesByStatus")]
        public ICollection<UserStory> GetUserStoriesByStatus(string status)
        {
            return userStory.GetUserStoriesByStatus(status);
        }

        // GET api/UserStories/GetUserStoryById?id=5
        [HttpGet("{id}")]
        [Route("GetUserStoryById")]
        public UserStory GetUserStoryById(int id)
        {
            return userStory.GetUserStory(id);
        }

        // POST api/UserStories/AddUserStory
        [HttpPost]
        [Route("AddUserStory")]
        public int AddUserStory([FromBody]UserStory value)
        {
            return userStory.AddUserStory(value);
        }

        // POST api/UserStories/UpdateUserStory
        [HttpPost]
        [Route("UpdateUserStory")]
        public int UpdateUserStory([FromBody]UserStory value)
        {
            return userStory.UpdateUserStory(value);
        }
    }
}
