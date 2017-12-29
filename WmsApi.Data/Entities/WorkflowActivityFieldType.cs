using System;
using System.Collections.Generic;

namespace WmsApi.Data.Entities
{
    public partial class WorkflowActivityFieldType
    {
        public WorkflowActivityFieldType()
        {
            WorkflowActivityField = new HashSet<WorkflowActivityField>();
        }

        public int Id { get; set; }
        public int ActivityType { get; set; }
        public string Name { get; set; }
        public string DataType { get; set; }

        public WorkflowActivityType ActivityTypeNavigation { get; set; }
        public ICollection<WorkflowActivityField> WorkflowActivityField { get; set; }
    }
}
