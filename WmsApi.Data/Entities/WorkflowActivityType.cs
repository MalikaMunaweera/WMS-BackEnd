using System;
using System.Collections.Generic;

namespace WmsApi.Data.Entities
{
    public partial class WorkflowActivityType
    {
        public WorkflowActivityType()
        {
            WorkflowActivity = new HashSet<WorkflowActivity>();
            WorkflowActivityField = new HashSet<WorkflowActivityField>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<WorkflowActivity> WorkflowActivity { get; set; }
        public ICollection<WorkflowActivityField> WorkflowActivityField { get; set; }
    }
}
