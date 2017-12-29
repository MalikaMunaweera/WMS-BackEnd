using System;
using System.Collections.Generic;

namespace WmsApi.Common.Models
{
    public partial class WorkflowExecution
    {
        public int Id { get; set; }
        public int Workflow { get; set; }
        public double WorkflowVersion { get; set; }
        public int UserStory { get; set; }
        public DateTime? StartDate { get; set; }
        public string Status { get; set; }
        public double? Progress { get; set; }
        public User InitiatedBy { get; set; }
        public DateTime? EndDate { get; set; }
        public ICollection<ActivityExecution> ActivityExecutions { get; set; }
    }
}
