using System;
using System.Collections.Generic;
using System.Text;

namespace WmsApi.Common.Models
{
    public class WorkflowActivity
    {
        public int Id { get; set; }
        public ActivityType Type { get; set; }
        public int Workflow { get; set; }
        public double WorkflowVersion { get; set; }
        public string Name { get; set; }
        public int? ActivityOrderNumber { get; set; }
        public ICollection<WorkflowActivityField> Fields { get; set; }
    }
}
