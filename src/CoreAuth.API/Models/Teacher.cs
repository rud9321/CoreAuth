using System;
using System.Collections.Generic;

namespace CoreAuth.API.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }        
        public int? Salary { get; set; }

        public Department Department { get; set; }
    }
}
