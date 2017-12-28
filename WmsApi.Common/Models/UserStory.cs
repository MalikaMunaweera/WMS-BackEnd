using System;

namespace WmsApi.Common.Models
{
    public class UserStory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserType { get; set; }
        public string Activity { get; set; }
        public string BusinessValue { get; set; }
        public string AcceptanceCriteria { get; set; }
        public DateTime? CreatedDate { get; set; }
        public User CreatedBy { get; set; }
        public DateTime? LastModified { get; set; }
        public User ModifiedBy { get; set; }
        public Project Project { get; set; }
        public string ApprovalStatus { get; set; }
    }
}
