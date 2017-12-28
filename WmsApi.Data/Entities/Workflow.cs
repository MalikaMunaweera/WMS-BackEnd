using System;
using System.Collections.Generic;

namespace WmsApi.Data.Entities
{
    public partial class Workflow
    {
        public Workflow()
        {
            WorkflowActivity = new HashSet<WorkflowActivity>();
            WorkflowExecution = new HashSet<WorkflowExecution>();
        }

        public int Id { get; set; }
        public double Version { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public bool? IsActive { get; set; }

        public Employee CreatedByNavigation { get; set; }
        public ICollection<WorkflowActivity> WorkflowActivity { get; set; }
        public ICollection<WorkflowExecution> WorkflowExecution { get; set; }
    }
}
