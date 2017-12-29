using System;
using System.Collections.Generic;
using System.Text;

namespace WmsApi.Common.Models
{
    public class ActivityFieldType
    {
        public int Id { get; set; }
        public int ActivityType { get; set; }
        public string Name { get; set; }
        public string DataType { get; set; }
    }
}
