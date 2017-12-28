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

        // GET: api/values
        [HttpGet]
        [Route("GetUserStories")]
        public ICollection<UserStory> Get()
        {
            return userStory.GetUserStories();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [Route("GetUserStoryById")]
        public string Get(int id)
        {
            return $"User Story {id}";
        }

        // POST api/values
        [HttpPost]
        [Route("AddUserStory")]
        public int Post([FromBody]UserStory value)
        {
            return userStory.AddUserStory(value);
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
