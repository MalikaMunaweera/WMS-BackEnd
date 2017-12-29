using System.Collections.Generic;
using System.Linq;
using WmsApi.Data.Entities;
using WmsApi.Common.Interfaces;
using WmsApi.Common.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace WmsApi.Data
{
    public class UserStoryDataAccess : IUserStoryDataAccess
    {
        WMSContext db = new WMSContext();

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

        public ICollection<Common.Models.UserStory> GetUserStoriesByStatus(string status)
        {
            return db.UserStory.Where(w => w.ApprovalStatus == status).Select(userStory => new Common.Models.UserStory
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

        public Common.Models.UserStory GetUserStory(int id)
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
            }).FirstOrDefault(u => u.Id == id);
        }

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

        public int UpdateUserStory(Common.Models.UserStory userStory)
        {
            Entities.UserStory US = db.UserStory.FirstOrDefault(u => u.Id == userStory.Id);

            US.Id = userStory.Id;
            US.Name = userStory.Name;
            US.UserType = userStory.UserType;
            US.Activity = userStory.Activity;
            US.BusinessValue = userStory.BusinessValue;
            US.AcceptanceCriteria = userStory.AcceptanceCriteria;
            //US.CreatedDate = DateTime.Now;
            US.Creator = userStory.CreatedBy.Id;
            US.LastModified = DateTime.Now;
            US.ModifiedBy = userStory.ModifiedBy.Id;
            US.Project = userStory.Project.Id;
            US.ApprovalStatus = userStory.ApprovalStatus;

            db.UserStory.Update(US);
            db.SaveChanges();
            return US.Id;
        }
    }
}
