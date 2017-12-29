using System;

namespace WmsApi.Common.Models
{
    public class ActivityExecution
    {
        public int Id { get; set; }
        public int WorkflowExecution { get; set; }
        public WorkflowActivity Activity { get; set; }
        public DateTime? StartDate { get; set; }
        public string Status { get; set; }
        public string OutCome { get; set; }
        public string Comments { get; set; }
        public DateTime? CompletedDate { get; set; }
    }
}
