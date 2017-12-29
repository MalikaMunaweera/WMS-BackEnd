using System.Collections.Generic;
using WmsApi.Common.Models;

namespace WmsApi.Common.Interfaces
{
    public interface IUserStoryBusiness
    {
        ICollection<UserStory> GetUserStories();
        ICollection<UserStory> GetUserStoriesByStatus(string status);
        UserStory GetUserStory(int id);
        int AddUserStory(UserStory userStrory);
        int UpdateUserStory(UserStory userStrory);
    }
}
