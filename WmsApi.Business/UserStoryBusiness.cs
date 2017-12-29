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

        public ICollection<UserStory> GetUserStories()
        {
            return dataAccess.GetUserStories();
        }

        public ICollection<UserStory> GetUserStoriesByStatus(string status)
        {
            return dataAccess.GetUserStoriesByStatus(status);
        }

        public UserStory GetUserStory(int id)
        {
            return dataAccess.GetUserStory(id);
        }

        public int AddUserStory(UserStory userStrory)
        {
            return dataAccess.AddUserStory(userStrory);
        }

        public int UpdateUserStory(UserStory userStrory)
        {
            return dataAccess.UpdateUserStory(userStrory);
        }
    }
}
