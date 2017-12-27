using System;
using System.Collections.Generic;

namespace WmsApi.Data.Entities
{
    public partial class Project
    {
        public Project()
        {
            ProjectAllocations = new HashSet<ProjectAllocations>();
            UserStory = new HashSet<UserStory>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<ProjectAllocations> ProjectAllocations { get; set; }
        public ICollection<UserStory> UserStory { get; set; }
    }
}
