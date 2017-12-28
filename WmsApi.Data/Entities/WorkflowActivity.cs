using System;
using System.Collections.Generic;

namespace WmsApi.Data.Entities
{
    public partial class WorkflowActivity
    {
        public WorkflowActivity()
        {
            WorkflowActivityField = new HashSet<WorkflowActivityField>();
        }

        public int Id { get; set; }
        public int Type { get; set; }
        public int Workflow { get; set; }
        public double WorkflowVersion { get; set; }
        public string Name { get; set; }
        public int? ActivityOrderNumber { get; set; }

        public WorkflowActivityType TypeNavigation { get; set; }
        public Workflow WorkflowNavigation { get; set; }
        public ICollection<WorkflowActivityField> WorkflowActivityField { get; set; }
    }
}
