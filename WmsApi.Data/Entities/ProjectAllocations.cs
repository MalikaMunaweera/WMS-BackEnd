using System;
using System.Collections.Generic;

namespace WmsApi.Data.Entities
{
    public partial class ProjectAllocations
    {
        public int Project { get; set; }
        public int Employee { get; set; }
        public string Role { get; set; }

        public Employee EmployeeNavigation { get; set; }
        public Project ProjectNavigation { get; set; }
    }
}
