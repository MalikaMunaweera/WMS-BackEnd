using System.Collections.Generic;
using System.Linq;
using WmsApi.Data.Entities;
using WmsApi.Common.Interfaces;
using WmsApi.Common.Models;

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
                CreatedDate = userStory.CreatedDate,
                Creator = userStory.Creator,
                LastModified = userStory.LastModified,
                ModifiedBy = userStory.ModifiedBy,
                Project = userStory.Project,
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
                Creator = userStory.Creator,
                LastModified = userStory.LastModified,
                ModifiedBy = userStory.ModifiedBy,
                Project = userStory.Project,
                ApprovalStatus = userStory.ApprovalStatus
            }).ToList();
        }
    }
}
