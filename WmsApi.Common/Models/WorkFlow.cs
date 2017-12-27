using System;
using System.Collections.Generic;
using System.Text;

namespace WmsApi.Common.Models
{
    public class WorkFlow
    {
        public int Id { get; set; }
        public double Version { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public bool? IsActive { get; set; }
    }
}
