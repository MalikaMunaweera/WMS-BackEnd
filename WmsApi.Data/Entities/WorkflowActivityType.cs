using System;
using System.Collections.Generic;

namespace WmsApi.Data.Entities
{
    public partial class WorkflowActivityType
    {
        public WorkflowActivityType()
        {
            WorkflowActivity = new HashSet<WorkflowActivity>();
            WorkflowActivityFieldType = new HashSet<WorkflowActivityFieldType>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<WorkflowActivity> WorkflowActivity { get; set; }
        public ICollection<WorkflowActivityFieldType> WorkflowActivityFieldType { get; set; }
    }
}
