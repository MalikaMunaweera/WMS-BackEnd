﻿using System;
using System.Collections.Generic;

namespace WmsApi.Data.Entities
{
    public partial class WorkflowExecution
    {
        public WorkflowExecution()
        {
            WorkflowActivityExecution = new HashSet<WorkflowActivityExecution>();
        }

        public int Id { get; set; }
        public int Workflow { get; set; }
        public double WorkflowVersion { get; set; }
        public int UserStory { get; set; }
        public DateTime? StartDate { get; set; }
        public string Status { get; set; }
        public double? Progress { get; set; }
        public int? InitiatedBy { get; set; }
        public DateTime? EndDate { get; set; }

        public Employee InitiatedByNavigation { get; set; }
        public UserStory UserStoryNavigation { get; set; }
        public Workflow WorkflowNavigation { get; set; }
        public ICollection<WorkflowActivityExecution> WorkflowActivityExecution { get; set; }
    }
}
