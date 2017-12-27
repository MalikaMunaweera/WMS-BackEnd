using System.Collections.Generic;
using System.Linq;
using WmsApi.Common.Interfaces;
using WmsApi.Common.Models;
using WmsApi.Data.Entities;

namespace WmsApi.Data
{
    public class UserDataAccess : IUserDataAccess
    {
        WMSContext db = new WMSContext();

        public User GetUserByName(string name)
        {
            return db.Employee.Select(s => new Common.Models.User { Id = s.Id, FirstName = s.FirstName, LastName = s.LastName, Designation = s.Designation, Email = s.Email }).FirstOrDefault(u => u.FirstName == name);
        }

        public ICollection<Common.Models.User> GetUsers()
        {
            return db.Employee.Select(s => new Common.Models.User { Id = s.Id, FirstName = s.FirstName, LastName = s.LastName, Designation = s.Designation, Email = s.Email }).ToList();
        }
    }
}
