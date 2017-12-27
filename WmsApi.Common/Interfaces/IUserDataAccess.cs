using System.Collections.Generic;
using WmsApi.Common.Models;

namespace WmsApi.Common.Interfaces
{
    public interface IUserDataAccess
    {
        ICollection<User> GetUsers();
        User GetUserByName(string name);
    }
}
