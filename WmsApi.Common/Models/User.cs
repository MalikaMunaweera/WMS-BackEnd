﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WmsApi.Common.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? Designation { get; set; }
        public string Email { get; set; }
    }
}
