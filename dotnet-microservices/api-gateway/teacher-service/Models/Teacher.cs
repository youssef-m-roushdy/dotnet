using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace teacher_service.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? School { get; set; }
    }
}