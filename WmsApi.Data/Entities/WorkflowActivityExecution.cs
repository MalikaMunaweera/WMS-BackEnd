using System;
using System.Collections.Generic;

namespace WmsApi.Data.Entities
{
    public partial class WorkflowActivityExecution
    {
        public int Id { get; set; }
        public int WorkflowExecution { get; set; }
        public int Activity { get; set; }
        public DateTime? StartDate { get; set; }
        public string Status { get; set; }
        public string OutCome { get; set; }
        public string Comments { get; set; }
        public DateTime? CompletedDate { get; set; }
        public int? CompletedBy { get; set; }

        public WorkflowExecution WorkflowExecutionNavigation { get; set; }
    }
}
