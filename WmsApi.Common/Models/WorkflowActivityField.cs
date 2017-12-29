using System;
using System.Collections.Generic;

namespace WmsApi.Common.Models
{
    public class WorkflowActivityField
    {
        public int Id { get; set; }
        public ActivityFieldType Type { get; set; }
        public int Activity { get; set; }
        public string Value { get; set; }
    }
}
