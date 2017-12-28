using System;
using System.Collections.Generic;

namespace WmsApi.Data.Entities
{
    public partial class Employee
    {
        public Employee()
        {
            ProjectAllocations = new HashSet<ProjectAllocations>();
            UserStoryCreatorNavigation = new HashSet<UserStory>();
            UserStoryModifiedByNavigation = new HashSet<UserStory>();
            Workflow = new HashSet<Workflow>();
            WorkflowExecution = new HashSet<WorkflowExecution>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? Designation { get; set; }
        public string Email { get; set; }

        public Designation DesignationNavigation { get; set; }
        public ICollection<ProjectAllocations> ProjectAllocations { get; set; }
        public ICollection<UserStory> UserStoryCreatorNavigation { get; set; }
        public ICollection<UserStory> UserStoryModifiedByNavigation { get; set; }
        public ICollection<Workflow> Workflow { get; set; }
        public ICollection<WorkflowExecution> WorkflowExecution { get; set; }
    }
}
