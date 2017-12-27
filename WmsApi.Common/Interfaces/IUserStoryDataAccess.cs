using System.Collections.Generic;
using WmsApi.Common.Models;

namespace WmsApi.Common.Interfaces
{
    public interface IUserStoryDataAccess
    {
        ICollection<UserStory> GetUserStories();
        int AddUserStory(UserStory userStrory);
    }
}
