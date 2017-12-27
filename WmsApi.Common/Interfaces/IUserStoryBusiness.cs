using System.Collections.Generic;
using WmsApi.Common.Models;

namespace WmsApi.Common.Interfaces
{
    public interface IUserStoryBusiness
    {
        ICollection<UserStory> GetUserStories();
        int AddUserStory(UserStory userStrory);
    }
}
