using System.Collections.Generic;
using WmsApi.Common.Interfaces;
using WmsApi.Common.Models;

namespace WmsApi.Business
{
    public class UserBusiness : IUserBusiness
    {
        private IUserDataAccess dataAccess;

        public UserBusiness(IUserDataAccess userDataAccess)
        {
            this.dataAccess = userDataAccess;
        }

        public User GetUserByName(string name)
        {
            return dataAccess.GetUserByName(name);
        }

        public ICollection<User> GetUsers()
        {
            return dataAccess.GetUsers();
        }
    }
}
