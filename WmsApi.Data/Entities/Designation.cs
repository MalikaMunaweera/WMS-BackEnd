using System;
using System.Collections.Generic;

namespace WmsApi.Data.Entities
{
    public partial class Designation
    {
        public Designation()
        {
            Employee = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public int Level { get; set; }
        public string Name { get; set; }

        public ICollection<Employee> Employee { get; set; }
    }
}
