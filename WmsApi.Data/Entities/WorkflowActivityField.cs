using System;
using System.Collections.Generic;

namespace WmsApi.Data.Entities
{
    public partial class WorkflowActivityField
    {
        public int Id { get; set; }
        public int Type { get; set; }
        public int Activity { get; set; }
        public string Value { get; set; }

        public WorkflowActivity ActivityNavigation { get; set; }
        public WorkflowActivityFieldType TypeNavigation { get; set; }
    }
}
