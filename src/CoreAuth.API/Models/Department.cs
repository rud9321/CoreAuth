using System;
using System.Collections.Generic;

namespace CoreAuth.API.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Teacher> Teachers { get; set; }
    }
}
