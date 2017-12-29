using System;
using System.Collections.Generic;
using System.Text;

namespace WmsApi.Common.Models
{
    public class ActivityType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ActivityFieldType> FieldTypes { get; set; }

    }
}
