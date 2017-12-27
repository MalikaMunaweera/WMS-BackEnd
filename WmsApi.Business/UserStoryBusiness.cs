using System.Collections.Generic;
using WmsApi.Common.Interfaces;
using WmsApi.Common.Models;

namespace WmsApi.Business
{
    public class UserStoryBusiness : IUserStoryBusiness
    {
        private IUserStoryDataAccess dataAccess;

        public UserStoryBusiness(IUserStoryDataAccess userStoryDataAccess)
        {
            this.dataAccess = userStoryDataAccess;
        }

        public int AddUserStory(UserStory userStrory)
        {
            return dataAccess.AddUserStory(userStrory);
        }

        public ICollection<UserStory> GetUserStories()
        {
            return dataAccess.GetUserStories();
        }
    }
}
