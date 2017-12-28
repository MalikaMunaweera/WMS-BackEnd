using System;
using System.Collections.Generic;
using System.Linq;
using WmsApi.Common.Interfaces;
using WmsApi.Common.Models;
using WmsApi.Data.Entities;

namespace WmsApi.Data
{
    public class UserStoryDataAccess : IUserStoryDataAccess
    {
        WMSContext db = new WMSContext();

        public int AddUserStory(Common.Models.UserStory userStory)
        {
            Entities.UserStory US = new Entities.UserStory
            {
                Id = userStory.Id,
                Name = userStory.Name,
                UserType = userStory.UserType,
                Activity = userStory.Activity,
                BusinessValue = userStory.BusinessValue,
                AcceptanceCriteria = userStory.AcceptanceCriteria,
                CreatedDate = DateTime.Now,
                Creator = userStory.CreatedBy.Id,
                LastModified = DateTime.Now,
                ModifiedBy = userStory.ModifiedBy.Id,
                Project = userStory.Project.Id,
                ApprovalStatus = userStory.ApprovalStatus
            };
            db.UserStory.Add(US);
            db.SaveChanges();
            return US.Id;
        }

        public ICollection<Common.Models.UserStory> GetUserStories()
        {
            return db.UserStory.Select(userStory => new Common.Models.UserStory
            {
                Id = userStory.Id,
                Name = userStory.Name,
                UserType = userStory.UserType,
                Activity = userStory.Activity,
                BusinessValue = userStory.BusinessValue,
                AcceptanceCriteria = userStory.AcceptanceCriteria,
                CreatedDate = userStory.CreatedDate,
                CreatedBy = db.Employee.Select(s => new User { Id = s.Id, FirstName = s.FirstName, LastName = s.LastName, Designation = s.Designation, Email = s.Email }).FirstOrDefault(u => u.Id == userStory.Creator),//new User { Id = userStory.Creator ?? 0 },
                LastModified = userStory.LastModified,
                ModifiedBy = db.Employee.Select(s => new User { Id = s.Id, FirstName = s.FirstName, LastName = s.LastName, Designation = s.Designation, Email = s.Email }).FirstOrDefault(u => u.Id == userStory.ModifiedBy),//new User { Id = userStory.ModifiedBy ?? 0 },
                Project = db.Project.Select(s => new Common.Models.Project { Id = s.Id, Name = s.Name }).FirstOrDefault(p => p.Id == userStory.Project),//userStory.Project,
                ApprovalStatus = userStory.ApprovalStatus
            }).ToList();
        }
    }
}
