using System;
using System.Collections.Generic;

namespace WmsApi.Data.Entities
{
    public partial class UserStory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserType { get; set; }
        public string Activity { get; set; }
        public string BusinessValue { get; set; }
        public string AcceptanceCriteria { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? Creator { get; set; }
        public DateTime? LastModified { get; set; }
        public int? ModifiedBy { get; set; }
        public int? Project { get; set; }
        public string ApprovalStatus { get; set; }

        public Employee CreatorNavigation { get; set; }
        public Employee IdNavigation { get; set; }
        public Project ProjectNavigation { get; set; }
    }
}
